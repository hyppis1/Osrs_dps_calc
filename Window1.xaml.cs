using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Globalization;

namespace Osrs_dps_calculator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<string> monster_stats = new List<string>();
        CollectionViewSource collectionViewSource = new CollectionViewSource();
        DataTable dataTable = new DataTable();
        DataTable bis_style_Table = new DataTable();
        private DataTable originalDataTable;
        string selected_monster;

        public Window1(List<List<string>> giga_data_list_transfer)
        {
            InitializeComponent();

            List<List<string>> giga_data_list = giga_data_list_transfer;

            List<string> columnNames = new List<string> { "Loadout name", "Weapon name", "Combat style", "Max hit", "Max attack roll", "Hit chance %", "Average dmg", "DPS", "Average dmg (Overkill)", "DPS (Overkill)", "Average hits to kill", "Average time to kill (s)", "Monster name" };

            List<Type> columnDataTypes = new List<Type>
            {
                typeof(string), // loadout name
                typeof(string), // weapon name
                typeof(string), // combat style
                typeof(double), // max hit
                typeof(double), // max attack roll
                typeof(double), // hit chance
                typeof(double), // avverage dmg
                typeof(double), // dps
                typeof(double), // avg dmg overkill
                typeof(double), // dps overkill
                typeof(double), // avg hits to kill
                typeof(double), // avg time to kill
                typeof(string), // monster name
            };

            for (int i = 0; i < columnNames.Count; i++)
            {
                dataTable.Columns.Add(columnNames[i], columnDataTypes[i]);
                bis_style_Table.Columns.Add(columnNames[i], columnDataTypes[i]);
            }

            for (int i = 0; i < giga_data_list[0].Count; i++)
            {
                DataRow newRow = dataTable.NewRow();

                // Fill each column with the corresponding element from the lists
                newRow["Loadout name"] = (giga_data_list[0][i]);
                newRow["Weapon name"] = (giga_data_list[1][i]);
                newRow["Combat style"] = (giga_data_list[2][i]);
                newRow["Max hit"] = double.Parse(giga_data_list[3][i]);
                newRow["Max attack roll"] = double.Parse(giga_data_list[4][i]);
                newRow["Hit chance %"] = double.Parse(giga_data_list[5][i]);
                newRow["Average dmg"] = double.Parse(giga_data_list[6][i]);
                newRow["DPS"] = double.Parse(giga_data_list[7][i]);
                newRow["Average dmg (Overkill)"] = double.Parse(giga_data_list[8][i]);
                newRow["DPS (Overkill)"] = double.Parse(giga_data_list[9][i]);
                newRow["Average hits to kill"] = double.Parse(giga_data_list[10][i]);
                newRow["Average time to kill (s)"] = double.Parse(giga_data_list[11][i]);
                newRow["Monster name"] = (giga_data_list[12][i]);

                dataTable.Rows.Add(newRow);
            }

            CollectionViewSource collectionViewSource = FindResource("CollectionViewSource") as CollectionViewSource;
            collectionViewSource.Source = dataTable.DefaultView;
            originalDataTable = dataTable.Copy();

            // monster stats

            for (int i = 0; i < giga_data_list[13].Count; i++)
            {
                monster_stats.Add(giga_data_list[13][i]);
            }

            double monster_count = Convert.ToInt32(giga_data_list[14][0]);

            for (int i = 0; i < monster_count; i++)
            {
               monsters_combobox.Items.Add(giga_data_list[12][i * 8]);
            }

        }

        private void FilterDataGridBasedOnSelection()
        {
            dataTable.Clear();
            dataTable.Merge(originalDataTable);
            data_grid.ItemsSource = dataTable.DefaultView;

            DataView dataView = new DataView(dataTable);

            if(selected_monster == null)
            {
                selected_monster = monsters_combobox.Items[0].ToString();
                monsters_combobox.Text = selected_monster;
            }

            string monster_filter = selected_monster.Replace("'", "''");

            string monster_filter_column = $"[Monster name] = '{monster_filter}'";
            string empty_style_filter_column = "[Max hit] <> '0'";

            string combined_filter = $"{empty_style_filter_column} AND {monster_filter_column}";

            dataView.RowFilter = combined_filter;

            data_grid.ItemsSource = dataView;

            data_grid.Items.Refresh();
        }

        private void monster_name_combobox_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(monsters_combobox.SelectedItem);
            if (temp_string != "")
            {
                selected_monster = Convert.ToString(temp_string);
                int selected_index = monsters_combobox.SelectedIndex;

                Dispatcher.Invoke(FilterDataGridBasedOnSelection);

                monster_atk_lvl_textbox.Text = monster_stats[0 + selected_index * 38];
                monster_str_lvl_textbox.Text = monster_stats[1 + selected_index * 38];
                monster_def_lvl_textbox.Text = monster_stats[2 + selected_index * 38];
                monster_magic_lvl_textbox.Text = monster_stats[3 + selected_index * 38];
                monster_range_lvl_textbox.Text = monster_stats[4 + selected_index * 38];
                monster_hp_lvl_textbox.Text = monster_stats[5 + selected_index * 38];

                monster_stab_def_textbox.Text = monster_stats[6 + selected_index * 38];
                monster_slash_def_textbox.Text = monster_stats[7 + selected_index * 38];
                monster_crush_def_textbox.Text = monster_stats[8 + selected_index * 38];
                monster_magic_def_textbox.Text = monster_stats[9 + selected_index * 38];
                monster_range_def_textbox.Text = monster_stats[10 + selected_index * 38];

                max_defence_roll_stab_textbox.Text = monster_stats[11 + selected_index * 38];
                max_defence_roll_slash_textbox.Text = monster_stats[12 + selected_index * 38];
                max_defence_roll_crush_textbox.Text = monster_stats[13 + selected_index * 38];
                max_defence_roll_magic_textbox.Text = monster_stats[14 + selected_index * 38];
                max_defence_roll_range_textbox.Text = monster_stats[15 + selected_index * 38];

                monster_aggressive_atk_textbox.Text = monster_stats[16 + selected_index * 38];
                monster_aggressive_str_textbox.Text = monster_stats[17 + selected_index * 38];
                monster_aggressive_mage_textbox.Text = monster_stats[18 + selected_index * 38];
                monster_aggressive_mage_dmg_textbox.Text = monster_stats[19 + selected_index * 38];
                monster_aggressive_range_textbox.Text = monster_stats[20 + selected_index * 38];
                monster_aggressive_range_str_textbox.Text = monster_stats[21 + selected_index * 38];

                arclight_hits_textbox.Text = monster_stats[22 + selected_index * 38];
                dwh_hits_textbox.Text = monster_stats[23 + selected_index * 38];
                bgs_dmg_textbox.Text = monster_stats[24 + selected_index * 38];
                dmg_textbox.Text = monster_stats[25 + selected_index * 38];
                team_size_textbox.Text = monster_stats[26 + selected_index * 38];
                raid_lvl_textbox.Text = monster_stats[27 + selected_index * 38];
                path_lvl_textbox.Text = monster_stats[28 + selected_index * 38];

                CM_cox_checkbox.IsChecked = Convert.ToBoolean(monster_stats[29 + selected_index * 38]);
                slayer_task_checkbox.IsChecked = Convert.ToBoolean(monster_stats[30 + selected_index * 38]);
                kandarin_diary_checkbox.IsChecked = Convert.ToBoolean(monster_stats[31 + selected_index * 38]);
                red_keris_spec_checkbox.IsChecked = Convert.ToBoolean(monster_stats[32 + selected_index * 38]);
                tome_of_water_checkbox.IsChecked = Convert.ToBoolean(monster_stats[33 + selected_index * 38]);
                vulnerability_checkbox.IsChecked = Convert.ToBoolean(monster_stats[34 + selected_index * 38]);
                enfeeble_checkbox.IsChecked = Convert.ToBoolean(monster_stats[35 + selected_index * 38]);
                stun_checkbox.IsChecked = Convert.ToBoolean(monster_stats[36 + selected_index * 38]);
                accursed_secptre_checkbox.IsChecked = Convert.ToBoolean(monster_stats[37 + selected_index * 38]);

            }
        }

        private void data_grid_sorting(object sender, DataGridSortingEventArgs e)
        {
            Dispatcher.Invoke(FilterDataGridBasedOnSelection);

            // Get the current DataView
            var dataView = CollectionViewSource.GetDefaultView(data_grid.ItemsSource) as BindingListCollectionView;

            // Get the current sorting column
            string sortingColumn = e.Column.Header.ToString();

            if (show_only_best_style_checkbox.IsChecked == true)
            {
                // Sort the DataView
                dataView.SortDescriptions.Clear();
                dataView.SortDescriptions.Add(new SortDescription(sortingColumn, ListSortDirection.Ascending));

                // Remove non bis styles from each loadout
                RemoveDuplicateLoadoutNames(dataView);

                // Set the sorted and filtered data back to the DataGrid
                data_grid.ItemsSource = dataView;

            }

            // Sort the DataView
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription(sortingColumn, ListSortDirection.Descending));

            // Mark the event as handled to prevent the default sorting behavior
            e.Handled = true;
        }

        private void RemoveDuplicateLoadoutNames(BindingListCollectionView dataView)
        {
            // Create a HashSet to keep track of whether a "Loadout name" has already been added
            HashSet<string> addedLoadoutNames = new HashSet<string>();

            // Iterate through the DataView and remove rows if the "Loadout name" has already been added
            for (int i = dataView.Count - 1; i >= 0; i--)
            {
                var item = dataView.GetItemAt(i);

                // Ensure the item is a DataRowView before proceeding
                if (item is DataRowView rowView)
                {
                    DataRow row = rowView.Row;

                    string loadoutName = row.Field<string>("Loadout name");

                    if (loadoutName != null && addedLoadoutNames.Contains(loadoutName))
                    {
                        // Remove the row from the DataTable
                        row.Delete();
                    }
                    else
                    {
                        // Mark this "Loadout name" as added
                        addedLoadoutNames.Add(loadoutName);
                    }
                }
            }

            // Accept changes to apply the deletions
            dataTable.AcceptChanges();
        }

    }
}
