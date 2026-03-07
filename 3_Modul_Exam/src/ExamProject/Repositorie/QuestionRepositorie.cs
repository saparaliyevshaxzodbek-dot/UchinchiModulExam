using ExamProject.Models;
using System.Text.Json;

namespace ExamProject.Repositorie;

public class QuestionRepositorie : IQuestionRepositorie
{
    private readonly string FilePath;

    public QuestionRepositorie()
    {
        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Questions.Json");
        if(!File.Exists(FilePath))
        {
            var stream = File.Create(FilePath);
            stream.Close();
        }
    }
    public List<Question>? GetAllQuestions()
    {
        var json =File.ReadAllText(FilePath);
        if(string.IsNullOrEmpty(json))
        {
            return new List<Question>();
        }
        var questions = JsonSerializer.Deserialize<List<Question>>(json);
        return questions;

    }

    public void SaveAllQuestions(List<Question> questions)
    {
        var json = JsonSerializer.Serialize(questions);
        File.WriteAllText(FilePath, json);
    }
}
