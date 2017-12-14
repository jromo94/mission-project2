using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionaryWebsiteP2.Models;
using MissionaryWebsiteP2.DAL;

namespace MissionaryWebsiteP2.Controllers
{

    public class MissionController : Controller
    {
        private MissionContext db = new MissionContext();
        // GET: Mission
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MissionPage(int mission_ID)
        {

            IEnumerable<MissionQuestions> questions = db.Database.SqlQuery<MissionQuestions>(
                "SELECT MissionQuestions.MissionQuestion_ID, MissionQuestions.question, MissionQuestions.answer, " +
                "MissionQuestions.user_ID, MissionQuestions.mission_ID " +
                "FROM MissionQuestions " +
                "WHERE MissionQuestions.mission_ID = " + mission_ID);


            IEnumerable<Missions> missions = db.Database.SqlQuery<Missions>(
                "SELECT Missions.mission_ID, Missions.missionName, Missions.missionPresidentName, Missions.missionAddress, Missions.missionLanguage, " +
                "Missions.missionClimate, Missions.missionDominantReligion, Missions.missionFlag " +
                "FROM Missions " +
                "WHERE Missions.mission_ID = " + mission_ID);

            ViewBag.missionID = mission_ID;
            ViewBag.questions = questions;
            ViewBag.missions = missions;

            return View(missions);
        }

        [HttpPost]
        public ActionResult MissionPage(FormCollection answer, int? question_ID, int? mission_ID)
        {
            MissionQuestions myQuestion = db.MissionQuestion.Find(question_ID);
            myQuestion.answer = answer["answer" + question_ID];
            string fullname = TempData["firstname"].ToString() + " " + TempData["lastname"].ToString();
            myQuestion.user_ID = fullname;
            db.SaveChanges();       

            return RedirectToAction("MissionPage", new { mission_ID = myQuestion.mission_ID });
        }

        [HttpPost]
        public ActionResult MissionPage2(FormCollection newQuestion, int mission_ID)
        {
            TempData["error"] = "";
            if (newQuestion["newQuestion"] != "")
            {
                MissionQuestions newQuestions = new MissionQuestions();
                newQuestions.question = newQuestion["newQuestion"];
                newQuestions.mission_ID = mission_ID;
                db.MissionQuestion.Add(newQuestions);
                db.SaveChanges();
            }
            else
            {
                TempData["error"] = "Please type something";
            }
            return RedirectToAction("MissionPage", new { mission_ID = mission_ID });
        }
    }
}