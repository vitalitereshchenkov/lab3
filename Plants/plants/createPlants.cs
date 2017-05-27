using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.plants
{
    abstract class createPlants
    {

        public abstract plant createPlant(List<string> values);

        public virtual List<string> GetPropertyNames()
        {
            var propertyName = new List<string>();

            propertyName.Add("Height");
            propertyName.Add("Origin");

            return propertyName;
        }

        public virtual void SetProperties(plant plant, List<string> values)
        {
            plant.height = Int32.Parse(values[0]);
            plant.origin = values[1];
        }

        public virtual List<string> GetProperties(plant plant)
        {
            var values = new List<string>();

            values.Add(plant.height.ToString());
            values.Add(plant.origin);

            return values;
        }


    }

    class CreateGrass : createPlants
    {

        public override void SetProperties(plant plant, List<string> values)
        {
            base.SetProperties(plant as grass, values);

            (plant as grass).type = values[2];
            (plant as grass).weight = Int32.Parse(values[3]);
            (plant as grass).price = Int32.Parse(values[4]);
            plant.name = "Grass";
        }

        public override List<string> GetProperties(plant plant)
        {
            var values = base.GetProperties(plant);

            values.Add((plant as grass).type);
            values.Add((plant as grass).weight.ToString());
            values.Add((plant as grass).price.ToString());

            return values;
        }

        public override plant createPlant(List<string> values)
        {
            grass grass = new grass();
            SetProperties(grass, values);

            return grass;
        }

        public override List<string> GetPropertyNames()
        {

            var propertyName = base.GetPropertyNames();

            propertyName.Add("Type");
            propertyName.Add("Weight");
            propertyName.Add("Price");

            return propertyName;

        }


    }

    class createTree : createPlants
    {
        public override void SetProperties(plant plant, List<string> values)
        {
            base.SetProperties(plant as tree, values);


            (plant as tree).leavesType = values[2];

            plant.name = "Tree";
        }

        public override List<string> GetProperties(plant plant)
        {
            var values = base.GetProperties(plant);

            values.Add((plant as tree).leavesType);

            return values;
        }

        public override plant createPlant(List<string> values)
        {
            tree tree = new tree();
            
            SetProperties(tree, values);


            return tree;
        }

        public override List<string> GetPropertyNames()
        {
            var propertyName = base.GetPropertyNames();

            propertyName.Add("Leaves type");

            return propertyName;
        }

    }


    class CreateCannabis : CreateGrass
    {
        public override void SetProperties(plant plant, List<string> values)
        {
            base.SetProperties(plant as cannabis, values);

            (plant as cannabis).kind = values[5];

            plant.name = "Cannabis";
        }

        public override List<string> GetProperties(plant plant)
        {
            var values = base.GetProperties(plant);

            values.Add((plant as cannabis).kind);

            return values;
        }

        public override plant createPlant(List<string> values)
        {
            cannabis cannabis = new cannabis();
            SetProperties(cannabis, values);

            return cannabis;
        }

        public override List<string> GetPropertyNames()
        {
            var propertyName = base.GetPropertyNames();

            propertyName.Add("Kind");

            return propertyName;
        }


    }

    class CreateCoriander : CreateGrass
    {
        public override void SetProperties(plant plant, List<string> values)
        {
            base.SetProperties(plant as coriander, values);

            (plant as coriander).recipe = values[5];

            plant.name = "coriander";
        }

        public override List<string> GetProperties(plant plant)
        {
            var values = base.GetProperties(plant);

            values.Add((plant as coriander).recipe);

            return values;
        }

        public override plant createPlant(List<string> values)
        {
            coriander coriander = new coriander();
            SetProperties(coriander, values);

            return coriander;
        }

        public override List<string> GetPropertyNames()
        {
            var propertyName = base.GetPropertyNames();

            propertyName.Add("Recipe");

            return propertyName;
        }


    }

    class CreateSpruce : createTree
    {
        public override void SetProperties(plant plant, List<string> values)
        {
            base.SetProperties(plant as spruce, values);

            (plant as spruce).color = values[3];

            plant.name = "Spruce";
        }

        public override List<string> GetProperties(plant plant)
        {
            var values = base.GetProperties(plant);

            values.Add((plant as spruce).color);

            return values;
        }

        public override plant createPlant(List<string> values)
        {
            spruce spruce = new spruce();
            SetProperties(spruce, values);

            return spruce;
        }

        public override List<string> GetPropertyNames()
        {
            var propertyName = base.GetPropertyNames();

            propertyName.Add("Color");

            return propertyName;
        }


    }

    class CreateBirch : createTree
    {
        public override void SetProperties(plant plant, List<string> values)
        {
            base.SetProperties(plant as birch, values);

            (plant as birch).age = Int32.Parse(values[3]);

            plant.name = "Birch";
        }

        public override List<string> GetProperties(plant plant)
        {
            var values = base.GetProperties(plant);

            values.Add((plant as birch).age.ToString());

            return values;
        }

        public override plant createPlant(List<string> values)
        {
            birch birch = new birch();
            SetProperties(birch, values);

            return birch;
        }

        public override List<string> GetPropertyNames()
        {
            var propertyName = base.GetPropertyNames();

            propertyName.Add("Age");

            return propertyName;
        }


    }
}
