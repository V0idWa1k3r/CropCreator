using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CropCreator
{
    public partial class CropCreator : Form
    {
        public static Random Rand { get; } = new Random();

        public CropCreator()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string text = "N/A";
            float f;
            if (float.TryParse(this.textBox6.Text, out f))
            {
                float days = 90 / f;
                text = string.Format("{0,1:N2} days", days);
            }

            this.label9.Text = "Will take : " + text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox9.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
            this.textBox10.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
            this.textBox11.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
            this.textBox12.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
            this.textBox13.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
            this.textBox14.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
            this.textBox15.Text = string.Format("{0,7:N5}", this.GetNutrientRandomValue());
        }

        public float GetNutrientRandomValue()
        {
            return (float)Rand.NextDouble() / 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (BiomeSelectionInfo dial = new BiomeSelectionInfo())
            {
                dial.ShowDialog();
                if (dial.OkPressed)
                {
                    this.listBox1.Items.Add(dial.Result);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count > 0)
            {
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CropData data = new CropData();
            try
            {
                data.Crop = this.textBox1.Text;
                data.MinimalTemperature = FloatRange.FromString(this.textBox2.Text);
                data.OptimalTemperature = FloatRange.FromString(this.textBox3.Text);
                data.PerfectTemperature = FloatRange.FromString(this.textBox4.Text);
                data.HumidityRange = FloatRange.FromString(this.textBox5.Text);
                data.GrowthStages = int.Parse((string)this.comboBox1.SelectedItem);
                data.GrowthRate = float.Parse(this.textBox6.Text);
                data.BaseHealth = float.Parse(this.textBox7.Text);
                data.Bug = string.IsNullOrEmpty(this.textBox8.Text) ? "none" : this.textBox8.Text;
                string[] foundIn = new string[this.listBox1.Items.Count];
                for (int i = 0; i < foundIn.Length; ++i)
                {
                    foundIn[i] = (string)this.listBox1.Items[i];
                }

                data.FoundIn = foundIn;
                data.HarvestSeason = this.GetHarvestSeasons();
                data.HarvestAction = this.comboBox3.Text;
                data.NutrientConsumption["NITROGEN"] = float.Parse(this.textBox9.Text);
                data.NutrientConsumption["PHOSPHORUS"] = float.Parse(this.textBox10.Text);
                data.NutrientConsumption["POTASSIUM"] = float.Parse(this.textBox11.Text);
                data.NutrientConsumption["CALCIUM"] = float.Parse(this.textBox12.Text);
                data.NutrientConsumption["SULPHUR"] = float.Parse(this.textBox13.Text);
                data.NutrientConsumption["MAGNESIUM"] = float.Parse(this.textBox14.Text);
                data.NutrientConsumption["MICRONUTRIENTS"] = float.Parse(this.textBox15.Text);
                data.WaterConsumption = float.Parse(this.textBox16.Text);
                string path = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + this.textBox1.Text + ".json";
                File.WriteAllText(path, JsonConvert.SerializeObject(data));
                MessageBox.Show("Saved crop data as " + path, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Entered values are invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string[] GetHarvestSeasons()
        {
            string currentItem = (string)this.comboBox2.SelectedItem;
            if (currentItem.Equals("SPRING") || currentItem.Equals("SUMMER") || currentItem.Equals("AUTUMN") || currentItem.Equals("WINTER"))
            {
                return new string[] { currentItem };
            }

            if (currentItem.Equals("SP+SU"))
            {
                return new string[] { "SPRING", "SUMMER" };
            }

            if (currentItem.Equals("SP+AU"))
            {
                return new string[] { "SPRING", "AUTUMN" };
            }

            if (currentItem.Equals("SP+WI"))
            {
                return new string[] { "SPRING", "WINTER" };
            }

            if (currentItem.Equals("SU+AU"))
            {
                return new string[] { "SUMMER", "AUTUMN" };
            }

            if (currentItem.Equals("SU+WI"))
            {
                return new string[] { "SUMMER", "WINTER" };
            }

            if (currentItem.Equals("AU+WI"))
            {
                return new string[] { "AUTUMN", "WINTER" };
            }

            if (currentItem.Equals("SP+SU+AU"))
            {
                return new string[] { "SPRING", "SUMMER", "AUTUMN" };
            }

            if (currentItem.Equals("SP+SU+WI"))
            {
                return new string[] { "SPRING", "SUMMER", "WINTER" };
            }

            if (currentItem.Equals("SP+AU+WI"))
            {
                return new string[] { "SPRING", "AUTUMN", "WINTER" };
            }

            if (currentItem.Equals("SP+SU+AU"))
            {
                return new string[] { "SPRING", "SUMMER", "AUTUMN" };
            }

            if (currentItem.Equals("SU+AU+WI"))
            {
                return new string[] { "SUMMER", "AUTUMN", "WINTER" };
            }

            return new string[] { "SPRING", "SUMMER", "AUTUMN", "WINTER" };
        }
    }
}
