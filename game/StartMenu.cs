using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using game.Player;
using game.World_map;

namespace game
{
    /*!
     * \brief Стартовое окно игры.
     * Даёт выбор пользователю выйти из игры, загрузить сохранение или начать новую игру.
     */
    public partial class StartMenu : Form
    {
        FormGame formGame;
        public StartMenu()
        {
            InitializeComponent();
        }

        private void buttonsMouseMove(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            if (but == startButton)
            {
                but.BackgroundImage = Properties.Resources.start_active;
            }
            else if (but == exitButton)
            {
                but.BackgroundImage = Properties.Resources.exit_active;
            }
            else if (but == loadButton)
            {
                but.BackgroundImage = Properties.Resources.Load_Move;
            }
        }

        private void buttonsMouseLeave(object sender, EventArgs e)
        {
            var but = sender as Button;
            if (but == startButton)
            {
                but.BackgroundImage = Properties.Resources.start_no_active;
            }
            else if (but == exitButton)
            {
                but.BackgroundImage = Properties.Resources.exit_no_active;
            }
            else if (but == loadButton)
            {
                but.BackgroundImage = Properties.Resources.Load_No_Move;
            }
        }

        private void buttonsMouseDown(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            if(but == startButton)
            {
                but.BackgroundImage = Properties.Resources.start_Down;
            }
            else if (but == exitButton)
            {
                but.BackgroundImage = Properties.Resources.exit_Down;
            }
            else if (but == loadButton)
            {
                but.BackgroundImage = Properties.Resources.Load_Click;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Map.GenerateMap();
            formGame = new FormGame(this);
            formGame.Show();
            this.Hide();
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static ICollection<T> DeserializeList<T>(FileStream fs)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<T> list = new List<T>();
            while (fs.Position != fs.Length)
            {
                //deserialize each object in the file
                var deserialized = (T)bf.Deserialize(fs);
                //add individual object to a list
                list.Add(deserialized);
            }
            //return the list of objects
            return list;
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.UserProfile;
            folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory.ToString() + "\\saves\\";
                
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;

                var fileStream = File.Open(path + "\\Chunks.sav", FileMode.Open);
                Map.LoadChunks(DeserializeList<Chunk>(fileStream).ToList());

                fileStream.Close();

                fileStream = File.Open(path + "\\Buildings.sav", FileMode.Open);
                Building.LoadBuildings(DeserializeList<Building>(fileStream).ToList());

                fileStream.Close();

                var playerObj = ReadFromBinaryFile<Player.Player>(path + "\\Player.sav");
                new Player.Player().loadResourecesDict(playerObj.GetPlayerResourcesDict());

                formGame = new FormGame(this, playerObj);
                formGame.Show();
                this.Hide();
            }
        }
    }
}
