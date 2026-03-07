using ExamProject.Dtos;
using ExamProject.Servises;
using Microsoft.AspNetCore.Mvc;

namespace ExamProject.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController()
        {
            _questionService = new QuestionService();
        }

        [HttpPost("add")]
        public Guid Create(QuestionCreateDto questionCreateDto)
        {
            return _questionService.AddQuestion(questionCreateDto);
        }

        [HttpGet("get-count")]
        public int GetCount()
        {
            return _questionService.GetCountOfQuestions();
        }

        [HttpGet("get-random")]
        public QuestionGetDto GetRandom()
        {
            return _questionService.GetRandomQuestion();
        }

        [HttpDelete("remove")]
        public bool Delete(Guid id)
        {
            return _questionService.RemoveQuestion(id);
        }

        [HttpPost("solve")]
        public (bool isCorrect, string correctAnswer) Solve(Guid id, string answer)
        {
            return _questionService.SolveQuestion(id, answer);
        }
    }
}
