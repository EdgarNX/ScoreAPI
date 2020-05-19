using Microsoft.AspNetCore.Mvc;
using ScoreAPI.DbContexts;
using ScoreAPI.Entity;
using ScoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreAPI.Controllers
{
    [ApiController]
    [Route("api/scores")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;
        
        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository ??
                throw new ArgumentNullException(nameof(scoreRepository));

        }

        [HttpGet]
        public IActionResult GetScores()
        {
            var scoresFromRepo = _scoreRepository.GetScores();

            return Ok(scoresFromRepo);
        }

        [HttpGet]
        [Route("{userName}")]
        public IActionResult GetScore(string userName)
        {
            var userFromRepo = _scoreRepository.GetUser(userName);
            if (userFromRepo == null)
                return NotFound();

            return Ok(userFromRepo.Points);
        }

        [HttpPost]
        public IActionResult CreateScore([FromBody] Score score)
        {
            _scoreRepository.AddScore(score);
            _scoreRepository.Save();

            return Ok();
        }

        [HttpPut]
        [Route("{userName}/{userPoints}")]
        public ActionResult UpdateScore(string userName, int userPoints)
        {
            if (!_scoreRepository.ScoreExists(userName))
                return NotFound();

            var scoreFromRepo = _scoreRepository.GetUser(userName);
            if (scoreFromRepo == null)
                return NotFound();

            if (scoreFromRepo.Points < userPoints)
                scoreFromRepo.Points = userPoints;

            _scoreRepository.UpdateUser(scoreFromRepo);
            _scoreRepository.Save();

            return NoContent();
        }

        [HttpDelete]
        [Route("{userName}")]
        public IActionResult DeleteScore(string userName)
        {
            var scoreToDelete = _scoreRepository.GetUser(userName);

            if (scoreToDelete == null)
                return NotFound();

            _scoreRepository.DeleteScore(scoreToDelete);
            _scoreRepository.Save();

            return NoContent();
        }
    }
}
