using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainerProgramInfo : System.Web.UI.Page
{
    LiteralControl[] literalControlArray1 = new LiteralControl[21];
    LiteralControl[] literalControlArray2 = new LiteralControl[21];
    LiteralControl[] literalControlArray3 = new LiteralControl[21];
    static int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        {
            if (!IsPostBack)
            {
                i = 0;
            }
            for (int j = 0; j <= 20; j++)   //creating 21 labels
            {
                literalControlArray1[j] = new LiteralControl("Excercise " + (j + 1) + ": ");
                literalControlArray1[j].ID = "Excercise " + (j + 1).ToString() + ": ";
                literalControlArray2[j] = new LiteralControl("Sets " + (j + 1) + ": ");
                literalControlArray2[j].ID = "Sets " + (j + 1) + ": ";
                literalControlArray3[j] = new LiteralControl("Reps " + (j + 1) + ": ");
                literalControlArray3[j].ID = "Reps " + (j + 1) + ": ";

                literalControlArray1[j].Visible = false;
                literalControlArray2[j].Visible = false;
                literalControlArray3[j].Visible = false;
            }


            for (int j = 0; j <= 20; j++)   //creating 21 workouts the are not visibale
            {
                //building sets dropdown list
                DropDownList sets = new DropDownList();
                for (int i = 1; i < 21; i++)
                {
                    sets.Items.Add(i.ToString());
                }
                sets.DataTextField = "fldSetsId";
                sets.DataValueField = "fldSetsId";
                sets.DataBind();

                //building excercises dropdown list
                DropDownList excercises = new DropDownList();
                excercises.DataSource = MyAdoHelper.GetDataSet("Select * from tblExcerciseList");
                excercises.DataTextField = "fldExcerciseId";
                excercises.DataValueField = "fldExcerciseId";
                excercises.DataBind();

                //building reps dropdown list
                DropDownList reps = new DropDownList();
                for (int i = 1; i < 6; i++)
                {
                    reps.Items.Add(i.ToString());
                }
                reps.DataValueField = "fldRepsId";
                sets.DataValueField = "fldRepsId";
                reps.DataBind();

                excercises.ID = "Exercise" + j.ToString();
                sets.ID = "Sets" + j.ToString();
                reps.ID = "Reps" + j.ToString();

                PlaceHolder1.Controls.Add(literalControlArray1[j]);
                PlaceHolder1.Controls.Add(excercises);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));

                PlaceHolder1.Controls.Add(literalControlArray2[j]);
                PlaceHolder1.Controls.Add(sets);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));

                PlaceHolder1.Controls.Add(literalControlArray3[j]);
                PlaceHolder1.Controls.Add(reps);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));

                excercises.Visible = false;
                sets.Visible = false;
                reps.Visible = false;

            }
        }
    }


    protected void addnewworkout1_Click(object sender, EventArgs e)
    {
        for(int j=0; j<=i; j++)
        {
            PlaceHolder1.FindControl("Exercise" + j.ToString()).Visible=true;
            PlaceHolder1.FindControl("Sets" + j.ToString()).Visible = true;
            PlaceHolder1.FindControl("Reps" + j.ToString()).Visible = true;
            literalControlArray1[j].Visible = true;
            literalControlArray2[j].Visible = true;
            literalControlArray3[j].Visible = true;
        }
        i++;
    }
    
    protected void submitworkout_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string workout = "";
            for (int j = 0; j <= i; j++)
            {
                string excercice = ((DropDownList)PlaceHolder1.FindControl("Exercise" + j.ToString())).SelectedItem.Text;
                string sets = ((DropDownList)PlaceHolder1.FindControl("Sets" + j.ToString())).SelectedItem.Text;
                string reps = ((DropDownList)PlaceHolder1.FindControl("Reps" + j.ToString())).SelectedItem.Text;
                workout += "Excercise" + j.ToString() + ": " + excercice + " Sets: " + sets + " Reps: " + reps + " ";
            }
            string strProgramDuration = inDuration.Value;
            string strProgramType = inType.Value;
            string strProgramLevel = inLevel.Value;

            MyAdoHelper.addProgramInfo(strProgramDuration, strProgramType, strProgramLevel, workout, Session["username"].ToString(), "Database.mdf");
        }
    }



}