using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CaseStudyFLAMES
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AboutButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("About Me", "Aleeza China Ulang (BS-IS) from MOBDEVT OTI003. Source code reference from CodePlex Archive.", "Return");
        }

        private void FlamesButton_Clicked(object sender, EventArgs e)
        {
            string outcome = Name.Text.ToUpper();
            string outcome2 = Partner.Text.ToUpper();
            int placement = 0;
            int flamestick = 0;
            int charcount;

            if (outcome == "" || outcome2 == "") //error handling if no input
            {
                this.Result.Text = "Enter a valid name.";
            }
            else if (outcome == outcome2) //error handling if input is same
            {
                this.Result.Text = "Make sure to enter two different names!";
            }
            else if (!((outcome == "" || outcome2 == "") && (outcome == outcome2)))
            {
                List<char> namelist = new List<char>();
                List<char> namelist2 = new List<char>();
                List<char> play = new List<char>() { 'F', 'L', 'A', 'M', 'E', 'S' };

                namelist.AddRange(outcome.ToCharArray());
                namelist2.AddRange(outcome2.ToCharArray());

                foreach (char item in namelist.ToList()) //remove duplicates
                {
                    foreach (char item2 in namelist2.ToList())
                    {
                        if (item == item2)
                        {
                            namelist.Remove(item);
                            namelist2.Remove(item2);
                            break;
                        }
                    }
                }

                charcount = namelist.Count() + namelist2.Count();

                while (play.Count() != 1)
                {
                    flamestick++; //rev
                    if (flamestick == charcount)
                    {
                        play.RemoveAt(placement);
                        flamestick = 0; //r
                        placement = placement - 1; //w
                    }

                    if (placement == (play.Count() - 1))
                    {
                        placement = 0; //l
                    }
                    else
                    {
                        placement++;
                    }
                }

                switch (play[0].ToString())
                {
                    case "F":
                        this.Result.Text = "FRIENDSHIP";
                        break;
                    case "L":
                        this.Result.Text = "LOVE";
                        break;
                    case "A":
                        this.Result.Text = "AFFECTION";
                        break;
                    case "M":
                        this.Result.Text = "MARRIAGE";
                        break;
                    case "E":
                        this.Result.Text = "ENEMY";
                        break;
                    case "S":
                        this.Result.Text = "SIBLING";
                        break;

                    default:

                        break;
                }

                this.FinalResult.Text = charcount.ToString(); //count result
            }
        }
    }
}
