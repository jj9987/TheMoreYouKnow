using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TheMoreYouKnow
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadFile();
        }
        public class Question
        {
            public string text { get; set; }
            public string answer1 { get; set; }
            public string answer2 { get; set; }
            public string answer3 { get; set; }
            public string answer4 { get; set; }

            public Question(string v1, string v2, string v3, string v4, string v5)
            {
                text = v1;
                answer1 = v2;
                answer2 = v3;
                answer3 = v4;
                answer4 = v5;
            }
            public static object GetPropValue(object src, string propName)
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }

        }

        public List<Question> allquestions = new List<Question>();

        public void LoadFile()
        {
            string[] lines = System.IO.File.ReadAllLines("data.txt");

            for (int i = 0; i < 44; i++)
            {
                string[] tokens = lines[i].Split(';');
                string questinn = "question" + i.ToString();
                allquestions.Add(new Question(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]));
            }
        }

        public string correctanswer = "";

        private static Random rng = new Random();

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void NewQuestion(List<Question> allquestions)
        {
            b_answer.Visibility = Visibility.Collapsed;
            Random random = new Random();
            int randomNumber = random.Next(0, 44);
            var kusimus = allquestions[randomNumber];
            correctanswer = kusimus.answer1;

            List<string> answers = new List<string>();
            answers.Add(kusimus.answer1);
            answers.Add(kusimus.answer2);
            answers.Add(kusimus.answer3);
            answers.Add(kusimus.answer4);

            Shuffle(answers);

            b_A.Content = answers[1];
            b_B.Content = answers[3];
            b_C.Content = answers[0];
            b_D.Content = answers[2];

            b_q.Text = kusimus.text;
            b_q.Visibility = Visibility.Visible;
            b_A.Visibility = Visibility.Visible;
            b_B.Visibility = Visibility.Visible;
            b_C.Visibility = Visibility.Visible;
            b_D.Visibility = Visibility.Visible;
            //image.Source = new BitmapImage(new Uri(base.BaseUri, @"/eva.jpg"));
        }
        public void b_newgame_Click(object sender, RoutedEventArgs e)
        {
            NewQuestion(allquestions);
        }
        private void b_A_Click(object sender, RoutedEventArgs e)
        {
            if (String.Equals(b_A.Content.ToString(), correctanswer, StringComparison.Ordinal))
            {
                RightAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
        private void b_B_Click(object sender, RoutedEventArgs e)
        {
            if (String.Equals(b_B.Content.ToString(), correctanswer, StringComparison.Ordinal))
            {
                RightAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
        private void b_C_Click(object sender, RoutedEventArgs e)
        {
            if (String.Equals(b_C.Content.ToString(), correctanswer, StringComparison.Ordinal))
            {
                RightAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
        private void b_D_Click(object sender, RoutedEventArgs e)
        {
            if (String.Equals(b_D.Content.ToString(), correctanswer, StringComparison.Ordinal))
            {
                RightAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
        private void RightAnswer()
        {
            b_A.Visibility = Visibility.Collapsed;
            b_B.Visibility = Visibility.Collapsed;
            b_C.Visibility = Visibility.Collapsed;
            b_D.Visibility = Visibility.Collapsed;
            b_answer.Text = "RIGHT!";
            b_answer.Visibility = Visibility.Visible;
        }
        private void WrongAnswer()
        {
            b_A.Visibility = Visibility.Collapsed;
            b_B.Visibility = Visibility.Collapsed;
            b_C.Visibility = Visibility.Collapsed;
            b_D.Visibility = Visibility.Collapsed;
            b_answer.Text = "WRONG! Correct answer was" + correctanswer;
            b_answer.Visibility = Visibility.Visible;
        }
        private void b_SEX_Click(object sender, RoutedEventArgs e)
        {
            b_SEX.Visibility = Visibility.Collapsed;
            b_title.Visibility = Visibility.Collapsed;
            b_score.Visibility = Visibility.Visible;
            b_newgame.Visibility = Visibility.Visible;
            Instructions.Visibility = Visibility.Collapsed;
            //b_scoreboard.Visibility = Visibility.Visible;
            NewQuestion(allquestions);

        }
    }
}
