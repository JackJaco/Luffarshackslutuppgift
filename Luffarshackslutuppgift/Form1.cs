namespace Luffarshackslutuppgift
{
    public partial class Form1 : Form
    {
        //true = X tur och false = O tur
        bool tur = true;
        int tur_antal = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void omToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Detta �r mitt slutprojekt!", "Hejsan Tobias");
        }

        private void st�ngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //st�ng ner programmet
            Application.Exit();
        }
        
        private void knapp_klick(object sender, EventArgs e)

        {
            Button b = (Button)sender;
            if (tur)
                b.Text = "X";
            else
                b.Text = "O";

            tur = !tur;
            b.Enabled = false;

            tur_antal++;

            vinnare();
        }

        private void vinnare()
        {
            bool det_finns_en_vinnare = false;


            //H�r g�r vi s� att man kan vinna med att ha tre i rad horistontellt
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                det_finns_en_vinnare = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                det_finns_en_vinnare = true;

            //H�r g�r vi s� att man kan vinna med att ha tre i rad vertikalt
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                det_finns_en_vinnare = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                det_finns_en_vinnare = true;

            //H�r g�r vi s� att man kan vinna med att ha tre i rad diagonalt
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
            

            //blir det tre i rad f�r X eller O uppst�r det en message box som s�ger vinnare till en av dom
            if (det_finns_en_vinnare)
            {
                disableButtons();

                String vinnare = " ";
                if (tur)
                    vinnare = "O";
                else
                    vinnare = "X";

                MessageBox.Show(vinnare + " �r vinnaren!");
            }
            else
            {
                //Om det har g�tt 9 omg�ngar kommer det upp en message box som s�ger oavgjort
                if(tur_antal == 9)
                    MessageBox.Show("Oavgjort!");

            }
        }

        //funktionen l�ter en inte klicka igen p� en knapp som redan har blivit nertryckt
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
            
        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tur = true;
            tur_antal = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = " ";
                }
            }
            catch { }
        }
    }
}