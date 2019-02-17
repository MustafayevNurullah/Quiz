using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Path;
        List<int> Ansvercounter = new List<int>();
        List<string> Asci = new List<string>() {
"A", 
"B",
"C",
"D",
"E",
"F",
"G",
"H",
"I",
"J",
"K",
"L",
"M",
"N",
"O",
"P",
"Q",
"R",
"S",
"T",
"U",
"V",
"W",
"X",
"Y",
"Z" };
        List<QuestionBlock> questionBlock=new List<QuestionBlock>();
        List<QuestionBlock> questionBlocks = new List<QuestionBlock>();
        List<Class1Q> questionBlocks_ = new List<Class1Q>();
        List<int> vsQuestion = new List<int>();
        List<int> vsAnswer = new List<int>();
        List<int> RandomQuestion = new List<int>();
        List<int> RandomAnswer = new List<int>();
        int createQuestionCounter = -1;
        int a = 0;
        int correct=0;
        int wrong=0;
        int null_=0;
        int AsciCounter=0;
        int counter ;
        Point point = new Point();
        List<string> List = new List<string>();
        int radiobuttonconter = 0;
        void ReadList()
        {
            if (createQuestionCounter == questionBlock.Count)
            {
                QuestionBlock questionBloc = new QuestionBlock();
                questionBloc.id = questionBlock.Count;
                questionBloc.Text = WriteTextBox("Test");
                questionBloc.Answers = new List<Answer>();
                // MessageBox.Show("as"+AsciCounter.ToString());
                for (int i = 0; i < AsciCounter; i++)
                {
                    Answer answer = new Answer();
                    answer.id = i;
                    answer.Text = WriteTextBoxAnswer($"{i}");
                    questionBloc.Answers.Add(answer);
                }
                questionBlock.Add(questionBloc);
            }
            else
            {
                questionBlock[createQuestionCounter].id = createQuestionCounter;
                questionBlock[createQuestionCounter].Text = WriteTextBox("Test");
                for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                {
                    questionBlock[createQuestionCounter].Answers[i].id = i;
                    questionBlock[createQuestionCounter ].Answers[i].Text = WriteTextBoxAnswer($"{i}");
                   // MessageBox.Show(questionBlock[createQuestionCounter].Answers[i].Text);
                }
                //if(questionBlock[createQuestionCounter].Answers.Count<AsciCounter)
                //{
                //    QuestionBlock questionBloc = new QuestionBlock();
                //    questionBloc.id = questionBlock.Count;
                //    questionBloc.Text = WriteTextBox("Test");
                //    questionBloc.Answers = new List<Answer>();
                //    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count-AsciCounter; i++)
                //    {
                //        Answer answer = new Answer();
                //        answer.id = i;
                //        answer.Text = WriteTextBoxAnswer($"{i}");
                //        questionBloc.Answers.Add(answer);
                //    }
                //    questionBlock.Add(questionBloc);
                //}
                //if (questionBlock[createQuestionCounter].Answers.Count > AsciCounter)
                //{
                    
                //    for (int i = AsciCounter-1; i < questionBlock[createQuestionCounter].Answers.Count - AsciCounter; i++)
                //    {
                //        questionBlock[createQuestionCounter - 1].Answers.Remove(questionBlock[createQuestionCounter].Answers[i]);

                //    }
                //}
            }
            foreach (var item in questionBlock[0].Answers)
            {
               // MessageBox.Show(item.Text);
            }

        }
        string WriteTextBox(string number)
        {
            for (int i = 0; i < Controls.Count*6; i++)
            {
                foreach (var item in Controls)
                {
                    if(item is TextBox textBox )
                    {
                      if(textBox.Name==number)
                        {
                            return textBox.Text;
                        }

                    }
                }
            }
                return string.Empty;
           
        }
        string WriteTextBoxAnswer(string number)
        {
                        //MessageBox.Show("Number"+number);
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox textBox)
                    {
                       // MessageBox.Show("Texbox NAme"+textBox.Name);
                        if (textBox.Name == number && textBox.Location.Y>70)
                        {
                            return textBox.Text;
                        }

                    }
                }
            }
            return string.Empty;

        }
        #region CreateControls

        void PictureBox(string text)
        {
            PictureBox radioButton = new PictureBox();
            radioButton.Size = new Size(20, 20);
            radioButton.Location = new Point(180, point.Y - 13);
            radioButton.Name = Name;
            if(text=="Yes")
            {
                radioButton.Image = Image.FromFile("Correct.png");
            }
            if (text == "No")
            {
                radioButton.Image = Image.FromFile("Wrong.png");
            }
            if(text=="")
            {
                radioButton.Location = new Point(180, point.Y - 30);

                radioButton.Image = Image.FromFile("Answer.png");

            }

            this.Controls.Add(radioButton);
            radioButton.Click += RadioButton_Click;
        }
        void ResetRadiButton()
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton label)
                    {
                        //  MessageBox.Show(AsciCounter.ToString());
                        if (label.Name == AsciCounter.ToString())
                        {
                            label.Dispose();
                          //  AsciCounter--;
                        }
                    }

                }
            }

        }
        void ResetAnswerTextBox()
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox label)
                    {

                          //MessageBox.Show(AsciCounter.ToString());
                          if(point.Y==36)
                        {
                            label.Dispose();
                        }
                        if (  label.Location.Y>100 &&label.Name == AsciCounter.ToString())
                        {
                            label.Dispose();
                            ResetRadiButton();
                            //AsciCounter--;
                        }
                    }
                   
                }
            }

        }
        void ResetForm()
        {
            AsciCounter = 0;
            for (int i = 0; i < Controls.Count*10; i++)
            {
                foreach (var item in Controls)
                {
                    if(item is ListView listView)
                    {
                        listView.Dispose();
                    }
                    if(item is TextBox label)
                    {
                        label.Dispose();
                    }
                    if (item is Button button)
                    {
                        button.Dispose();
                    }
                    if (item is RadioButton radioButton)
                    {
                        radioButton.Dispose();
                    }
                }
            }
        }
        void CreateTextLabel(string Text,string Name,bool bool_)
        {
            TextBox label = new TextBox();
            label.Size = new Size(571, 81);
            label.Location = new Point(197,point.Y);
            label.Name = "Test";
            label.Enabled = bool_;
            label.Text =counter+1+Text;
            this.Controls.Add(label);
        }
       
        void CreateAnswerLabel(string Text,bool bool_)
        {
            TextBox label = new TextBox();
            label.Size = new Size(464, 44);
            label.Location = new Point(200, point.Y);
             //  MessageBox.Show(AsciCounter.ToString());
            label.Enabled = bool_;

            label.Name = AsciCounter.ToString();
            label.Text =Asci[AsciCounter]+". "+ Text;
            this.Controls.Add(label);
        }
        void createButton(string Text,bool  enable)
        {
            Button button = new Button();
            button.Size = new Size(75,23);
            button.Location = new Point(point.X, point.Y);
            button.Text = Text;
            button.Enabled = enable;
            this.Controls.Add(button);
            button.Click += Button_Click;            

        }
        void createRadioButton(string Name)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Size = new Size(15,15);
            radioButton.Location = new Point(180,point.Y-13);
            radioButton.Name = Name;
            this.Controls.Add(radioButton);
            radioButton.Click += RadioButton_Click;
        }
        void createTextBoxSum(string Text)
        {
            TextBox label = new TextBox();
            label.Size = new Size(464, 44);
            label.Location = new Point(200, point.Y);
            label.Text =  Text;
            this.Controls.Add(label);
        }
        #endregion Create
        #region ControlsClick
        void ButonEnableTrue()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button Button)
                    {
                       if (Button.Text == "Remove")
                        {
                            Button.Enabled = true;
                        }
                       if(counter>1  &&   Button.Text=="Save")
                        {
                            Button.Enabled = true;
                        }
                       if( point.Y==36 &&Button.Text=="Add")
                        {
                            Button.Enabled = true;
                        }
                    }
                }
            }
        }
        void  ButtonEnable()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button Button)
                    {
                        if(Button.Text!="Accept" || Button.Text!="Sub" )
                        {
                            if(Button.Text!="Add")
                        Button.Enabled = false;

                        }
                        if(Button.Text=="Remove" )
                        {
                            Button.Enabled = false;
                        }
                      

                    }
                }
            }
        }
        bool  AcceptButton()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button button)
                    {
                        if (button.Text == "Accept")
                        {
                            return button.Enabled;
                        }
                    }
                }
            }
            return false;

        }
        string ControlRadioButton()
        {
            for (int i = 0; i < Controls.Count*5; i++)
            {
                foreach (var item in Controls)
                {
                    if(item is RadioButton radioButton)
                    {
                        if(radioButton.Checked==true)
                        {
                            return radioButton.Name;
                        }
                    }
                }
            }
            return string.Empty;
        }
        bool ControlButton(string Text)
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button radioButton)
                    {
                        if (radioButton.Text == Text )
                        {
                            return true;
                        }
                    }
                }

            }
            return false;

        }
        void RadioButtonEnable()
        {
            for (int i = 0; i < Controls.Count*5; i++)
            {
                foreach (var item in Controls)
                {
                    if(item is RadioButton radioButton)
                    {
                        radioButton.Enabled = false;
                    }
                }
            }
        }
        private void RadioButton_Click(object sender, EventArgs e)
        {
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button.Text=="AddPage")
            {

                if(createQuestionCounter!=-1)
                ReadList();

                AsciCounter = 0;

                ResetForm();
                point.Y = 36;
                CreateTextLabel(string.Empty,string.Empty,true);
                point.X = 803;

                point.Y = 297;
                createButton("Add", true);
                point.Y = 197;
                createButton("Remove", false);
                point.Y = 97;
                createButton("AddPage", true);
                point.X = 36;
                point.Y = 36;
                createButton("Save", false);
                point.Y = 477;
                point.X = 200;
                if (createQuestionCounter==-1 )
                {
                    createButton("Next", false);
                    point.X = 100;
                    createButton("Back", false);

                }
                if (questionBlock.Count != 0 && createQuestionCounter==0 )
                {
                    createButton("Next", false);
                    point.X = 100;
                    createButton("Back", true);

                }
                if (questionBlock.Count>=createQuestionCounter && createQuestionCounter>0)
                {
                    createButton("Next", true);
                    point.X = 100;
                    createButton("Back", true);
                }
                createQuestionCounter++;
                counter++;
                ButonEnableTrue();


            }
            if (button.Text=="Sum")
            {
                ResetForm();
                point.Y = 197;
                PictureBox("Yes");
                createTextBoxSum(correct.ToString());
                point.Y += 70;
                PictureBox("No");
                createTextBoxSum(wrong.ToString());
                point.Y += 70;
                PictureBox("");
                createTextBoxSum(questionBlocks.Count.ToString());
            }
            if (button.Text == "Remove")
            {

                if (point.Y ==36)
                {
                    ResetAnswerTextBox();
                        ButtonEnable();

                }
                else
                {


                    AsciCounter--;
                    ResetAnswerTextBox();
                    if (AsciCounter == 0)
                    {
                        ButtonEnable();
                    }
                    counter--;
                }
                    point.Y -= 70;
            }
            if (button.Text=="Save")
            {
                ReadList();
                string json = JsonConvert.SerializeObject(questionBlock);
                System.IO.File.WriteAllText($"xxmmmlll{counter++}.xml", json);
            }
            if(button.Text=="Quiz")
            {
                ResetForm();
                ListView listView = new ListView();
                listView.Size = new Size(422, 294);
                listView.Location = new Point(277, 76);
                listView.SelectedIndexChanged += ListView_SelectedIndexChanged;
                listView.Items.Add("QuestionsXML");
                this.Controls.Add(listView);
            }
            if (button.Text == "Add")
            {
                if (AsciCounter==0)
                    point.Y = 197;
                if(point.Y>110)
                {
                    ButonEnableTrue();
                }
                if(point.Y>40)
                {



                    CreateAnswerLabel(string.Empty,true);
                    createRadioButton(radiobuttonconter.ToString());
                    AsciCounter++;
                    radiobuttonconter++;
                    ButonEnableTrue();
                }
                    point.Y += 70;


            }
            if (button.Text== "Create Test")
            {
                ResetForm();
                point.X = 803;

              
                point.Y = 97;
                createButton("AddPage", true);
               

            }
            if (button.Text=="Next")
            {
                if (ControlButton("Remove"))
                {
                    ReadList();
                    counter ++;
                    createQuestionCounter++;
                    ResetForm();
                    point.Y = 36;
                    CreateTextLabel(questionBlock[createQuestionCounter].Text, string.Empty, true);
                AsciCounter = 0;
                    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                    {
                        point.Y += 70;
                        CreateAnswerLabel(questionBlock[createQuestionCounter].Answers[i].Text, true);
                    }
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    createButton("Remove", false);
                    point.Y = 97;
                    createButton("AddPage", true);
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", false);
                    point.Y = 477;
                    if (createQuestionCounter ==questionBlock.Count )
                    {
                        point.X = 200;
                        createButton("Next", false);
                        point.X = 100;
                        createButton("Back", true);
                    }
                    else
                    {
                        point.X = 200;
                        createButton("Next", true);
                        point.X = 100;
                        createButton("Back", true);
                    }
                }


                if(!AcceptButton() && !ControlButton("Remove"))
                {
                   
                    vsQuestion.Add(questionBlocks[counter].id);
                    vsAnswer.Add(Convert.ToInt32(ControlRadioButton()));
                   questionBlocks.Remove(questionBlocks[counter]);
                    counter--;
                ResetForm();
                FormLoad("Next");
                }
                bool a = false;
               if(ControlButton("Add"))
                {
                    a = true;
                }
                if(a)
                { 
                   // ResetForm();
                
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", true);
                }
            }
            if (button.Text == "Back")
            {



                if (ControlButton("Remove"))
                {
                    ReadList();
                    if (counter == 2)
                    {
                        counter -= 2;
                    }
                    else
                    {
                        counter--;
                    }
                    createQuestionCounter--;
                    ResetForm();
                    point.Y = 36;
                        
                    CreateTextLabel(questionBlock[createQuestionCounter].Text, string.Empty, true);
                AsciCounter = 0;
                    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                    {
                        point.Y += 70;
                        CreateAnswerLabel(questionBlock[createQuestionCounter].Answers[i].Text, true);
                    }
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    createButton("Remove", false);
                    point.Y = 97;
                    createButton("AddPage", true);
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", false);
                    point.Y = 477;
                    if (createQuestionCounter == 0)
                    {
                        point.X = 200;
                        createButton("Next", true);
                        point.X = 100;
                        createButton("Back", false);
                    }
                }


                if (!AcceptButton()  && !ControlButton("Remove"))
                {
                    vsQuestion.Add(questionBlocks[counter].id);
                    vsAnswer.Add(Convert.ToInt32(ControlRadioButton()));
                    questionBlocks.Remove(questionBlocks[counter]);
                   // Ansvercounter.Remove(counter);

                ResetForm();
                FormLoad("Back");
                }
                //bool a = false;
                //if (ControlButton("Add"))
                //{
                //    a = true;
                //}
                //if (a)
                //{
                //    point.X = 803;
                //    point.Y = 297;
                //    createButton("Add", true);
                //    point.Y = 197;
                //    point.X = 36;
                //    point.Y = 36;
                //    createButton("Save", true);
                //}
            }
            if (button.Text == "Accept")
            {
                
                    for (int i = 0; i < Controls.Count * 5; i++)
                    {
                        foreach (var item in Controls)
                        {
                            if (item is RadioButton radioButton)
                            {
                                if (radioButton.Checked == true)
                                {
                                    button.Enabled = false;
                                RadioButtonEnable();
                                if(questionBlocks.Count==1)
                                {
                                    vsQuestion.Add(questionBlocks[counter].id);
                                    vsAnswer.Add(Convert.ToInt32(ControlRadioButton()));
                                    questionBlocks.Remove(questionBlocks[counter]);

                                }


                            }
                        }
                        }
                    }

            }
            if(button.Text=="Sub")
            {

                null_ = questionBlocks_.Count - questionBlocks.Count;
                ResetForm();
                point.Y = 97;
                counter = 0;
                AsciCounter = 0;
                for (int i = 0; i < questionBlocks_.Count; i++)
                {
                    CreateTextLabel(questionBlocks_[i].Text,counter.ToString(),false);
                    point.Y +=100;
                    for (int j = 0; j < questionBlocks_[i].Answers.Count; j++)
                    {
                        for (int q = 0; q < vsQuestion.Count; q++)
                        {
                            if (vsQuestion[q] == questionBlocks_[i].id)
                            {
                                if (vsAnswer[q] == questionBlocks_[i].Answers[j].id)
                                {
                                    if (questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                    {
                                        PictureBox("Yes");
                                        correct++;
                                        PictureBox("");
                                    }
                                    else
                                    {
                                        PictureBox("");

                                        PictureBox("No");
                                        wrong++;
                                        for (int t = 0; t < questionBlocks_[i].Answers.Count; t++)
                                        {
                                            if(questionBlocks_[i].Answers[t].IsCorrect=="Yes")
                                            {
                                                PictureBox("Yes");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if(questionBlocks_[i].Answers[j].IsCorrect=="Yes")
                                {
                                    PictureBox("Yes");
                                }
                            }
                          
                        }
                        if(questionBlocks_.Count==questionBlocks.Count)
                        {
                            for (int q = 0; q < questionBlocks.Count; q++)
                            {
                                for (int r = 0; r < questionBlock[q].Answers.Count; r++)
                                {
                                    if (questionBlocks_[i].Answers[j].IsCorrect == "Yes")
                                    {
                                        PictureBox("Yes");
                                    }
                                }
                            }
                        }
                        CreateAnswerLabel(questionBlocks_[i].Answers[j].Text,false);
                        AsciCounter++;
                        point.Y += 70;
                        
                    }
                    counter++;
                    AsciCounter = 0;
                }
                createButton("Sum", true);
            }

        }
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(File.Exists($"C:\\Users\\User\\Desktop\\QuestionsXML.xml"))
            {
                Path =$"C:\\Users\\User\\Desktop\\QuestionsXML.xml";
                ResetForm();
                FormLoad("");
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }
        #endregion ControlsClick
        void FormLoad(string Text)
        {
            if (a == 0)
            {

                //QuestionBlock questionBloc = new QuestionBlock();
                //questionBloc.id = 100;
                //questionBloc.Text = "Salam Kele";
                //questionBloc.Answers = new List<Answer>();
                //Answer answer = new Answer();
                //answer.id = 101;
                //answer.IsCorrect = "Kele";
                //answer.Text = "Civi";
                //questionBloc.Answers.Add(answer);
                //questionBlock.Add(questionBloc);

                StreamReader streamReader = new StreamReader(Path);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestionBlock>));
                var obj = (List<QuestionBlock>)xmlSerializer.Deserialize(streamReader);
                a++;
                questionBlock=obj;
                
                questionBlocks = obj;
                do
                {
                    bool q = false;
                    Random random = new Random();
                    counter = random.Next(0, questionBlocks.Count);
                    foreach (var item in RandomQuestion)
                    {
                        if(item==counter)
                        {
                            q = true;
                        }
                    }
                    if(!q)
                    {
                        Class1Q class1Q = new Class1Q();
                        class1Q.Answers = new List<Class1A>();
                        class1Q.id = questionBlock[counter].id;
                        class1Q.Text = questionBlock[counter].Text;
                        RandomQuestion.Add(counter);
                        do
                        {
                            bool qw = false;
                            Class1A class1A = new Class1A();
                            int answercounter;
                            answercounter = random.Next(0, questionBlocks[counter].Answers.Count);
                            foreach (var item in RandomAnswer)
                            {
                                if (item == answercounter)
                                {
                                    qw = true;
                                }
                            }
                            if(!qw)
                            {
                                class1A.id = questionBlock[counter].Answers[answercounter].id;
                                class1A.Text = questionBlock[counter].Answers[answercounter].Text;
                                class1A.IsCorrect = questionBlock[counter].Answers[answercounter].IsCorrect;
                                class1Q.Answers.Add(class1A);
                                RandomAnswer.Add(answercounter);
                            }
                        } while (questionBlocks[counter].Answers.Count != RandomAnswer.Count);
                        RandomAnswer.Clear();
                        questionBlocks_.Add(class1Q);
                    }
                } while (questionBlocks.Count!=RandomQuestion.Count);
                ListBox listBox = new ListBox();
                listBox.Location= new Point(140, 200);
                listBox.Size = new Size(100,100);
                for (int i = 0; i < questionBlocks.Count; i++)
                {
                    questionBlocks[i].id = questionBlocks_[i].id;
                    questionBlocks[i].Text = questionBlocks_[i].Text;
                    for (int j = 0; j < questionBlocks[i].Answers.Count; j++)
                    {
                        questionBlocks[i].Answers[j].id = questionBlocks_[i].Answers[j].id;
                        questionBlocks[i].Answers[j].IsCorrect = questionBlocks_[i].Answers[j].IsCorrect;
                        questionBlocks[i].Answers[j].Text = questionBlocks_[i].Answers[j].Text;
                    }
                  
                }
                counter = 0;
            }
            switch (Text)
            {
                case "Next":
                    counter++;
                    break;
                case "Back":
                    counter--;
                    break;
                case "":
                    counter=0;
                    break;
            }
            point.Y = 97;
                CreateTextLabel(questionBlocks[counter].Text,counter.ToString(),false);
            point.Y = 197;
            foreach (var item in questionBlocks[counter].Answers)
            {
            CreateAnswerLabel(item.Text,false);
                createRadioButton(item.id.ToString());
                    AsciCounter++;
                    point.Y += 70;
            }
            point.X = 300;
            createButton("Sub", true);
            point.X = 200;
            if (counter == questionBlocks.Count-1)
            {
                createButton("Next", false);
            }
            else
            {
                createButton("Next", true);
            }
            point.X =0;
            if (counter == 0)
            {
                createButton("Back", false);
            }
            else
            {
                createButton("Back", true);
            }
            point.X = 100;
            createButton("Accept", true);
        }
        void ProgramLoad()
        {
            point.X = 142;
            point.Y = 49;
            createButton("Create Test", true);
            point.X = 442;
            createButton("Quiz", true);

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            ProgramLoad();
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var item in droppedFiles)
            {
                Path = item;
            }
            FormLoad("");
        }
    }
}