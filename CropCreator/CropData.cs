using System.Collections.Generic;

namespace CropCreator
{
    public class FloatRange
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "min")]
        public float Min { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "max")]
        public float Max { get; set; }

        public FloatRange(float f, float f1)
        {
            this.Min = f;
            this.Max = f1;
        }

        public static FloatRange FromString(string s)
        {
            string[] splt = s.Split(':');
            return new FloatRange(float.Parse(splt[0]), float.Parse(splt[1]));
        }
    }

    public class CropData
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "crop")]
        public string Crop
        {
            get
            {
                return this.crop;
            }

            set
            {
                this.crop = value.ToUpper().Replace(' ', '_');
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimalTemperature")]
        public FloatRange MinimalTemperature { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "optimalTemperature")]
        public FloatRange OptimalTemperature { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "perfectTemperature")]
        public FloatRange PerfectTemperature { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "humidityRange")]
        public FloatRange HumidityRange { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "growthStages")]
        public int GrowthStages { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "growthRate")]
        public float GrowthRate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "baseHealth")]
        public float BaseHealth { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bug")]
        public string Bug
        {
            get
            {
                return this.bug;
            }

            set
            {
                this.bug = value.ToUpper().Replace(' ', '_');
            }
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "foundIn")]
        public string[] FoundIn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "harvestSeason")]
        public string[] HarvestSeason { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "harvestAction")]
        public string HarvestAction { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "nutrientConsumption")]
        public Dictionary<string, float> NutrientConsumption { get; set; } = new Dictionary<string, float>();

        [Newtonsoft.Json.JsonProperty(PropertyName = "waterConsumption")]
        public float WaterConsumption { get; set; }

        private string crop;
        private string bug;
    }
}
