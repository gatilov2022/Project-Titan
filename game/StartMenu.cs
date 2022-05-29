using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using game.Player;
using game.World_map;

namespace game
{
    public partial class StartMenu : Form
    {
        Form1 form1;
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            _ = but == button1 ? but.BackgroundImage = Properties.Resources.start_active : but.BackgroundImage = Properties.Resources.exit_active;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            var but = sender as Button;
            _ = but == button1 ? but.BackgroundImage = Properties.Resources.start_no_active : but.BackgroundImage = Properties.Resources.exit_no_active;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            var but = sender as Button;
            _ = but == button1 ? but.BackgroundImage = Properties.Resources.start_Down : but.BackgroundImage = Properties.Resources.exit_Down;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Map.GenerateMap();
            form1 = new Form1(this);
            form1.Show();
            this.Hide();
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {

                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
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
        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.UserProfile;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;

                var fileStream = File.Open( path + "\\Chunks.sav", FileMode.Open);

                var chunksList = DeserializeList<Chunk>(fileStream);
                Map.LoadChunks(chunksList.ToList());
                fileStream.Close();

                fileStream = File.Open(path + "\\Buildings.sav", FileMode.Open);
                var buildingsList = DeserializeList<Building>(fileStream);
                Building.LoadBuildings(buildingsList.ToList());

                fileStream.Close();

                var playerObj = ReadFromBinaryFile<Player.Player>(path + "\\Player.sav");

                var newPlayer = new Player.Player();

                newPlayer.loadResourecesDict(playerObj.GetPlayerResourcesDict());
                newPlayer.loadWarehouseDict(playerObj.GetWarehouseDict());

                form1 = new Form1(this, playerObj);
                form1.Show();
                this.Hide();
            }
        }
    }
}
