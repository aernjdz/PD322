using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet set;
        private SqlCommandBuilder cmd;
        private List<string> tab_Names;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["storeDB"].ConnectionString);
            PopulateTableList();
        }

        private void PopulateTableList()
        {
            tab_Names = new List<string>();
            try
            {
                conn.Open();
                DataTable sh = conn.GetSchema("Tables");
                foreach (DataRow dr in sh.Rows)
                {

                    string name = dr["TABLE_NAME"].ToString();


#pragma warning disable CS8604
                    tab_Names.Add(name);
#pragma warning restore CS8604
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"Error :: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

            foreach (string name in tab_Names)
            {
                table.Items.Add(name);
            }

        }

        private void Fill(object sender, RoutedEventArgs e)
        {
            string selectTB = table.SelectedItem as string;
            if (selectTB != null)
            {
                string cmd_txt = $"SELECT * FROM {selectTB}";
                adapter = new SqlDataAdapter(cmd_txt, conn);
                cmd = new SqlCommandBuilder(adapter);
                set = new DataSet();
                
                adapter.Fill(set,selectTB);
                datagrd.ItemsSource = set.Tables[selectTB].DefaultView;
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if(set != null)
            {
                string selectedTB = table.SelectedItem as string;
                if(selectedTB != null)
                {
                    adapter.Update(set, selectedTB);
                }
            }
        }

    }
}