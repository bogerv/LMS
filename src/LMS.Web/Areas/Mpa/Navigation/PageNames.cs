using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Areas.Mpa.Navigation
{
    public static class PageNames
    {
        public static class Common
        {
            public const string Administration = "Administration";
            public const string Roles = "Roles";
            public const string Users = "Users";
            public const string AuditLogs = "AuditLogs";
            public const string Teams = "Teams";
            public const string Languages = "Languages";
            public const string Jobs = "Jobs";
        }

        public static class Competence
        {
            public const string Competences = "Competences";
            public const string MyCompetences = "MyCompetences";
            public const string MyCompetencePacks = "MyCompetencePacks";
            public const string MyLearningItems = "MyLearningItems";

            public const string MyEmployeeCompetences = "MyEmployeeCompetences";
            public const string EmployeeCompetencePacks = "EmployeeCompetencePacks";
            public const string EmployeeLearningItems = "EmployeeLearningItems";

            public const string MyMenteeCompetences = "MyMenteeCompetences";
            public const string MenteeCompetencePacks = "MenteeCompetencePacks";
            public const string MenteeLearningItems = "MenteeLearningItems";

            public const string Statistics = "Statistics";
            public const string PersonalCompetences = "PersonalCompetences";
            public const string GroupCompetences = "GroupCompetences";
            public const string ScoresAndRanking = "ScoresAndRanking";
        }
    }
}