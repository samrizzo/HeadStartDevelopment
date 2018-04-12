using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HeadStart.Models
{
    class Milestones
    {
        public int MilestoneId { get; set; }
        public string AgeGroup { get; set; }
        public string Category { get; set; }
        public string Milestone { get; set; }
        public bool IsWarningSign { get; set; }

        public List<Milestones> GetMilestones()
        {
            List<Milestones> milestoneList = new List<Milestones>();

            //foreach (var item in db.Milestones)
            //{
            //    var milestone = new Milestones
            //    {
            //        MilestoneId = item.MilestoneId,
            //        AgeGroup = item.AgeGroup,
            //        Category = item.Category,
            //        Milestone = item.Milestone,
            //        IsWarningSign = item.IsWarningSign
            //    };

            //    milestoneList.Add(milestone);
            //}

            return milestoneList;
        }
    }
}