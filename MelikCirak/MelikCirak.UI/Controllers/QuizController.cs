using MelikCirak.BusinessLayer.Concrete;
using MelikCirak.DataAcessLayer.EntityFramework;
using MelikCirak.EntityLayer.Concrete;
using MelikCirak.UI.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MelikCirak.UI.Controllers
{
    public class QuizController : Controller
    {
        private QuizManager quizManager;
        private QuestionManager questionManager;
        private OptionManager optionManager;
        public QuizController()
        {
            quizManager = new QuizManager(new EfQuizRepository());
            questionManager = new QuestionManager(new EfQuestionRepository());
            optionManager = new OptionManager(new EfOptionRepository());
        }

        public IActionResult Index()
        {
            var models = quizManager.GetAll();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<Question> Questions, string Title, string QContent)
        {
            //create quiz and adding to db
            Quiz quiz = new Quiz();
            quiz.CreateDate = System.DateTime.Now;
            quiz.UserId = (int)HttpContext.Session.GetInt32("user");
            quiz.Title = Title;
            quiz.Content = QContent;
            quizManager.Insert(quiz);
            //create quiz and adding to db

            //create questions and adding to db
            for (int i = 0; i < 4; i++)
            {
                var q = new Question();
                q.QuestionContent = Questions[i].QuestionContent;
                q.QuizId = quiz.Id;               
                questionManager.Insert(q);

                int oCount = 0;//option count 
                int RightOptId = 0;//the questions right answer
                foreach (var item in Questions[i].Options)
                {
                    var opt = new Option();
                    opt.OptionContent = item.OptionContent;
                    opt.IsAnswer = false;
                    if (Questions[i].RightOptionIndex == oCount)
                    {
                        //is the right answer
                        opt.IsAnswer = true;
                    }
                    oCount++;

                    opt.QuestionId = q.Id;
                    optionManager.Insert(opt);
                    if (opt.IsAnswer == true)
                    {
                        RightOptId = opt.Id;
                    }
                }
                if (RightOptId != 0)
                {
                    var _q = questionManager.Get(q.Id);
                    q.RightOptionId = RightOptId;
                    questionManager.Update(_q);
                }

            }
            //create questions and adding to db
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            quizManager.Delete(quizManager.Get(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Start(int id)
        {
            var quiz = quizManager.Get(id);
            ViewBag.Questions = questionManager.GetAll(x => x.QuizId == id);
            return View(quiz);
        }

        [HttpGet]
        public string GetPost(string url)
        {
            string xpath = "/html/body/div[1]/div/main/article/div[2]/div[1]/div[1]/div[1]/div[1]/div/div"; //it is paragraph path from wired.com/postlink
            GetFromWired wired = new GetFromWired(url,xpath);
            return wired.GetPost();
        }
    }
}
