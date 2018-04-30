using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace HeadStart.Models
{
    class HeadStartDbContext
    {
        public void DatabaseStartup()
        {
            Console.WriteLine("Creating database, if it doesn't already exist");

            // Create Db Path
            string dbPath = Path.Combine(
                 System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                 "headstart.db3");

            // Create connection & table
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Milestones>();

            // Create a list of milestones
            List<Milestones> milestones = PopulateMilestoneList();

            // Insert the values
            if (db.Table<Milestones>().Count() == 0)
            {
                foreach (var milestone in milestones)
                {
                    db.Insert(milestone);
                }
            }

            // Close the connection
            db.Close();
        }

        public List<string> GetMilestoneData(int ageGroup)
        {
            try
            {
                using (var connection = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "headstart.db3")))
                {
                    List<string> milestoneList = new List<string>();
                    var data = connection.Table<Milestones>().ToList();

                    foreach (var milestone in data)
                    {
                        if (milestone.AgeGroup == ageGroup)
                        {
                            milestoneList.Add(milestone.Milestone);
                        }
                    }

                    return milestoneList;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Populate a list of milestones for each age category
        private static List<Milestones> PopulateMilestoneList()
        {
            List<Milestones> milestones = new List<Milestones>
            {
                /** Insert milestones for Age 0-3 months **/
                new Milestones { AgeGroup = 3, Milestone = "Begins to smile at people" },
                new Milestones { AgeGroup = 3, Milestone = "Can briefly calm herself (may bring hands to mouth and suck on hand)" },
                new Milestones { AgeGroup = 3, Milestone = "Coos, makes gurgling sounds" },
                new Milestones { AgeGroup = 3, Milestone = "Turns head toward sounds" },
                new Milestones { AgeGroup = 3, Milestone = "Pays attention to faces" },
                new Milestones { AgeGroup = 3, Milestone = "Begins to follow things with eyes and recognize people at a distance" },
                new Milestones { AgeGroup = 3, Milestone = "Begins to act bored (cries, fussy) if activity doesn’t change " },
                new Milestones { AgeGroup = 3, Milestone = "Can hold head up and begins to push up when lying on tummy" },

                /** Insert milestones for Age 3-6 months **/
                new Milestones { AgeGroup = 6, Milestone = "Smiles spontaneously, especially at people" },
                new Milestones { AgeGroup = 6, Milestone = "Likes to play with people and might cry when playing stops" },
                new Milestones { AgeGroup = 6, Milestone = "Begins to babble" },
                new Milestones { AgeGroup = 6, Milestone = "Babbles with expression and copies sounds he hears" },
                new Milestones { AgeGroup = 6, Milestone = "Reaches for toy with one hand" },
                new Milestones { AgeGroup = 6, Milestone = "Follows moving things with eyes from side to side" },
                new Milestones { AgeGroup = 6, Milestone = "Can hold a toy and shake it and swing at dangling toys" },
                new Milestones { AgeGroup = 6, Milestone = "Brings hands to mouth" },

                /** Insert milestones for Age 6-9 months **/
                new Milestones { AgeGroup = 9, Milestone = "Responds to other people’s emotions and often seems happy " },
                new Milestones { AgeGroup = 9, Milestone = "Likes to look at self in a mirror" },
                new Milestones { AgeGroup = 9, Milestone = "Responds to sounds by making sounds" },
                new Milestones { AgeGroup = 9, Milestone = "Strings vowels together when babbling (“ah,” “eh,” “oh”) and likes taking turns with parent while making sounds" },
                new Milestones { AgeGroup = 9, Milestone = "Understands “no”" },
                new Milestones { AgeGroup = 9, Milestone = "Makes a lot of different sounds like “mamamama” and “bababababa”" },
                new Milestones { AgeGroup = 9, Milestone = "Uses fingers to point at things" },
                new Milestones { AgeGroup = 9, Milestone = "Plays peek-a-boo" },

                /** Insert milestones for Age 9-12 months **/
                new Milestones { AgeGroup = 12, Milestone = "Stands, holding on" },
                new Milestones { AgeGroup = 12, Milestone = "Sits without support" },
                new Milestones { AgeGroup = 12, Milestone = "Copies sounds and gestures of others" },
                new Milestones { AgeGroup = 12, Milestone = "Responds to simple spoken requests" },
                new Milestones { AgeGroup = 12, Milestone = "Uses simple gestures, like shaking head “no” or waving “bye-bye”" },
                new Milestones { AgeGroup = 12, Milestone = "Says “mama” and “dada” and exclamations like “uh-oh!”" },
                new Milestones { AgeGroup = 12, Milestone = "Follows simple directions like “pick up the toy”" },
                new Milestones { AgeGroup = 12, Milestone = "Finds hidden things easily" },

                /** Insert milestones for Age 12-18 months **/
                new Milestones { AgeGroup = 18, Milestone = "Pulls up to stand, walks holding on to furniture (“cruising”)" },
                new Milestones { AgeGroup = 18, Milestone = "May stand alone" },
                new Milestones { AgeGroup = 18, Milestone = "Starts to use things correctly; for example, drinks from a cup, brushes hair" },
                new Milestones { AgeGroup = 18, Milestone = "Copies gestures" },
                new Milestones { AgeGroup = 18, Milestone = "Likes to hand things to others as play" },
                new Milestones { AgeGroup = 18, Milestone = "Plays simple pretend, such as feeding a doll" },
                new Milestones { AgeGroup = 18, Milestone = "Says several single words" },
                new Milestones { AgeGroup = 18, Milestone = "Says and shakes head “no”" },

                /** Insert milestones for Age 18-24 months **/
                new Milestones { AgeGroup = 24, Milestone = "Knows what ordinary things are for; for example, telephone, brush, spoon" },
                new Milestones { AgeGroup = 24, Milestone = "Shows interest in a doll or stuffed animal by pretending to feed " },
                new Milestones { AgeGroup = 24, Milestone = "Points to one body part" },
                new Milestones { AgeGroup = 24, Milestone = "Walks alone" },
                new Milestones { AgeGroup = 24, Milestone = "Pulls toys while walking" },
                new Milestones { AgeGroup = 24, Milestone = "Says sentences with 2 to 4 words" },
                new Milestones { AgeGroup = 24, Milestone = "Repeats words overheard in conversation " },
                new Milestones { AgeGroup = 24, Milestone = "Builds towers of 4 or more blocks" }
            };

            return milestones;
        }
    }
}