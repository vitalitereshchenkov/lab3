using Plants.plants;
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

namespace Plants
{
    public partial class Form1 : Form
    {
        List<plant> list = new List<plant>();
        Dictionary<Type, createPlants> creators;
        Dictionary<Button, Type> buttons;
        plant plant;
        Type plantType;
        List<Label> Labels;
        List<TextBox> TextBoxes;
        public bool flag = true;

        public Form1()
        {
            InitializeComponent();

            creators = new Dictionary<Type, createPlants>();
            creators[typeof(cannabis)] = new CreateCannabis();
            creators[typeof(coriander)] = new CreateCoriander();
            creators[typeof(spruce)] = new CreateSpruce();
            creators[typeof(birch)] = new CreateBirch();

            buttons = new Dictionary<Button, Type>();
            buttons[btnCannabis] = typeof(cannabis);
            buttons[btnCoriander] = typeof(coriander);
            buttons[btnSpruce] = typeof(spruce);
            buttons[btnBirch] = typeof(birch);

            btnCannabis.Click += btn_Click;
            btnBirch.Click += btn_Click;
            btnSpruce.Click += btn_Click;
            btnCoriander.Click += btn_Click;

            Labels = new List<Label>();

            Labels.Add(label1);
            Labels.Add(label2);
            Labels.Add(label3);
            Labels.Add(label4);
            Labels.Add(label5);
            Labels.Add(label6);

            TextBoxes = new List<TextBox>();

            TextBoxes.Add(textBox1);
            TextBoxes.Add(textBox2);
            TextBoxes.Add(textBox3);
            TextBoxes.Add(textBox4);
            TextBoxes.Add(textBox5);
            TextBoxes.Add(textBox6);

            HideProperties();
        }

        private void HideProperties()
        {
            foreach (var label in Labels)
                label.Visible = false;
            foreach (var textBox in TextBoxes)
                textBox.Visible = false;
        }

        private void SetPropertyNames(List<string> values)
        {
            int index = 0;
            foreach (var value in values)
            {
                Labels[index].Text = value;
                Labels[index].Visible = true;
                TextBoxes[index++].Visible = true;
            }
        }

        private void SetPropertyValues(List<string> values)
        {
            int index = 0;
            foreach (var value in values)
            {
                TextBoxes[index++].Text = value;
            }
        }

        private bool CheckEmptyTextBoxes()
        {
            bool flag = false;

            foreach (var textBox in TextBoxes)
            {
                if (textBox.Visible == true)
                {
                    if (textBox.Text != String.Empty)
                    {
                        flag = true;
                    }
                    else
                        flag = false;
                }
            }
            return flag;
        }


        private void clearValues()
        {
            foreach (var textBox in TextBoxes)
                textBox.Clear();
        }

        private List<string> GetPropertyValues()
        {
            var values = new List<string>();
            foreach (var textBox in TextBoxes)
                values.Add(textBox.Text);
            return values;
        }

        private bool checkEmptyList()
        {
            if (lbList.SelectedIndex == -1)
                return false;
            else return true;

        }

        private void btn_Click(object sender, EventArgs e)
        {
            HideProperties();
            clearValues();
            plantType = buttons[sender as Button];
            var propertyNames = creators[plantType].GetPropertyNames();
            SetPropertyNames(propertyNames);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckEmptyTextBoxes())
                {
                    var values = GetPropertyValues();
                    plant = creators[plantType].createPlant(values);
                    list.Add(plant);
                    lbList.Items.Add(plant.name);
                    clearValues();
                }
                else
                    MessageBox.Show("All fields are required!");
            }
            catch
            {
                    MessageBox.Show("Incorrect input!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            plant tmp = list[lbList.SelectedIndex];

            list.Remove(tmp);
            flag = false;
            lbList.Items.RemoveAt(lbList.SelectedIndex);
            clearValues();
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkEmptyList())
            {
                if (flag)
                {
                    HideProperties();
                    var propertyNames = creators[list[lbList.SelectedIndex].GetType()].GetPropertyNames();
                    var propertyValues = creators[list[lbList.SelectedIndex].GetType()].GetProperties(list[lbList.SelectedIndex]);
                    SetPropertyNames(propertyNames);
                    SetPropertyValues(propertyValues);
                }
                else
                {
                    flag = true;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkEmptyList())
            {
                if (CheckEmptyTextBoxes())
                {
                    var values = GetPropertyValues();
                    creators[list[lbList.SelectedIndex].GetType()].SetProperties(list[lbList.SelectedIndex], values);
                }
                else
                    MessageBox.Show("All fields are required!");

            }
        }

        private void btnSerialize_Click(object sender, EventArgs e)

        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<plant>));

            using (FileStream fs = new FileStream("plants.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, list);
                    MessageBox.Show("Serialisation is complete");
                }
                catch
                {
                    MessageBox.Show("error");
                }

            }


        }


        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<plant>));

            using (FileStream fs = new FileStream("plants.xml", FileMode.OpenOrCreate))
            {
                try
                {

                    List<plant> newList = (List<plant>)formatter.Deserialize(fs);
                    foreach (plant p in newList)
                    {
                        lbList.Items.Add(p.name);
                        list.Add(p);
                    }
                }
                catch
                {
                    MessageBox.Show("error");
                }

               
            }

        }
    }
}
