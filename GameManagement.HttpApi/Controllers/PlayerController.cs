using AutoMapper;
using GameManagement.Contracts;
using GameManagement.Entites;
using GameManagement.Entites.DTOs;
using GameManagement.Entites.ReponseType.DataShaping;
using GameManagement.Entites.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameManagement.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;
        public PlayerController(IRepositoryWrapper repository, ILogger<PlayerController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlayers([FromQuery] PlayerParameter playerParameter)
        {
            if (!playerParameter.ValidDateCreatedRange)
            {
                return BadRequest("开始日期不能大于结束日期");
            }
            try
            {
                var players = _repository.Player.GetPlayers(playerParameter);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(players.MetaData));

                var result = _mapper.Map<IEnumerable<PlayerDTO>>(players).ShapeData(playerParameter.Fields);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "PlayerById")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerById(id);
                if (player == null)
                {
                    return NotFound();
                }
                var result = _mapper.Map<PlayerDTO>(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}/character")]
        public async Task<IActionResult> GetPlayerWithCharacters(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerWithCharacters(id);
                if (player == null)
                {
                    return NotFound();
                }
                var result = _mapper.Map<PlayerWithCharactersDTO>(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody]PlayerForCreationDTO player)
        {
            try
            {
                if (player is null)
                {
                    return BadRequest("请求数据不能为空");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求数据");
                }
                var playerEntity = _mapper.Map<Player>(player);

                _repository.Player.Create(playerEntity);
                 await _repository.Save();

                var createdPlayer = _mapper.Map<PlayerDTO>(playerEntity);
                return CreatedAtRoute("PlayerById", new { id = createdPlayer.Id }, createdPlayer);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody]PlayerForUpdateDTO player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求对象");
                }

                var playerEntity = await _repository.Player.GetPlayerById(id);
                if (playerEntity is null)
                {
                    return NotFound("该玩家不存在");
                }
                _mapper.Map(player, playerEntity);

                _repository.Player.Update(playerEntity);
                await _repository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerById(id);
                if(player is null)
                {
                    return NotFound("该玩家不存在");
                }
                if(player.Characters.Any())
                {
                    return BadRequest("该玩家有关联角色吗，不能删除！");
                }
                _repository.Player.Delete(player);
                await _repository.Save();

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
