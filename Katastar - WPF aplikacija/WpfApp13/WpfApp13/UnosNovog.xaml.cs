using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for UnosNovog.xaml
    /// </summary>
    public partial class UnosNovog : Window
    {
        KatastarDataContext Katastar = new KatastarDataContext();
        
        public UnosNovog()
        {
            
            InitializeComponent();
            puniComb();
        }
        private void puniComb()
        {
            var opstine = from o in Katastar.KatastarskeOpstines
                          select o;
            cbKatOpstina.ItemsSource = opstine;
        }
        private void puniListu()
        {
            var parcele =from p in Katastar.Parceles 
                where p.IDKatOpstine == int.Parse(((KatastarskeOpstine)cbKatOpstina.SelectedValue).IDKatOpstina.ToString())
                select p;
            lbParcela.ItemsSource = parcele;
        }

        private void CbKatOpstina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                    puniListu();
            
        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSifra.Text) && !String.IsNullOrEmpty(tbVlasnik.Text) && !String.IsNullOrEmpty(tbKvadratura.Text) && !String.IsNullOrEmpty(cbKatOpstina.Text) && lbParcela.SelectedValue != null)
            {
                try
                {
                    Objekti objekti = (from o in Katastar.Objektis
                                       where o.IDKatOpstine == int.Parse(((Parcele)lbParcela.SelectedValue).IDKatOpstine.ToString()) && o.IDParcele == int.Parse(((Parcele)lbParcela.SelectedValue).IDParcele.ToString())
                                       select o).First();
                    if (objekti != null)
                    {
                        MessageBox.Show("Na ovoj parceli ima objekta pokusaj na drugoj");
                    }
                }
                catch(Exception)
                {
                    Objekti nov = new Objekti()
                        {
                            IDObjekta = (int.Parse)(tbSifra.Text),
                            Vlasnik = tbVlasnik.Text,
                            Kvadratura = int.Parse(tbKvadratura.Text),
                            Uknjizeno = (bool)cbUknjizeno.IsChecked,
                            IDKatOpstine = (int.Parse)(((KatastarskeOpstine)cbKatOpstina.SelectedValue).IDKatOpstina.ToString()),
                            IDParcele = (int.Parse)(((Parcele)lbParcela.SelectedValue).IDParcele.ToString()),
                        };


                        Katastar.Objektis.InsertOnSubmit(nov);
                       


                        try
                        {
                            Katastar.SubmitChanges();
                            MessageBox.Show("Uspesan unos");
                            resetuj();
                        }
                        catch (Exception)
                        {

                        }
                    
                }
            }
            else
            {
                MessageBox.Show("Sva polja su obavezna!!!");
            }
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            resetuj();
        }
        private void resetuj()
        {
            tbSifra.Text = "";
            tbVlasnik.Text = "";
            tbKvadratura.Text = "";
            cbUknjizeno.IsChecked = false;
            cbKatOpstina.SelectedIndex = -1;
            lbParcela.SelectedIndex = -1;
        }
    }
}
