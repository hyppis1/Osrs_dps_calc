using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Osrs_dps_calculator
{
    public partial class MainWindow : Window
    {
        double combat_lvl;
        double hp_lvl;
        double hp_remaining;
        double prayer_lvl;
        double prayer_remaining;
        double mining_lvl;

        double attack_lvl;
        double attack_pot;
        double attack_prayer;
        double attack_lvl_and_pot;
        double attack_lvl_and_pot_modifier;
        double true_attack_lvl;
        double temp_effective_attack_lvl;

        double strength_lvl;
        double strength_pot;
        double strenght_prayer;
        double strength_lvl_and_pot;
        double strength_lvl_and_pot_modifier;
        double true_strength_lvl;
        double temp_effective_strength_lvl;

        double temp_max_attack_roll;
        List<double> max_attack_roll_list = new List<double>();

        double temp_max_hit;
        List<double> max_hit_list = new List<double>();

        double temp_hit_chance;
        List<double> hit_chance_list = new List<double>();

        double temp_avg_dmg_per_attack;
        List<double> avg_dmg_per_attack_list = new List<double>();
        List<double> overkill_avg_dmg_per_attack_list = new List<double>();

        List<double> dps_list = new List<double>();
        List<double> overkill_dps_list = new List<double>();

        double temp_avg_hits_to_kill;
        List<double> avg_hits_to_kill_list = new List<double>();

        List<double> time_to_kill_list = new List<double>();

        double defence_lvl;
        double defence_pot;
        double defence_prayer;
        double defence_lvl_and_pot;
        double defence_lvl_and_pot_modifier;
        double true_defence_lvl;

        double magic_lvl;
        double magic_pot;
        double magic_prayer;
        double magic_lvl_and_pot;
        double magic_lvl_and_pot_modifier;
        double true_mage_lvl;
        double spell_base_max_hit;
        double staff_base_max_hit;
        double temp_effective_mage_lvl;

        double range_lvl;
        double range_pot;
        double range_prayer;
        double range_str_prayer;
        double range_lvl_and_pot;
        double range_lvl_and_pot_modifier;
        double true_range_lvl;
        double true_range_str;
        double temp_effective_range_lvl;
        double temp_effective_range_str;

        double[] stab_def_array = new double[22];
        double[] stab_def_modifier_array = new double[2];
        double[] total_stab_def_array = new double[2];

        double[] slash_def_array = new double[22];
        double[] slash_def_modifier_array = new double[2];
        double[] total_slash_def_array = new double[2];

        double[] crush_def_array = new double[22];
        double[] crush_def_modifier_array = new double[2];
        double[] total_crush_def_array = new double[2];

        double[] magic_def_array = new double[22];
        double[] magic_def_modifier_array = new double[2];
        double[] total_magic_def_array = new double[2];

        double[] range_def_array = new double[22];
        double[] range_def_modifier_array = new double[2];
        double[] total_range_def_array = new double[2];

        double[] prayer_bonus_array = new double[22];
        double[] total_prayer_bonus_array = new double[2];

        double[] stab_atk_array = new double[22];
        double[] stab_atk_modifier_array = new double[2];
        double[] total_stab_atk_array = new double[2];

        double[] slash_atk_array = new double[22];
        double[] slash_atk_modifier_array = new double[2];
        double[] total_slash_atk_array = new double[2];

        double[] crush_atk_array = new double[22];
        double[] crush_atk_modifier_array = new double[2];
        double[] total_crush_atk_array = new double[2];

        double[] magic_atk_array = new double[22];
        double[] magic_atk_modifier_array = new double[2];
        double[] total_magic_atk_array = new double[2];

        double[] range_atk_array = new double[22];
        double[] range_atk_modifier_array = new double[2];
        double[] total_range_atk_array = new double[2];

        double[] melee_str_array = new double[22];
        double[] melee_str_modifier_array = new double[2];
        double[] total_melee_str_array = new double[2];

        double[] range_str_array = new double[22];
        double[] range_str_modifier_array = new double[2];
        double[] total_range_str_array = new double[2];

        double[] magic_dmg_array = new double[22];
        double[] magic_dmg_modifier_array = new double[2];
        double[] total_magic_dmg_array = new double[2];

        string[] preset_name_array = new string[2];
        string[] helmet_name_array = new string[2];
        string[] cape_name_array = new string[2];
        string[] amulet_name_array = new string[2];
        string[] ammo_name_array = new string[2];
        string[] weapon_name_array = new string[2];
        string[] body_name_array = new string[2];
        string[] off_hand_name_array = new string[2];
        string[] legs_name_array = new string[2];
        string[] gloves_name_array = new string[2];
        string[] boots_name_array = new string[2];
        string[] ring_name_array = new string[2];
        string[] spell_name_array = new string[2];
        string[] spell_book_array = new string[2];

        string atk_pot_name;
        string atk_prayer_name;
        double[] style_bonus_attack_array = new double[8];
        string str_pot_name;
        string str_prayer_name;
        double[] style_bonus_str_array = new double[8];
        string def_pot_name;
        string def_prayer_name;
        double[] style_bonus_def_array = new double[8];
        string magic_pot_name;
        string magic_prayer_name;
        double[] style_bonus_magic_array = new double[8];
        string range_pot_name;
        string range_prayer_name;
        double[] style_bonus_range_array = new double[8];
        string monster_name;

        bool gear_set_2;
        bool show_set_2;

        string thrall_name;
        string thrall_type;
        double thrall_max_hit;
        double thrall_avg_dmg;
        double thrall_damage_per_second;


        List<string> temp_combat_style_textbox_list = new List<string>();
        List<string> temp_max_hit_textbox_list = new List<string>();
        List<string> temp_max_attack_roll_textbox_list = new List<string>();
        List<string> temp_hit_chance_textbox_list = new List<string>();
        List<string> temp_avg_dmg_textbox_list = new List<string>();
        List<string> temp_dps_textbox_list = new List<string>();
        List<string> temp_avg_dmg_overkill_textbox_list = new List<string>();
        List<string> temp_dps_overkill_textbox_list = new List<string>();
        List<string> temp_avg_hits_to_kill_textbox_list = new List<string>();
        List<string> temp_avg_time_to_kill_textbox_list = new List<string>();
        List<string> temp_extra_info_textbox_list = new List<string>();

        double[] mining_lvl_req_array = new double[2];

        double[] custom_attack_speed_array = new double[2];
        double temp_weapon_attack_speed;

        double special_attack_roll_modifier;
        double special_dmg_roll_modifier;
        string special_defence_roll_modifier;

        double[] special_attack_roll_1_array = new double[8];
        double[] special_attack_roll_2_array = new double[8];
        double special_attack_roll_1;
        double special_attack_roll_2;

        double[] special_max_hit_1_array = new double[8];
        double[] special_max_hit_2_array = new double[8];
        double[] special_max_hit_3_array = new double[8];
        double[] special_max_hit_4_array = new double[8];
        double special_max_hit_1;
        double special_max_hit_2;
        double special_max_hit_3;
        double special_max_hit_4;

        double dragon_claw_spec_min_hit;

        double[] dwh_avg_def_reduction_list = new double[8];

        double[] spec_min_hit_array = new double[8];
        double spec_min_hit;

        double[] special_average_dmg_1_array = new double[8];
        double[] special_average_dmg_2_array = new double[8];
        double special_average_dmg_1;
        double special_average_dmg_2;

        double[] special_hit_chance_1_array = new double[8];
        double[] special_hit_chance_2_array = new double[8];
        double special_hit_chance_1;
        double special_hit_chance_2;

        double special_additional_dmg;

        bool[] has_special_attack_array= new bool[2];
        bool[] is_weapon_2h_array = new bool[2];
        double[] weapon_atk_speed_array = new double[2];

        string[] weapon_type_array = new string[8]; // stab, slash, cursh, range, mage, cast
        string[] weapon_stance_array = new string[8]; // accurate, aggressive, defensive, controlled, rapid, longrange
        string temp_weapon_type;
        string temp_weapon_stance;

        bool monster_is_undead;
        bool monster_is_dragon;
        bool monster_is_demon;
        bool monster_is_kaplhite;
        bool monster_is_in_cox;
        bool monster_is_in_tob;
        bool monster_is_in_toa;
        bool monster_is_in_wilderness;
        double monster_size;
        double monster_combat_hp_lvl;
        double monster_combat_atk_lvl;
        double monster_combat_str_lvl;
        double monster_combat_def_lvl;
        double monster_defence_cap;
        double monster_combat_magic_lvl;
        double monster_combat_range_lvl;
        double monster_aggressive_atk;
        double monster_aggressive_str;
        double monster_aggressive_magic;
        double monster_aggressive_magic_dmg;
        double monster_aggressive_range;
        double monster_aggressive_range_str;
        double monster_defensive_stab;
        double monster_defensive_slash;
        double monster_defensive_crush;
        double monster_defensive_magic;
        double monster_defensive_range;
        double temp_monster_max_defensive_roll;
        double monster_max_defensive_roll_stab;
        double monster_max_defensive_roll_slash;
        double monster_max_defensive_roll_crush;
        double monster_max_defensive_roll_magic;
        double monster_max_defensive_roll_range;

        double melee_prayer_effectiviness;
        double mage_prayer_effectiviness;
        double range_prayer_effectiviness;

        double[] monster_max_hit_array = new double[10];
        double[] monster_attack_roll_array = new double[10];
        double[] monster_hit_chance_array = new double[10];
        double[] monster_avg_dmg_array = new double[10];

        double[] player_def_roll_array = new double[10];

        double distance_to_monster;

        double venator_bow_1st_bounce_def_lvl;
        double venator_bow_1st_bounce_range_def;
        double venator_bow_2nd_bounce_def_lvl;
        double venator_bow_2nd_bounce_range_def;

        double soulreaper_axe_stack;
        int dwh_hits;
        int arclight_hits;
        double bgs_dmg;
        double dmg_delt;

        double team_size;
        int toa_raid_lvl;
        int toa_path_lvl;

        double monster_boosted_hp_lvl;
        double monster_boosted_atk_lvl;
        double monster_boosted_str_lvl;
        double monster_boosted_def_lvl;
        double monster_boosted_magic_lvl;
        double monster_boosted_range_lvl;

        double monster_reduced_hp_lvl;
        double monster_reduced_atk_lvl;
        double monster_reduced_str_lvl;
        double monster_reduced_def_lvl;
        double monster_reduced_magic_lvl;
        double monster_reduced_range_lvl;


        double[] scythe_hitsplat_1_array = new double[8];
        double[] scythe_hitsplat_2_array = new double[8];
        double[] scythe_hitsplat_3_array = new double[8];
        double scythe_hitsplat_1;
        double scythe_hitsplat_2;
        double scythe_hitsplat_3;

        double[] osmumtens_fang_max_hit_array = new double[8];
        double[] osmumtens_fang_min_hit_array = new double[8];
        double osmumtens_fang_max_hit;
        double osmumtens_fang_min_hit;

        bool immune_to_melee;
        bool immune_to_mage;
        bool immune_to_range;
        bool[] is_immune_array = new bool[2];
        bool[] special_immune_array = new bool[2];
        bool[] special_immune_2_array = new bool[2];
        bool temp_immune;
        bool thrall_immune;

        bool special_attack_fix;
        int corp_style_fix;
        int dps_calc_fix;

        double[] bolt_proc_dmg_array = new double[16];
        double[] bolt_normal_dmg_array = new double[16];
        double[] bolt_proc_chance_array = new double[16];
        double bolt_proc_chance;
        double bolt_proc_chance_acb_spec;
        double bolt_proc_kandarin_bonus;
        double bolt_proc_dmg;

        string loadout_name;
        string deleted_loadout_name;
        bool loadout_was_deleted;
        string loadout_data;
        string multiple_monsters_data;
        List<string> multiple_monsters_data_list = new List<string>();
        List<string> multiple_monsters_stats_data_list = new List<string>();
        List<string> multiple_monsters_names_data_list = new List<string>();

        List<string> multiple_loadout_name_data_list = new List<string>();
        List<string> multiple_weapon_name_data_list = new List<string>();
        List<string> multiple_combat_style_data_list = new List<string>();
        List<string> multiple_max_hit_data_list = new List<string>();
        List<string> multiple_max_attack_roll_data_list = new List<string>();
        List<string> multiple_hit_chance_data_list = new List<string>();
        List<string> multiple_avg_dmg_data_list = new List<string>();
        List<string> multiple_dps_data_list = new List<string>();
        List<string> multiple_avg_dmg_overkill_data_list = new List<string>();
        List<string> multiple_dps_overkill_data_list = new List<string>();
        List<string> multiple_avg_hits_to_kill_data_list = new List<string>();
        List<string> multiple_time_to_kill_data_list = new List<string>();

        List<string> monster_count = new List<string>();
        List<List<string>> giga_data_list = new List<List<string>>();

        List<string> temp_mutiple_monster_names_list = new List<string>();

        string set_1_during_multicalc;
        string set_2_during_multicalc;

        bool from_load;
        bool multiple_calcs;


        public MainWindow()
        {
            multiple_calcs = false;
            from_load = true;

            InitializeComponent();

            ToolTipService.ShowDurationProperty.OverrideMetadata(
            typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));

            weapon_name_array[0] = "None";
            ammo_name_array[0] = "None";
            helmet_name_array[0] = "None";
            cape_name_array[0] = "None";
            amulet_name_array[0] = "None";
            body_name_array[0] = "None";
            legs_name_array[0] = "None";
            off_hand_name_array[0] = "None";
            gloves_name_array[0] = "None";
            boots_name_array[0] = "None";
            ring_name_array[0] = "None";
            Dispatcher.Invoke(gear);

            spell_name_array[0] = "None";
            Dispatcher.Invoke(spell_gear);

            weapon_name_array[1] = "None";
            ammo_name_array[1] = "None";
            helmet_name_array[1] = "None";
            cape_name_array[1] = "None";
            amulet_name_array[1] = "None";
            body_name_array[1] = "None";
            legs_name_array[1] = "None";
            off_hand_name_array[1] = "None";
            gloves_name_array[1] = "None";
            boots_name_array[1] = "None";
            ring_name_array[1] = "None";
            gear_set_2 = true;
            Dispatcher.Invoke(weapon_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(ammo_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(helmet_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(cape_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(amulet_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(body_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(legs_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(off_hand_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(gloves_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(boots_gear);
            gear_set_2 = true;
            Dispatcher.Invoke(ring_gear);

            spell_name_array[1] = "None";
            gear_set_2 = true;
            Dispatcher.Invoke(spell_gear);

            atk_pot_name = "None";
            str_pot_name = "None";
            def_pot_name = "None";
            magic_pot_name = "None";
            range_pot_name = "None";
            Dispatcher.Invoke(potions);

            atk_prayer_name = "None";
            str_prayer_name = "None";
            def_prayer_name = "None";
            magic_prayer_name = "None";
            range_prayer_name = "None";
            Dispatcher.Invoke(prayers);

            monster_name = "None";
            Dispatcher.Invoke(monsters);

            attack_lvl = 99;
            strength_lvl = 99;
            defence_lvl = 99;
            magic_lvl = 99;
            range_lvl = 99;
            hp_lvl = 99;
            prayer_lvl = 99;
            mining_lvl = 99;
            custom_attack_speed_array[0] = 4;
            custom_attack_speed_array[1] = 4;

            hp_remaining = 99;
            prayer_remaining = 99;

            soulreaper_axe_stack = 0;

            melee_prayer_effectiviness = 0;
            mage_prayer_effectiviness = 0;
            range_prayer_effectiviness = 0;

            vulnerability_checkbox.IsChecked = false;
            stun_checkbox.IsChecked = false;
            enfeeble_checkbox.IsChecked = false;
            tome_of_water_checkbox.IsChecked = false;
            slayer_task_checkbox.IsChecked = true;
            CM_cox_checkbox.IsChecked = false;
            dragon_picaxe_spec_checkbox.IsChecked = false;
            custom_attack_speed_checkbox.IsChecked = false;
            custom_attack_speed_2_checkbox.IsChecked = false;
            overkill_checkbox.IsChecked = true;
            accursed_secptre_checkbox.IsChecked = false;
            red_keris_spec_checkbox.IsChecked = false;
            thrall_dps_checkbox.IsChecked = false;
            kandarin_diary_checkbox.IsChecked = true;
            venator_1st_bounce_checkbox.IsChecked = false;
            venator_2nd_bounce_checkbox.IsChecked = false;

            add_nylos_checkbox.IsChecked = false;
            add_baboons_and_scarabs_checkbox.IsChecked = false;

            venator_bow_1st_bounce_def_lvl = 0;
            venator_bow_1st_bounce_range_def = 0;
            venator_bow_2nd_bounce_def_lvl = 0;
            venator_bow_2nd_bounce_range_def = 0;

            arclight_hits = 0;
            dwh_hits = 0;
            bgs_dmg = 0;
            dmg_delt = 0;

            team_size = 1;
            toa_raid_lvl = 300;
            toa_path_lvl = 0;

            attack_lvl_and_pot_modifier = 0;
            strength_lvl_and_pot_modifier = 0;
            defence_lvl_and_pot_modifier = 0;
            magic_lvl_and_pot_modifier = 0;
            range_lvl_and_pot_modifier = 0;

            stab_atk_modifier_array[0] = 0;
            slash_atk_modifier_array[0] = 0;
            crush_atk_modifier_array[0] = 0;
            magic_atk_modifier_array[0] = 0;
            range_atk_modifier_array[0] = 0;
            melee_str_modifier_array[0] = 0;
            range_str_modifier_array[0] = 0;
            magic_dmg_modifier_array[0] = 0;

            stab_atk_modifier_array[1] = 0;
            slash_atk_modifier_array[1] = 0;
            crush_atk_modifier_array[1] = 0;
            magic_atk_modifier_array[1] = 0;
            range_atk_modifier_array[1] = 0;
            melee_str_modifier_array[1] = 0;
            range_str_modifier_array[1] = 0;
            magic_dmg_modifier_array[1] = 0;

            distance_to_monster = 0;

            thrall_name = "Greater Ghost";
            thrall_type = "magic";

            for (int i = 0; i < 8; i++)
            {

                compare_styles_set_1_combobox.Items.Add("none");
                compare_styles_set_2_combobox.Items.Add("none");
            }

            Dispatcher.Invoke(combobox_items);

            Dispatcher.Invoke(load_loadout_names_data);

            from_load = false;

            Dispatcher.Invoke(Stats);

        }
        private void combobox_items()
        {
            // weapons
            List<string> items = new List<string>
            {
                "Bandos godsword",
                "Zamorak godsword",
                "Saradomin godsword",
                "Ancient godsword",
                "Armadyl godsword",
                "Abyssal bludgeon",
                "Abyssal dagger",
                "Abyssal tentacle",
                "Abyssal whip",
                "Accursed sceptre",
                "Adamant darts",
                "Amethyst darts",
                "Ancient sceptre",
                "Arclight",
                "Armadyl crossbow",
                "Black chinchompa",
                "Black darts",
                "Blade of saeldor",
                "Bow of faerdhinen",
                "Craw's bow",
                "Crystal halberd",
                "Dark bow",
                "Dawnbringer",
                "Dragon crossbow",
                "Dragon dagger",
                "Dragon darts",
                "Dragon halberd",
                "Dragon hasta",
                "Dragon hunter crossbow",
                "Dragon hunter lance",
                "Dragon knife",
                "Dragon Pickaxe",
                "Dragon spear",
                "Dragon warhammer",
                "Dragon thrownaxe",
                "Eldritch nightmare staff",
                "Ghrazi rapier",
                "Granite hammer",
                "Granite maul",
                "Harmonised nightmare staff",
                "Ham joint",
                "Heavy ballista",
                "Ice ancient sceptre",
                "Inquisitor's mace",
                "Keris partisan",
                "Keris partisan of breaching",
                "Keris partisan of corruption",
                "Keris partisan of the sun",
                "Light ballista",
                "Magic longbow",
                "Magic shortbow",
                "Magic shortbow (i)",
                "Mithril darts",
                "Nightmare staff",
                "Osmumten's fang",
                "Rune Pickaxe",
                "Rune crossbow",
                "Sanguinesti staff",
                "Saradomin sword",
                "Saradomin's blessed sword",
                "Scythe of vitur",
                "Soulreaper axe",
                "Steel darts",
                "Swift blade",
                "Thammaron's sceptre",
                "Toxic blowpipe",
                "Trident of the seas",
                "Trident of the swamp",
                "Twisted bow",
                "Ursine chainmace",
                "Venator bow",
                "Viggora's chainmace",
                "Voidwaker",
                "Webweaver bow",
                "Zamorakian hasta",
                "Zamorakian spear",
                "Zaryte crossbow",
            };
            items.Sort();

            weapon_set_1_combobox.Items.Add("None");
            weapon_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                weapon_set_1_combobox.Items.Add(item);
                weapon_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // spells
            items.AddRange(new List<string>
            {
                "Fire Surge",
                "Earth Surge",
                "Water Surge",
                "Wind Surge",
                "Fire Wave",
                "Earth Wave",
                "Water Wave",
                "Wind Wave",
                "Fire Blast",
                "Earth Blast",
                "Water Blast",
                "Wind Blast",
                "Fire Bolt",
                "Earth Bolt",
                "Water Bolt",
                "Wind Bolt",
                "Fire Strike",
                "Earth Strike",
                "Water Strike",
                "Wind Strike",
                "Crumble Undead",
                "God Spell",
                "God Spell (charged)",
                "Iban Blast",
                "Magic Dart",
                "Vulnerability",
                "Enfeeble",
                "Stun",
                "Curse",
                "Weaken",
                "Confuse",
                "Entangle",
                "Snare",
                "Bind",
                "Tele Block",
                "Ice Barrage",
                "Blood Barrage",
                "Shadow Barrage",
                "Smoke Barrage",
                "Ice Blitz",
                "Blood Blitz",
                "Shadow Blitz",
                "Smoke Blitz",
                "Ice Burst",
                "Blood Burst",
                "Shadow Burst",
                "Smoke Burst",
                "Ice Rush",
                "Blood Rush",
                "Shadow Rush",
                "Smoke Rush",
                "Dark Demonbane",
                "Superior Demonbane",
                "Inferior Demonbane",
                "Undead Grasp",
                "Skeletal Grasp",
                "Ghostly Grasp"

            });
            items.Sort();

            spell_set_1_combobox.Items.Add("None");
            spell_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                spell_set_1_combobox.Items.Add(item);
                spell_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // ammo
            items.AddRange(new List<string>
            {
                "Dragon arrows",
                "Amethyst arrows",
                "Rune arrows",
                "Adamant arrows",
                "Broad arrows",
                "Mithril arrows",
                "Steel arrows",
                "Iron arrows",
                "Bronze arrows",
                "Dragon darts",
                "Amethyst darts",
                "Rune darts",
                "Adamant darts",
                "Mithril darts",
                "Black darts",
                "Steel darts",
                "Iron darts",
                "Bronze darts",
                "Dragon javelins",
                "Amethyst javelins",
                "Rune javelins",
                "Adamant javelins",
                "Mithril javelins",
                "Steel javelins",
                "Iron javelins",
                "Bronze javelins",
                "Ruby dragon bolts (e)",
                "Diamond dragon bolts (e)",
                "Dragonstone dragon bolts (e)",
                "Onyx dragon bolts (e)",
                "Opal dragon bolts (e)",
                "Pearl dragon bolts (e)",
                "Dragon bolts",
                "Ruby bolts (e)",
                "Diamond bolts (e)",
                "Dragonstone bolts (e)",
                "Onyx bolts (e)",
                "Opal bolts (e)",
                "Pearl bolts (e)",
                "Amethyst broad bolts",
                "Runite bolts",
                "Broad bolts",
                "Adamant bolts",
                "Mithril bolts",
                "Steel bolts",
                "Silver bolts",
                "Iron bolts",
                "Bronze bolts"

            });
            items.Sort();

            ammo_set_1_combobox.Items.Add("None");
            ammo_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                ammo_set_1_combobox.Items.Add(item);
                ammo_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // helmets
            items.AddRange(new List<string>
            {
                "Torva full helm",
                "Neitiznot faceguard",
                "Inquisitor's great helm",
                "Serpentine helm",
                "Justiciar faceguard",
                "Ancestral hat",
                "Virtus mask",
                "Ahrim's hood",
                "Masori mask (f)",
                "Armadyl helmet",
                "Crystal helm",
                "Robin hood hat",
                "God d'hide coif",
                "Archer helm",
                "Slayer helmet (i)",
                "Void helmet"

            });
            items.Sort();

            helmet_set_1_combobox.Items.Add("None");
            helmet_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                helmet_set_1_combobox.Items.Add(item);
                helmet_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // capes
            items.AddRange(new List<string>
            {
                "Infernal cape",
                "Fire cape",
                "Mythical cape",
                "God cape (i)",
                "God cape",
                "Ardougne cloak 4",
                "Ardougne cloak 3",
                "Ghostly cloak",
                "Ardougne cloak 2",
                "Ardougne cloak 1",
                "God cloak",
                "Ava's assembler",
                "Ava's accumulator",
                "Ava's attractor"

            });
            items.Sort();

            cape_set_1_combobox.Items.Add("None");
            cape_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                cape_set_1_combobox.Items.Add(item);
                cape_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // amulets
            items.AddRange(new List<string>
            {
                "Amulet of torture",
                "Amulet of strength",
                "Occult necklace",
                "Necklace of anguish",
                "Amulet of fury",
                "Amulet of glory",
                "Salve amulet (ei)"

            });
            items.Sort();

            necklace_set_1_combobox.Items.Add("None");
            necklace_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                necklace_set_1_combobox.Items.Add(item);
                necklace_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // body
            items.AddRange(new List<string>
            {
                "Torva platebody",
                "Bandos chestplate",
                "Inquisitor's hauberk",
                "Fighter torso",
                "Justiciar chestguard",
                "Ancestral robe top",
                "Virtus robe top",
                "Ahrim's robetop",
                "Masori body (f)",
                "Armadyl chestplate",
                "Crystal body",
                "God d'hide body",
                "Black d'hide body",
                "Red d'hide body",
                "Blue d'hide body",
                "Green d'hide body",
                "Elite void top",
                "Void top"

            });
            items.Sort();

            body_set_1_combobox.Items.Add("None");
            body_set_2_combobox.Items.Add("None");

            foreach (var item in items)
            {
                body_set_1_combobox.Items.Add(item);
                body_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // legs
            items.AddRange(new List<string>
            {
                "Torva platelegs",
                "Bandos tassets",
                "Inquisitor's plateskirt",
                "Justiciar legguards",
                "Ancestral robe bottom",
                "Virtus robe bottom",
                "Ahrim's robeskirt",
                "Masori chaps (f)",
                "Armadyl chainskirt",
                "Crystal legs",
                "God d'hide chaps",
                "Black d'hide chaps",
                "Red d'hide chaps",
                "Blue d'hide chaps",
                "Green d'hide chaps",
                "Elite void robe",
                "Void robe"

            });
            items.Sort();

            legs_set_1_combobox.Items.Add("None");
            legs_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                legs_set_1_combobox.Items.Add(item);
                legs_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // off hand
            items.AddRange(new List<string>
            {
                "Avernic defender",
                "Dragon defender",
                "Dragonfire shield",
                "Rune defender",
                "Toktz-ket-xil",
                "Adamant defender",
                "Mithril defender",
                "Black defender",
                "Book of war",
                "Steel defender",
                "Iron defender",
                "Bronze defender",
                "Elidinis' ward (f)",
                "Elidinis' ward",
                "Arcane spirit shield",
                "Mage's book",
                "Ancient wyvern shield",
                "Malediction ward",
                "Book of darkness",
                "Tome of fire",
                "Tome of water",
                "Book of the dead",
                "Twisted buckler",
                "Dragonfire ward",
                "Odium ward",
                "Book of law",
                "Unholy book",
                "God d'hide shield",
                "Black d'hide shield",
                "Red d'hide shield",
                "Blue d'hide shield",
                "Book of balance",
                "Green d'hide shield",
                "Snakeskin shield",
                "Hard leather shield"

            });
            items.Sort();

            off_hand_set_1_combobox.Items.Add("None");
            off_hand_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                off_hand_set_1_combobox.Items.Add(item);
                off_hand_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // gloves
            items.AddRange(new List<string>
            {
                "Ferocious gloves",
                "Barrows gloves",
                "Dragon gloves",
                "Rune gloves",
                "Regen bracelet",
                "Adamant gloves",
                "Granite gloves",
                "Combat bracelet",
                "Mithril gloves",
                "Black gloves",
                "Dragonstone gauntlets",
                "Steel gloves",
                "Iron gloves",
                "Bronze gloves",
                "Tormented bracelet",
                "Zaryte vambraces",
                "God d'hide bracers",
                "Black d'hide vambraces",
                "Red d'hide vambraces",
                "Blue d'hide vambraces",
                "Green d'hide vambraces",
                "Void gloves"

            });
            items.Sort();

            gloves_set_1_combobox.Items.Add("None");
            gloves_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                gloves_set_1_combobox.Items.Add(item);
                gloves_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // boots
            items.AddRange(new List<string>
            {
                "Primordial boots",
                "Dragon boots",
                "Guardian boots",
                "Climbing boots",
                "Eternal boots",
                "Infinity boots",
                "Pegasian boots",
                "Ranger boots",
                "God d'hide boots"

            });
            items.Sort();

            boots_set_1_combobox.Items.Add("None");
            boots_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                boots_set_1_combobox.Items.Add(item);
                boots_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // rings
            items.AddRange(new List<string>
            {
                "Ultor ring",
                "Bellator ring",
                "Berserker ring (i)",
                "Treasonous ring (i)",
                "Tyrannical ring (i)",
                "Warrior ring (i)",
                "Brimstone ring",
                "Ring of shadows",
                "Magus ring",
                "Seers ring (i)",
                "Venator ring",
                "Archer ring (i)"

            });
            items.Sort();

            ring_set_1_combobox.Items.Add("None");
            ring_set_2_combobox.Items.Add("None");
            foreach (var item in items)
            {
                ring_set_1_combobox.Items.Add(item);
                ring_set_2_combobox.Items.Add(item);
            }
            items.Clear();

            // thralls
            thralls_combobox.Items.Add("None");
            thralls_combobox.Items.Add("Greater Zombie");
            thralls_combobox.Items.Add("Greater Ghost");
            thralls_combobox.Items.Add("Greater Skeleton");
            thralls_combobox.Items.Add("Superior Zombie");
            thralls_combobox.Items.Add("Superior Ghost");
            thralls_combobox.Items.Add("Superior Skeleton");
            thralls_combobox.Items.Add("Lesser Zombie");
            thralls_combobox.Items.Add("Lesser Ghost");
            thralls_combobox.Items.Add("Lesser Skeleton");

            // presets
            // gear
            presets_set_1_combobox.Items.Add("None");
            presets_set_1_combobox.Items.Add("Max melee Scythe of vitur");
            presets_set_1_combobox.Items.Add("Max melee Osmumten's fang");
            presets_set_1_combobox.Items.Add("Max mage Tumeken's shadow");
            presets_set_1_combobox.Items.Add("Max mage Sanguinesti staff");
            presets_set_1_combobox.Items.Add("Max range Twisted bow");
            presets_set_1_combobox.Items.Add("Max range Bow of faerdhinen");
            presets_set_1_combobox.Items.Add("Elite void");
            // potions
            presets_potions_combobox.Items.Add("None");
            presets_potions_combobox.Items.Add("Smelling salts");
            presets_potions_combobox.Items.Add("Overload");
            presets_potions_combobox.Items.Add("Super set");
            // prayers
            presets_prayers_combobox.Items.Add("None");
            presets_prayers_combobox.Items.Add("Bis prayers");
            presets_prayers_combobox.Items.Add("15% prayers");


            // potions and prayers
            // attack
            attack_potions_combobox.Items.Add("None");
            attack_potions_combobox.Items.Add("Smelling salts");
            attack_potions_combobox.Items.Add("Overload");
            attack_potions_combobox.Items.Add("Zamorak brew");
            attack_potions_combobox.Items.Add("Super attack");
            attack_potions_combobox.Items.Add("Attack");

            attack_prayer_combobox.Items.Add("None");
            attack_prayer_combobox.Items.Add("Piety");
            attack_prayer_combobox.Items.Add("Chivalry");
            attack_prayer_combobox.Items.Add("15%");
            attack_prayer_combobox.Items.Add("10%");
            attack_prayer_combobox.Items.Add("5%");
            // strength
            strength_potions_combobox.Items.Add("None");
            strength_potions_combobox.Items.Add("Smelling salts");
            strength_potions_combobox.Items.Add("Overload");
            strength_potions_combobox.Items.Add("Super strength");
            strength_potions_combobox.Items.Add("Strength");

            strength_prayer_combobox.Items.Add("None");
            strength_prayer_combobox.Items.Add("Piety");
            strength_prayer_combobox.Items.Add("Chivalry");
            strength_prayer_combobox.Items.Add("15%");
            strength_prayer_combobox.Items.Add("10%");
            strength_prayer_combobox.Items.Add("5%");
            // defence
            defence_potions_combobox.Items.Add("None");
            defence_potions_combobox.Items.Add("Smelling salts");
            defence_potions_combobox.Items.Add("Overload");
            defence_potions_combobox.Items.Add("Saradomin brew");
            defence_potions_combobox.Items.Add("Super defence");
            defence_potions_combobox.Items.Add("Defence");

            defence_prayer_combobox.Items.Add("None");
            defence_prayer_combobox.Items.Add("Piety");
            defence_prayer_combobox.Items.Add("Chivalry");
            defence_prayer_combobox.Items.Add("15%");
            defence_prayer_combobox.Items.Add("10%");
            defence_prayer_combobox.Items.Add("5%");
            // magic
            magic_potions_combobox.Items.Add("None");
            magic_potions_combobox.Items.Add("Smelling salts");
            magic_potions_combobox.Items.Add("Overload");
            magic_potions_combobox.Items.Add("Saturated heart");
            magic_potions_combobox.Items.Add("Imbued heart");
            magic_potions_combobox.Items.Add("Forgotten brew");
            magic_potions_combobox.Items.Add("Ancient brew");
            magic_potions_combobox.Items.Add("Magic");

            magic_prayer_combobox.Items.Add("None");
            magic_prayer_combobox.Items.Add("Augury");
            magic_prayer_combobox.Items.Add("15%");
            magic_prayer_combobox.Items.Add("10%");
            magic_prayer_combobox.Items.Add("5%");
            // range
            range_potions_combobox.Items.Add("None");
            range_potions_combobox.Items.Add("Smelling salts");
            range_potions_combobox.Items.Add("Overload");
            range_potions_combobox.Items.Add("Ranging");

            range_prayer_combobox.Items.Add("None");
            range_prayer_combobox.Items.Add("Rigour");
            range_prayer_combobox.Items.Add("15%");
            range_prayer_combobox.Items.Add("10%");
            range_prayer_combobox.Items.Add("5%");


            // Monsters, yay
            items.AddRange(new List<string>
            {
                // tob
                "The Maiden of Sugadinti",
                "Pestilent Bloat",
                "Pestilent Bloat (moving)",
                "Hard mode Pestilent Bloat",
                "Hard mode Pestilent Bloat (moving)",
                "Nylocas Vasilias (Nylo boss)",
                "Sotetseg",
                "Hard mode Sotetseg",
                "Xarpus",
                "Hard mode Xarpus",
                "Verzik vitur P1",
                "Verzik vitur P2",
                "Verzik vitur P3",
                "Nylocas Ischyros (small melee)",
                "Nylocas Ischyros (big melee)",
                "Nylocas Hagios (small mage)",
                "Nylocas Hagios (big mage)",
                "Nylocas Toxobolos (small range)",
                "Nylocas Toxobolos (big range)",
                "Nylocas Matomenos (maiden)",
                "Nylocas Matomenos (verzik)",
                "Nylocas Prinkipas (Nylo prince)",
                // toa
                "Akkha",
                "Akkha's Shadow",
                "Ba-Ba",
                "Kephri",
                "Soldier Scarab",
                "Arcane Scarab",
                "Spitting Scarab",
                "Zebak",
                "Obelisk",
                "Tumeken's Warden P2 (assumes normal npc)",
                "Elidinis' Warden P2 (assumes normal npc)",
                "Wardens Core",
                "Wardens P3",
                "Wardens P4",
                "Baboon Brawler (small melee)",
                "Baboon Brawler (big melee)",
                "Baboon Mage (small mage)",
                "Baboon Mage (big mage)",
                "Baboon Thrower (small range)",
                "Baboon Thrower (big range)",
                "Baboon Shaman",
                "Baboon Thrall",
                "Volatile Baboon",
                "Cursed Baboon",
                "Baboon (Ba-Ba)",
                // cox
                "Tekton",
                "Tekton (enraged)",
                "Ice demon",
                "Lizardman shaman (CoX)",
                "Vanguard (melee)",
                "Vanguard (mage)",
                "Vanguard (range)",
                "Vespula",
                "Abyssal portal",
                "Deathly mage",
                "Deathly ranger",
                "Guardian",
                "Vasa Nistirio",
                "Glowing crystal",
                "Skeletal Mystic",
                "Muttadile (small)",
                "Muttadile (big)",
                "Great olm (mage hand)",
                "Great olm (melee hand)",
                "Great olm (head)",
                "Scavenger",
                // fight caves
                "Tz-Kih (bat)",
                "Tz-Kek (mini blob)",
                "Tz-Kek (big blob)",
                "Tok-Xil (range)",
                "Yt-MejKot (melee)",
                "Ket-Zek (mage)",
                "TzTok-Jad",
                "Yt-HurKot (healer)",
                // inferno
                "Jal-Nib (nibbler)",
                "Jal-MejRah (bat)",
                "Jal-AkRek-Ket (melee blob)",
                "Jal-AkRek-Mej (mage blob)",
                "Jal-AkRek-Xil (range blob)",
                "Jal-Ak (blob)",
                "Jal-ImKot (melee)",
                "Jal-Xil (range)",
                "Jal-Zek (mage)",
                "JalTok-Jad",
                "Yt-HurKot (inferno jad healer)",
                "TzKal-Zuk",
                "Jal-MejJak (zuk healer)",
                // nightmare
                "Nightmare",
                "Husk",
                "Parasite",
                "Parasite (weakened)",
                "Totem",
                "Phosani's Nightmare",
                "Phosani's Husk (range)",
                "Phosani's Husk (mage)",
                "Phosani's Parasite",
                "Phosani's Parasite (weakened)",
                "Phosani's Totem",
                "Sleepwalker",
                // gwd
                "Commander Zilyana",
                "Starlight (melee)",
                "Growler (mage)",
                "Bree (range)",
                "General Graardor",
                "Sergeant Strongstack (melee)",
                "Sergeant Steelwill (mage)",
                "Sergeant Grimspike (range)",
                "Kree'arra",
                "Flight Kilisa (melee)",
                "Wingman Skree (mage)",
                "Flockleader Geerin (range)",
                "K'ril Tsutsaroth",
                "Tstanon Karlak (melee)",
                "Balfrug Kreeyath (mage)",
                "Zakl'n Gritch (range)",
                "Nex",
                "Fumus (smoke)",
                "Umbra (shadow)",
                "Cruor (blood)",
                "Glacies (ice)",
                "Blood Reaver (nex)",
                // slayer bosses
                "Grotesque Guardians (dusk 1st form)",
                "Grotesque Guardians (dusk 2nd form)",
                "Grotesque Guardians (dawn)",
                "Abyssal Sire P1-P3",
                "Abyssal Sire P4",
                "Respiratory system",
                "Kraken",
                "Cerberus",
                "Thermonuclear smoke devil",
                "Alchemical Hydra",
                "Alchemical Hydra (not weakened)",
                // wildy bosses
                "Callisto",
                "Artio",
                "Vet'ion",
                "Calvar'ion",
                "Venenatis",
                "Spindel",
                "Chaos Elemental",
                "Chaos Fanatic",
                "Crazy archaeologist",
                "Scorpia",
                "King Black Dragon",
                // barrows
                "Ahrim the Blighted",
                "Dharok the Wretched",
                "Guthan the Infested",
                "Karil the Tainted",
                "Torag the Corrupted",
                "Verac the Defiled",
                // dt 2
                "Leviathan",
                "Leviathan (During special)",
                "Vardorvis",
                "Duke Sucellus",
                "Whisperer",
                "Awakened Leviathan",
                "Awakened Leviathan (During special)",
                "Awakened Vardorvis",
                "Awakened Duke Sucellus",
                "Awakened Whisperer",
                // misc bosses
                "Vorkath",
                "Vorkath (Quickfire Barrage)",
                "Zombified Spawn",
                "Zulrah (Serpentine range)",
                "Zulrah (Magma melee)",
                "Zulrah (Tanzanite mage)",
                "Phantom Muspah (Melee)",
                "Phantom Muspah (Ranged)",
                "Phantom Muspah (Teleporting)",
                "Phantom Muspah (Post-shield)",
                "Dagannoth Rex",
                "Dagannoth Prime",
                "Dagannoth Supreme",
                "Kalphite Queen P1",
                "Kalphite Queen P2",
                "Corporeal Beast",
                "Obor",
                "Bryophyta",
                "The Mimic",
                "Hespori",
                "Giant Mole",
                "Sarachnis",
                "Deranged archaeologist",
                "Skotizo"

            });
            items.Sort();

            monsters_combobox.Items.Add("None");
            monsters_combobox.Items.Add("Combat dummy");
            foreach (var item in items)
            {
                monsters_combobox.Items.Add(item);
            }
            items.Clear();


        }
        private void Stats()
        {
            int a = 0;
            int b = 0;
            int c = 0;

            Dispatcher.Invoke(monster_stat_boosts);
            Dispatcher.Invoke(monster_stat_reduction);
            Dispatcher.Invoke(monster_max_defence_roll);

            for (int i = 0; i < 2; i++)
            {
                a = 1 * i;
                b = 4 * i;
                c = 11 * i;

                // 2 handed weapon check
                if (is_weapon_2h_array[a] == true && off_hand_name_array[a] != "None")
                {
                    off_hand_name_array[a] = "None";
                    stab_atk_array[c + 6] = 0;
                    slash_atk_array[c + 6] = 0;
                    crush_atk_array[c + 6] = 0;
                    magic_atk_array[c + 6] = 0;
                    range_atk_array[c + 6] = 0;
                    melee_str_array[c + 6] = 0;
                    range_str_array[c + 6] = 0;
                    magic_dmg_array[c + 6] = 0;
                }

                // automaticly correct ammo for weapons, as cbad dealing with incorrect ammo problem
                if (weapon_name_array[a] == "Toxic blowpipe" && ammo_name_array[a].Contains("darts") == false)
                {
                    ammo_name_array[a] = "Dragon darts";
                    stab_atk_array[c + 3] = 0;
                    slash_atk_array[c + 3] = 0;
                    crush_atk_array[c + 3] = 0;
                    magic_atk_array[c + 3] = 0;
                    range_atk_array[c + 3] = 0;
                    melee_str_array[c + 3] = 0;
                    range_str_array[c + 3] = 35;
                    magic_dmg_array[c + 3] = 0;
                }

                if (weapon_name_array[a].Contains("crossbow") == true && ammo_name_array[a].Contains("bolt") == false)
                {
                    ammo_name_array[a] = "Ruby dragon bolts (e)";
                    stab_atk_array[c + 3] = 0;
                    slash_atk_array[c + 3] = 0;
                    crush_atk_array[c + 3] = 0;
                    magic_atk_array[c + 3] = 0;
                    range_atk_array[c + 3] = 0;
                    melee_str_array[c + 3] = 0;
                    range_str_array[c + 3] = 122;
                    magic_dmg_array[c + 3] = 0;
                }

                if (weapon_name_array[a].Contains("bow") == true && weapon_name_array[a].Contains("crossbow") == false && ammo_name_array[a].Contains("arrow") == false)
                {
                    if (weapon_name_array[a] == "Bow of faerdhinen" || weapon_name_array[a] == "Crystal bow" || weapon_name_array[a] == "Webweaver bow" || weapon_name_array[a] == "Craw's bow")
                    {
                        // giga janky
                    }
                    else
                    {
                        ammo_name_array[a] = "Dragon arrows";
                        stab_atk_array[c + 3] = 0;
                        slash_atk_array[c + 3] = 0;
                        crush_atk_array[c + 3] = 0;
                        magic_atk_array[c + 3] = 0;
                        range_atk_array[c + 3] = 0;
                        melee_str_array[c + 3] = 0;
                        range_str_array[c + 3] = 60;
                        magic_dmg_array[c + 3] = 0;
                    }
                }

                if (weapon_name_array[a].Contains("ballista") == true && ammo_name_array[a].Contains("javelin") == false)
                {
                    ammo_name_array[a] = "Dragon javelins";
                    stab_atk_array[c + 3] = 0;
                    slash_atk_array[c + 3] = 0;
                    crush_atk_array[c + 3] = 0;
                    magic_atk_array[c + 3] = 0;
                    range_atk_array[c + 3] = 0;
                    melee_str_array[c + 3] = 0;
                    range_str_array[c + 3] = 150;
                    magic_dmg_array[c + 3] = 0;
                }

                // virtus robe set for ancients
                if (spell_book_array[a] == "Ancient")
                {
                    if (helmet_name_array[a] == "Virtus mask")
                    {
                        magic_dmg_array[c + 0] = 4;
                    }
                    if (body_name_array[a] == "Virtus robe top")
                    {
                        magic_dmg_array[c + 5] = 4;
                    }
                    if (legs_name_array[a] == "Virtus robe bottom")
                    {
                        magic_dmg_array[c + 7] = 4;
                    }
                }
                else
                {
                    if (helmet_name_array[a] == "Virtus mask")
                    {
                        magic_dmg_array[c + 0] = 1;
                    }
                    if (body_name_array[a] == "Virtus robe top")
                    {
                        magic_dmg_array[c + 5] = 1;
                    }
                    if (legs_name_array[a] == "Virtus robe bottom")
                    {
                        magic_dmg_array[c + 7] = 1;
                    }
                }

                // counting stats
                total_stab_atk_array[a] = stab_atk_array.Skip(c).Take(11).Sum() + stab_atk_modifier_array[a];
                total_slash_atk_array[a] = slash_atk_array.Skip(c).Take(11).Sum() + slash_atk_modifier_array[a];
                total_crush_atk_array[a] = crush_atk_array.Skip(c).Take(11).Sum() + crush_atk_modifier_array[a];
                total_range_atk_array[a] = range_atk_array.Skip(c).Take(11).Sum() + range_atk_modifier_array[a];
                total_magic_atk_array[a] = magic_atk_array.Skip(c).Take(11).Sum() + magic_atk_modifier_array[a];
                total_melee_str_array[a] = melee_str_array.Skip(c).Take(11).Sum() + melee_str_modifier_array[a];
                total_range_str_array[a] = range_str_array.Skip(c).Take(11).Sum() + range_str_modifier_array[a];
                total_magic_dmg_array[a] = magic_dmg_array.Skip(c).Take(11).Sum() + magic_dmg_modifier_array[a];

                total_stab_def_array[a] = stab_def_array.Skip(c).Take(11).Sum() + stab_def_modifier_array[a];
                total_slash_def_array[a] = slash_def_array.Skip(c).Take(11).Sum() + slash_def_modifier_array[a];
                total_crush_def_array[a] = crush_def_array.Skip(c).Take(11).Sum() + crush_def_modifier_array[a];
                total_range_def_array[a] = range_def_array.Skip(c).Take(11).Sum() + range_def_modifier_array[a];
                total_magic_def_array[a] = magic_def_array.Skip(c).Take(11).Sum() + magic_def_modifier_array[a];

                total_prayer_bonus_array[a] = prayer_bonus_array.Skip(c).Take(11).Sum();

                attack_lvl_and_pot = Math.Max(attack_pot + attack_lvl + attack_lvl_and_pot_modifier, 0);
                strength_lvl_and_pot = Math.Max(strength_pot + strength_lvl + strength_lvl_and_pot_modifier, 0);
                defence_lvl_and_pot = Math.Max(defence_pot + defence_lvl + defence_lvl_and_pot_modifier, 0);
                magic_lvl_and_pot = Math.Max(magic_pot + magic_lvl + magic_lvl_and_pot_modifier, 0);
                range_lvl_and_pot = Math.Max(range_pot + range_lvl + range_lvl_and_pot_modifier, 0);

                true_attack_lvl = Math.Floor(attack_lvl_and_pot * attack_prayer);
                true_strength_lvl = +Math.Floor(strength_lvl_and_pot * strenght_prayer);
                true_defence_lvl = Math.Floor(defence_lvl_and_pot * defence_prayer);
                true_mage_lvl = Math.Floor(magic_lvl_and_pot * magic_prayer);
                true_range_lvl = Math.Floor(range_lvl_and_pot * range_prayer);
                true_range_str = Math.Floor(range_lvl_and_pot * range_str_prayer);

                combat_lvl = (0.25 * (defence_lvl + hp_lvl + Math.Floor(prayer_lvl * 0.5)));
                combat_lvl = Math.Floor(combat_lvl + Math.Max((0.325 * (attack_lvl + strength_lvl)), Math.Max((0.325 * Math.Floor(range_lvl * 1.5)), (0.325 * Math.Floor(magic_lvl * 1.5)))));

                if (thrall_name != "None")
                {
                    Dispatcher.Invoke(thrall_dps);
                }

                if (i == 0)
                {
                    max_hit_list.Clear();
                    max_attack_roll_list.Clear();
                    hit_chance_list.Clear();
                    avg_dmg_per_attack_list.Clear();
                    overkill_avg_dmg_per_attack_list.Clear();
                    dps_list.Clear();
                    overkill_dps_list.Clear();
                    avg_hits_to_kill_list.Clear();
                    time_to_kill_list.Clear();

                    gear_set_2 = false;
                }
                else
                {
                    gear_set_2 = true;
                }

                for (int j = b; j < b + 4; j++)
                {
                    if (spell_name_array[a] == "None")
                    {
                        temp_weapon_type = weapon_type_array[j];     // stab, slash, cursh, range, mage
                        temp_weapon_stance = weapon_stance_array[j]; // accurate, aggressive, defensive, controlled, rapid, longrange, spell
                    }
                    else
                    {
                        // casting spells
                        if (weapon_name_array[a] == "Harmonised nightmare staff" && spell_book_array[a] == "Standard")
                        {
                            weapon_atk_speed_array[a] = 4;
                        }
                        else
                        {
                            weapon_atk_speed_array[a] = 5;
                        }

                        if (weapon_name_array[a] == "Tumeken's shadow" || weapon_name_array[a] == "Dawnbringer" || weapon_name_array[a] == "Sanguinesti staff" || weapon_name_array[a] == "Trident of the swamp" || weapon_name_array[a] == "Accursed sceptre" || weapon_name_array[a] == "Thammaron's sceptre" || weapon_name_array[a] == "Trident of the seas")
                        {
                            if (j == b)
                            {
                                temp_weapon_type = "cast accurate";
                                temp_weapon_stance = "spell";
                                weapon_type_array[j] = "cast accurate";
                                weapon_stance_array[j] = "spell";
                            }
                            else if (j == b + 1)
                            {
                                temp_weapon_type = "cast longrange";
                                temp_weapon_stance = "spell";
                                weapon_type_array[j] = "cast longrange";
                                weapon_stance_array[j] = "spell";
                            }
                            else
                            {
                                temp_weapon_type = "none";
                                temp_weapon_stance = "none";
                                weapon_type_array[j] = "none";
                                weapon_stance_array[j] = "none";
                            }
                        }
                        else
                        {
                            if (j == b)
                            {
                                temp_weapon_type = "cast";
                                temp_weapon_stance = "spell";
                                weapon_type_array[j] = "cast";
                                weapon_stance_array[j] = "spell";
                            }
                            else
                            {
                                temp_weapon_type = "none";
                                temp_weapon_stance = "none";
                                weapon_type_array[j] = "none";
                                weapon_stance_array[j] = "none";
                            }
                        }
                    }
                    dps_calc_fix = j;
                    Dispatcher.Invoke(dps);
                }

                if (has_special_attack_array[a] == true && spell_name_array[a] == "None")
                {
                    Dispatcher.Invoke(special_attack_modifier);
                    for (int j = b; j < 4 + b; j++)
                    {
                        corp_style_fix = j;
                        temp_weapon_type = weapon_type_array[j];
                        temp_weapon_stance = weapon_stance_array[j];
                        dps_calc_fix = j;
                        Dispatcher.Invoke(special_attack_dps);
                    }
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        max_hit_list.Add(0);
                        max_attack_roll_list.Add(0);
                        hit_chance_list.Add(0);
                        avg_dmg_per_attack_list.Add(0);
                        overkill_avg_dmg_per_attack_list.Add(0);
                        dps_list.Add(0);
                        overkill_dps_list.Add(0);
                        avg_hits_to_kill_list.Add(0);
                        time_to_kill_list.Add(0);
                    }

                }

                if (multiple_calcs == true)
                {
                    i = 2; // aka dont do second run of dps calc for 2nd set if doing multi calcs
                }

            }


            Dispatcher.Invoke(UpdateUI);
            if (multiple_calcs == false)
            {
                Dispatcher.Invoke(monster_max_hit_and_atk_roll);
                Dispatcher.Invoke(monster_hit_chance_and_avg_dmg);
                Dispatcher.Invoke(coloring_menu);
            }

        }
        private void monster_stat_boosts()
        {
            monster_boosted_atk_lvl = monster_combat_atk_lvl;
            monster_boosted_str_lvl = monster_combat_str_lvl;
            monster_boosted_def_lvl = monster_combat_def_lvl;
            monster_boosted_magic_lvl = monster_combat_magic_lvl;
            monster_boosted_range_lvl = monster_combat_range_lvl;
            monster_boosted_hp_lvl = monster_combat_hp_lvl;

            double atk_modifier = 1;
            double str_modifier = 1;
            double def_modifier = 1;
            double magic_modifier = 1;
            double range_modifier = 1;
            double hp_modifier = 1;

            // tob
            if (monster_is_in_tob == true && monster_name != "Combat dummy")
            {
                if (team_size <= 3)
                {
                    hp_modifier = 0.75;
                }
                if (team_size == 4)
                {
                    hp_modifier = 0.875;
                }
                monster_boosted_hp_lvl = Math.Round(monster_combat_hp_lvl * hp_modifier);
            }

            // toa
            if (monster_is_in_toa == true && monster_name != "Combat dummy")
            {
                // Raid lvl
                if (monster_name == "Wardens Core")
                {
                    hp_modifier = (1 + toa_raid_lvl * 0.001);
                }
                else
                {
                    hp_modifier = (1 + toa_raid_lvl * 0.004);
                }

                // Path lvl
                if (monster_name == "Akkha" || monster_name == "Ba-Ba" || monster_name == "Kephri" || monster_name == "Zebak" || monster_name == "Arcane Scarab" || monster_name == "Spitting Scarab" || monster_name == "Soldier Scarab")
                {
                    if (toa_path_lvl > 0)
                    {
                        hp_modifier = hp_modifier * (1.03 + 0.05 * toa_path_lvl);
                    }
                }

                // Team size
                if (team_size == 2)
                {
                    hp_modifier = hp_modifier * 1.9;
                }
                if (team_size == 3)
                {
                    hp_modifier = hp_modifier * 2.8;
                }
                if (team_size > 3)
                {
                    hp_modifier = hp_modifier * (2.8 + 0.6 * (Math.Min(8, team_size) - 3));
                }

                // odd rounding what ever
                if (monster_name == "Akkha" || monster_name == "Ba-Ba" || monster_name == "Zebak" || monster_name == "Arcane Scarab" || monster_name == "Spitting Scarab" || monster_name == "Soldier Scarab" || monster_name == "Obelisk" || monster_name == "Wardens Core" || monster_name == "Wardens P3" || monster_name == "Wardens P4")
                {
                    monster_boosted_hp_lvl = (Math.Round((monster_combat_hp_lvl * hp_modifier) / 10)) * 10;
                }
                else if (monster_name == "Kephri" || monster_name == "Wardens P2" || monster_name == "Akkha's Shadow")
                {
                    monster_boosted_hp_lvl = (Math.Floor((monster_combat_hp_lvl * hp_modifier) / 5)) * 5;
                }
                // baboons
                else
                {
                    monster_boosted_hp_lvl = Math.Floor(monster_combat_hp_lvl * hp_modifier);
                }
            }

            // cox
            if (monster_is_in_cox == true && monster_name != "Combat dummy")
            {
                // mining lvl modifier
                if (monster_name == "Guardian")
                {
                    hp_modifier = monster_combat_hp_lvl - 99 + mining_lvl;
                    monster_boosted_hp_lvl = Math.Floor(monster_boosted_hp_lvl - (monster_boosted_hp_lvl - hp_modifier));
                }
                // combat lvl modifier
                if (monster_name.Contains("Great olm") == true)
                {
                    atk_modifier = 1;
                    str_modifier = 1;
                    def_modifier = 1;
                    magic_modifier = 1;
                    range_modifier = 1;
                    hp_modifier = 1;
                }
                else
                {
                    atk_modifier = ((Math.Floor(hp_lvl * 4 / 9)) + 55) / 99;
                    str_modifier = atk_modifier;
                    def_modifier = atk_modifier;
                    magic_modifier = atk_modifier;
                    range_modifier = atk_modifier;
                    hp_modifier = combat_lvl / 126;
                }

                monster_boosted_atk_lvl = Math.Floor(monster_boosted_atk_lvl * atk_modifier);
                monster_boosted_str_lvl = Math.Floor(monster_boosted_str_lvl * str_modifier);
                monster_boosted_def_lvl = Math.Floor(monster_boosted_def_lvl * def_modifier);
                monster_boosted_magic_lvl = Math.Floor(monster_boosted_magic_lvl * magic_modifier);
                monster_boosted_range_lvl = Math.Floor(monster_boosted_range_lvl * range_modifier);
                monster_boosted_hp_lvl = Math.Floor(monster_boosted_hp_lvl * hp_modifier);
                // party size modifier
                if (monster_name.Contains("Great olm") == true)
                {
                    hp_modifier = (team_size - 3 * Math.Floor(team_size / 8) + 1) / 2;
                }
                else if (monster_name == "Scavenger")
                {
                    hp_modifier = 1;
                }
                else
                {
                    hp_modifier = (1 + Math.Floor(team_size / 2));
                }

                if (monster_name == "Abyssal portal")
                {
                    def_modifier = (Math.Floor(Math.Sqrt(team_size - 1)) + Math.Floor((team_size - 1) * 7 / 10) + 100) / 100;
                    atk_modifier = def_modifier;
                    str_modifier = def_modifier;
                    magic_modifier = def_modifier;
                    range_modifier = def_modifier;
                }
                else
                {
                    def_modifier = (Math.Floor(Math.Sqrt(team_size - 1)) + Math.Floor((team_size - 1) * 7 / 10) + 100) / 100;
                    atk_modifier = (Math.Floor(Math.Sqrt(team_size - 1)) * 7 + (team_size - 1) + 100) / 100;
                    str_modifier = atk_modifier;
                    magic_modifier = atk_modifier;
                    range_modifier = atk_modifier;
                }

                if (monster_boosted_atk_lvl == 1)
                {
                    monster_boosted_atk_lvl = 1;
                }
                else
                {
                    monster_boosted_atk_lvl = Math.Floor(monster_boosted_atk_lvl * atk_modifier);
                }
                if (monster_boosted_str_lvl == 1)
                {
                    monster_boosted_str_lvl = 1;
                }
                else
                {
                    monster_boosted_str_lvl = Math.Floor(monster_boosted_str_lvl * str_modifier);
                }
                if (monster_boosted_magic_lvl == 1)
                {
                    monster_boosted_magic_lvl = 1;
                }
                else
                {
                    monster_boosted_magic_lvl = Math.Floor(monster_boosted_magic_lvl * magic_modifier);
                }
                if (monster_boosted_range_lvl == 1)
                {
                    monster_boosted_range_lvl = 1;
                }
                else
                {
                    monster_boosted_range_lvl = Math.Floor(monster_boosted_range_lvl * range_modifier);
                }
                monster_boosted_def_lvl = Math.Floor(monster_boosted_def_lvl * def_modifier);
                monster_boosted_hp_lvl = Math.Floor(monster_boosted_hp_lvl * hp_modifier);
                // CM scaling
                if (CM_cox_checkbox.IsChecked == true)
                {
                    if (monster_name.Contains("Great olm") == true || monster_name == "Glowing crystal")
                    {
                        hp_modifier = 1;
                    }
                    else
                    {

                        hp_modifier = 1.5;
                    }
                    atk_modifier = 1.5;
                    str_modifier = 1.5;
                    range_modifier = 1.5;
                    if (monster_name.Contains("Tekton") == true)
                    {
                        magic_modifier = 1.2;
                    }
                    else
                    {
                        magic_modifier = 1.5;
                    }
                    if (monster_name.Contains("Tekton") == true)
                    {
                        def_modifier = 1.2;
                    }
                    else
                    {
                        def_modifier = 1.5;
                    }
                    if (monster_name == "Gloving crystal")
                    {
                        def_modifier = 1;
                    }

                    monster_boosted_atk_lvl = Math.Floor(monster_boosted_atk_lvl * atk_modifier);
                    monster_boosted_str_lvl = Math.Floor(monster_boosted_str_lvl * str_modifier);
                    monster_boosted_def_lvl = Math.Floor(monster_boosted_def_lvl * def_modifier);
                    monster_boosted_magic_lvl = Math.Floor(monster_boosted_magic_lvl * magic_modifier);
                    monster_boosted_range_lvl = Math.Floor(monster_boosted_range_lvl * range_modifier);
                    monster_boosted_hp_lvl = Math.Floor(monster_boosted_hp_lvl * hp_modifier);
                }
            }
        }
        private void monster_stat_reduction()
        {
            monster_reduced_atk_lvl = monster_boosted_atk_lvl;
            monster_reduced_str_lvl = monster_boosted_str_lvl;
            monster_reduced_def_lvl = monster_boosted_def_lvl;
            monster_reduced_magic_lvl = monster_boosted_magic_lvl;
            monster_reduced_range_lvl = monster_boosted_range_lvl;
            monster_reduced_hp_lvl = monster_boosted_hp_lvl;


            monster_reduced_hp_lvl = monster_reduced_hp_lvl - dmg_delt;
            if (monster_reduced_hp_lvl < 0)
            {
                monster_reduced_hp_lvl = 0;
            }


            // cant reduce stats and vardovis
            if (monster_name == "Verzik vitur P1" || monster_name == "Verzik vitur P2" || monster_name == "Verzik vitur P3" || monster_name == "Vardorvis" || monster_name == "Awakened Leviathan" || monster_name == "Awakened Vardorvis" || monster_name == "Awakened Duke Sucellus" || monster_name == "Awakened Whisperer")
            {
                monster_reduced_atk_lvl = monster_boosted_atk_lvl;
                monster_reduced_str_lvl = monster_boosted_str_lvl;
                monster_reduced_def_lvl = monster_boosted_def_lvl;
                monster_reduced_magic_lvl = monster_boosted_magic_lvl;
                monster_reduced_range_lvl = monster_boosted_range_lvl;
                if (monster_name == "Vardorvis")
                {
                    monster_reduced_def_lvl = monster_boosted_def_lvl - Math.Floor((monster_boosted_hp_lvl - monster_reduced_hp_lvl) / 10.0); // 1 def lost for 10 hp
                    monster_reduced_str_lvl = monster_boosted_str_lvl + Math.Floor((monster_boosted_hp_lvl - monster_reduced_hp_lvl) / (70.0 / 9.0));  // 1 str gained for 7,7 hp
                }
                if (monster_name == "Awakened Vardorvis")
                {
                    monster_reduced_def_lvl = monster_boosted_def_lvl - Math.Floor((monster_boosted_hp_lvl - monster_reduced_hp_lvl) / (1400.0 / 87.0)); // 1 def lost for 16 hp
                    monster_reduced_str_lvl = monster_boosted_str_lvl + Math.Floor((monster_boosted_hp_lvl - monster_reduced_hp_lvl) / (1400.0 / 131.0)); // 1 str gained for 10,6 hp
                }

            }
            // normal stat reduction
            else
            {
                double curse_spell_effectiviness = 0.1;
                if (tome_of_water_checkbox.IsChecked == true)
                {
                    curse_spell_effectiviness = 0.15;
                }
                // vulnerability
                if (vulnerability_checkbox.IsChecked == true)
                {
                    monster_reduced_def_lvl = monster_reduced_def_lvl - Math.Floor(monster_reduced_def_lvl * curse_spell_effectiviness);
                }
                // enfeeble
                if (enfeeble_checkbox.IsChecked == true)
                {
                    monster_reduced_str_lvl = monster_reduced_str_lvl - Math.Floor(monster_reduced_str_lvl * curse_spell_effectiviness);
                }
                // stun
                if (stun_checkbox.IsChecked == true)
                {
                    monster_reduced_atk_lvl = monster_reduced_atk_lvl - Math.Floor(monster_reduced_atk_lvl * curse_spell_effectiviness);
                }

                // accused secptre
                if (accursed_secptre_checkbox.IsChecked == true)
                {
                    monster_reduced_def_lvl = monster_boosted_def_lvl - Math.Floor(monster_boosted_def_lvl * 0.15);
                    monster_reduced_magic_lvl = monster_boosted_magic_lvl - Math.Floor(monster_boosted_magic_lvl * 0.15);
                }

                // arlicht hits
                if (monster_is_demon == true)
                {
                    monster_reduced_atk_lvl = monster_reduced_atk_lvl - Math.Floor((monster_boosted_atk_lvl * 0.1) * arclight_hits);
                    monster_reduced_str_lvl = monster_reduced_str_lvl - Math.Floor((monster_boosted_str_lvl * 0.1) * arclight_hits);
                    monster_reduced_def_lvl = monster_reduced_def_lvl - Math.Floor((monster_boosted_def_lvl * 0.1) * arclight_hits);
                }
                else
                {
                    monster_reduced_atk_lvl = monster_reduced_atk_lvl - Math.Floor((monster_boosted_atk_lvl * 0.05) * arclight_hits);
                    monster_reduced_str_lvl = monster_reduced_str_lvl - Math.Floor((monster_boosted_str_lvl * 0.05) * arclight_hits);
                    monster_reduced_def_lvl = monster_reduced_def_lvl - Math.Floor((monster_boosted_def_lvl * 0.05) * arclight_hits);
                }

                if (monster_reduced_atk_lvl < 1)
                {
                    monster_reduced_atk_lvl = 0;
                }
                if (monster_reduced_str_lvl < 1)
                {
                    monster_reduced_str_lvl = 0;
                }
                if (monster_reduced_def_lvl < 1)
                {
                    monster_reduced_def_lvl = 0;
                }

                // dwh hits
                if (dwh_hits != 0)
                {
                    for (int i = 0; i < dwh_hits; i++)
                    {
                        monster_reduced_def_lvl = monster_reduced_def_lvl - Math.Floor(monster_reduced_def_lvl * 0.3);
                    }
                }

                // bgs dmg
                double temp_monster_reduced_lvl;
                double temp_bgs_dmg = bgs_dmg;
                // defence
                temp_monster_reduced_lvl = monster_reduced_def_lvl;
                monster_reduced_def_lvl = monster_reduced_def_lvl - temp_bgs_dmg;

                // minimum defence
                if (monster_reduced_def_lvl < monster_defence_cap)
                {
                    monster_reduced_def_lvl = monster_defence_cap;
                }

                // strength
                if (monster_reduced_def_lvl < 1)
                {
                    monster_reduced_def_lvl = 0;
                    temp_bgs_dmg = temp_bgs_dmg - temp_monster_reduced_lvl;

                    temp_monster_reduced_lvl = monster_reduced_str_lvl;
                    monster_reduced_str_lvl = monster_reduced_str_lvl - temp_bgs_dmg;
                    // attack
                    if (monster_reduced_str_lvl < 0)
                    {
                        monster_reduced_str_lvl = 0;
                        temp_bgs_dmg = temp_bgs_dmg - temp_monster_reduced_lvl;

                        temp_monster_reduced_lvl = monster_reduced_atk_lvl;
                        monster_reduced_atk_lvl = monster_reduced_atk_lvl - temp_bgs_dmg;
                        // magic
                        if (monster_reduced_atk_lvl < 0)
                        {
                            monster_reduced_atk_lvl = 0;
                            temp_bgs_dmg = temp_bgs_dmg - temp_monster_reduced_lvl;

                            temp_monster_reduced_lvl = monster_reduced_magic_lvl;
                            monster_reduced_magic_lvl = monster_reduced_magic_lvl - temp_bgs_dmg;
                            // range
                            if (monster_reduced_magic_lvl < 0)
                            {
                                monster_reduced_magic_lvl = 0;
                                temp_bgs_dmg = temp_bgs_dmg - temp_monster_reduced_lvl;

                                monster_reduced_range_lvl = monster_reduced_range_lvl - temp_bgs_dmg;
                                if (monster_reduced_range_lvl < 0)
                                {
                                    monster_reduced_range_lvl = 0;
                                }
                            }
                        }
                    }
                }
            }

        }
        private void monster_max_defence_roll()
        {
            monster_max_defensive_roll_stab = (monster_reduced_def_lvl + 9) * (monster_defensive_stab + 64);
            monster_max_defensive_roll_slash = (monster_reduced_def_lvl + 9) * (monster_defensive_slash + 64);
            monster_max_defensive_roll_crush = (monster_reduced_def_lvl + 9) * (monster_defensive_crush + 64);
            monster_max_defensive_roll_magic = (monster_reduced_magic_lvl + 9) * (monster_defensive_magic + 64);
            monster_max_defensive_roll_range = (monster_reduced_def_lvl + 9) * (monster_defensive_range + 64);

            if (monster_is_in_toa == true)
            {
                monster_max_defensive_roll_stab = Math.Floor(monster_max_defensive_roll_stab * (1 + toa_raid_lvl * 0.004));
                monster_max_defensive_roll_slash = Math.Floor(monster_max_defensive_roll_slash * (1 + toa_raid_lvl * 0.004));
                monster_max_defensive_roll_crush = Math.Floor(monster_max_defensive_roll_crush * (1 + toa_raid_lvl * 0.004));
                monster_max_defensive_roll_magic = Math.Floor(monster_max_defensive_roll_magic * (1 + toa_raid_lvl * 0.004));
                monster_max_defensive_roll_range = Math.Floor(monster_max_defensive_roll_range * (1 + toa_raid_lvl * 0.004));
            }

            // the odd "mage" defence rolls
            if (monster_name == "Ice demon" || monster_name == "Verzik vitur P1" || monster_name == "Verzik vitur P2" || monster_name == "Verzik vitur P3" || monster_name == "Baboon Brawler (small)" || monster_name == "Baboon Brawler (big)")
            {
                monster_max_defensive_roll_magic = (monster_reduced_def_lvl + 9) * (monster_defensive_magic + 64);
            }

        }
        private void dps()
        {
            int i = 0;

            if (gear_set_2 == true)
            {
                i = 1;
                if (custom_attack_speed_2_checkbox.IsChecked == true)
                {
                    temp_weapon_attack_speed = custom_attack_speed_array[i];
                }
                else
                {
                    temp_weapon_attack_speed = weapon_atk_speed_array[i];
                }
            }
            else
            {
                if (custom_attack_speed_checkbox.IsChecked == true)
                {
                    temp_weapon_attack_speed = custom_attack_speed_array[i];
                }
                else
                {
                    temp_weapon_attack_speed = weapon_atk_speed_array[i];
                }
            }

            Dispatcher.Invoke(attack_styles);

            if (temp_weapon_type != "none" && temp_weapon_stance != "none")
            {
                Dispatcher.Invoke(max_hit_and_attack_roll);
                Dispatcher.Invoke(hit_chance);
                if (temp_max_hit > -1)
                {
                    if (weapon_name_array[i].Contains("crossbow") == true && ammo_name_array[i].Contains("bolts (e)") == true)
                    {
                        Dispatcher.Invoke(bolt_proc_effects);
                        switch (ammo_name_array[i])
                        {
                            case "Dragonstone dragon bolts (e)":
                            case "Dragonstone bolts (e)":
                            case "Onyx dragon bolts (e)":
                            case "Onyx bolts (e)": // bolt needs to hit to get bolt proc effect
                                Dispatcher.Invoke(immunities_and_resistances);
                                is_immune_array[i] = temp_immune;
                                Dispatcher.Invoke(average_dmg);
                                double temp_temp_max_hit = temp_max_hit;
                                double temp_temp_avg_dmg = temp_avg_dmg_per_attack;
                                temp_max_hit = bolt_proc_dmg;
                                Dispatcher.Invoke(immunities_and_resistances);
                                Dispatcher.Invoke(average_dmg);

                                bolt_normal_dmg_array[dps_calc_fix] = temp_temp_max_hit;
                                bolt_proc_dmg_array[dps_calc_fix] = temp_max_hit;
                                bolt_proc_chance_array[dps_calc_fix] = bolt_proc_chance;
                                temp_max_hit = ((100 - bolt_proc_chance) / 100 * temp_temp_max_hit) + (bolt_proc_chance / 100 * temp_max_hit);
                                temp_avg_dmg_per_attack = ((100 - bolt_proc_chance) / 100 * temp_temp_avg_dmg) + (bolt_proc_chance / 100 * temp_avg_dmg_per_attack);

                                break;
                            default: // bypasses accuracy check
                                Dispatcher.Invoke(immunities_and_resistances);
                                is_immune_array[i] = temp_immune;
                                Dispatcher.Invoke(average_dmg);
                                temp_temp_max_hit = temp_max_hit;
                                temp_temp_avg_dmg = temp_avg_dmg_per_attack;
                                double temp_temp_hit_chance = temp_hit_chance;
                                if (ammo_name_array[i] == "Ruby dragon bolts (e)" || ammo_name_array[i] == "Ruby bolts (e)")
                                {
                                    temp_temp_avg_dmg = temp_temp_avg_dmg / 2;
                                }
                                temp_max_hit = bolt_proc_dmg;
                                temp_hit_chance = 1;
                                Dispatcher.Invoke(immunities_and_resistances);
                                Dispatcher.Invoke(average_dmg);

                                bolt_normal_dmg_array[dps_calc_fix] = temp_temp_max_hit;
                                bolt_proc_dmg_array[dps_calc_fix] = temp_max_hit;
                                bolt_proc_chance_array[dps_calc_fix] = bolt_proc_chance;

                                temp_hit_chance = temp_temp_hit_chance;
                                temp_max_hit = ((100 - bolt_proc_chance) / 100 * temp_temp_max_hit) + (bolt_proc_chance / 100 * temp_max_hit);
                                temp_avg_dmg_per_attack = ((100 - bolt_proc_chance) / 100 * temp_temp_avg_dmg) + (bolt_proc_chance / 100 * temp_avg_dmg_per_attack);
                                break;
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(immunities_and_resistances);
                        is_immune_array[i] = temp_immune;
                        Dispatcher.Invoke(average_dmg);
                    }

                    if (overkill_checkbox.IsChecked == true && temp_max_hit > -1)
                    {
                        Dispatcher.Invoke(overkill);
                    }
                    else
                    {
                        temp_avg_hits_to_kill = 0;
                    }
                }
                else
                {
                    temp_avg_dmg_per_attack = 0;
                    temp_avg_hits_to_kill = 0;

                    scythe_hitsplat_1 = 0;
                    scythe_hitsplat_2 = 0;
                    scythe_hitsplat_3 = 0;

                    osmumtens_fang_max_hit = 0;
                    osmumtens_fang_min_hit = 0;
                }

                if (temp_hit_chance > 0)
                {
                    if (temp_weapon_stance != "spell")
                    {
                        switch (weapon_name_array[i])
                        {
                            case "Scythe of vitur":
                                if (monster_size == 1)
                                {
                                    max_hit_list.Add(temp_max_hit);
                                    scythe_hitsplat_1_array[dps_calc_fix] = temp_max_hit;
                                    scythe_hitsplat_2_array[dps_calc_fix] = 0;
                                    scythe_hitsplat_3_array[dps_calc_fix] = 0;
                                }
                                else if (monster_size == 2)
                                {
                                    temp_max_hit = scythe_hitsplat_1 + scythe_hitsplat_2;
                                    max_hit_list.Add(temp_max_hit);
                                    scythe_hitsplat_1_array[dps_calc_fix] = scythe_hitsplat_1;
                                    scythe_hitsplat_2_array[dps_calc_fix] = scythe_hitsplat_2;
                                    scythe_hitsplat_3_array[dps_calc_fix] = 0;
                                }
                                else
                                {
                                    temp_max_hit = scythe_hitsplat_1 + scythe_hitsplat_2 + scythe_hitsplat_3;
                                    max_hit_list.Add(temp_max_hit);
                                    scythe_hitsplat_1_array[dps_calc_fix] = scythe_hitsplat_1;
                                    scythe_hitsplat_2_array[dps_calc_fix] = scythe_hitsplat_2;
                                    scythe_hitsplat_3_array[dps_calc_fix] = scythe_hitsplat_3;
                                }
                                break;
                            case "Osmumten's fang":
                                max_hit_list.Add(temp_max_hit);
                                osmumtens_fang_min_hit_array[dps_calc_fix] = osmumtens_fang_min_hit;
                                osmumtens_fang_max_hit_array[dps_calc_fix] = osmumtens_fang_max_hit;
                                break;
                            case "Dark bow":
                                max_hit_list.Add(temp_max_hit * 2);
                                temp_avg_dmg_per_attack = temp_avg_dmg_per_attack * 2;
                                break;
                            case "Venator bow":
                                if (venator_1st_bounce_checkbox.IsChecked == true)
                                {
                                    temp_max_hit += Math.Floor(temp_max_hit / 100.0 * 66);
                                }
                                if (venator_2nd_bounce_checkbox.IsChecked == true)
                                {
                                    temp_max_hit += Math.Floor(temp_max_hit / 100.0 * 66);
                                }
                                max_hit_list.Add(temp_max_hit);
                                break;
                            default:
                                max_hit_list.Add(temp_max_hit);
                                break;

                        }
                    }
                    else
                    {
                        max_hit_list.Add(temp_max_hit);
                    }

                    max_attack_roll_list.Add(temp_max_attack_roll);

                    hit_chance_list.Add(Math.Round(temp_hit_chance, 15) * 100);

                    avg_dmg_per_attack_list.Add(Math.Round(temp_avg_dmg_per_attack, 15));

                    if (temp_avg_hits_to_kill == 0)
                    {
                        overkill_avg_dmg_per_attack_list.Add(0);
                    }
                    else
                    {
                        overkill_avg_dmg_per_attack_list.Add(Math.Round(monster_reduced_hp_lvl / temp_avg_hits_to_kill, 15));
                    }
                    
                    if (is_immune_array[i] == true || temp_max_hit == 0)
                    {
                        dps_list.Add(0);
                        overkill_dps_list.Add(0);
                        time_to_kill_list.Add(0);
                        avg_hits_to_kill_list.Add(0);
                    }
                    else
                    {
                        avg_hits_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill, 15));

                        if (temp_weapon_stance == "rapid" || temp_weapon_stance == "medium fuse")
                        {
                            dps_list.Add(Math.Round(temp_avg_dmg_per_attack / ((temp_weapon_attack_speed - 1) * 0.6), 15));
                            if (temp_avg_hits_to_kill == 0)
                            {
                                overkill_dps_list.Add(0);
                                time_to_kill_list.Add(0);
                            }
                            else
                            {
                                overkill_dps_list.Add(Math.Round(monster_reduced_hp_lvl / (temp_avg_hits_to_kill * ((temp_weapon_attack_speed - 1) * 0.6)), 15));
                                time_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill * ((temp_weapon_attack_speed - 1) * 0.6), 15));
                            }

                        }
                        else
                        {
                            dps_list.Add(Math.Round(temp_avg_dmg_per_attack / (temp_weapon_attack_speed * 0.6), 15));
                            if (temp_avg_hits_to_kill == 0)
                            {
                                overkill_dps_list.Add(0);
                                time_to_kill_list.Add(0);
                            }
                            else
                            {
                                overkill_dps_list.Add(Math.Round(monster_reduced_hp_lvl / (temp_avg_hits_to_kill * (temp_weapon_attack_speed * 0.6)), 15));
                                time_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill * (temp_weapon_attack_speed * 0.6), 15));
                            }

                        }
                    }
                                       
                }
                else
                {
                    max_hit_list.Add(0);
                    max_attack_roll_list.Add(temp_max_attack_roll);
                    hit_chance_list.Add(0);
                    avg_dmg_per_attack_list.Add(0);
                    overkill_avg_dmg_per_attack_list.Add(0);
                    dps_list.Add(0);
                    overkill_dps_list.Add(0);
                    avg_hits_to_kill_list.Add(0);
                    time_to_kill_list.Add(0);

                    scythe_hitsplat_1_array[dps_calc_fix] = 0;
                    scythe_hitsplat_2_array[dps_calc_fix] = 0;
                    scythe_hitsplat_3_array[dps_calc_fix] = 0;

                    osmumtens_fang_min_hit_array[dps_calc_fix] = 0;
                    osmumtens_fang_max_hit_array[dps_calc_fix] = 0;
                }
            }
            else
            {
                max_hit_list.Add(0);
                max_attack_roll_list.Add(0);
                hit_chance_list.Add(0);
                avg_dmg_per_attack_list.Add(0);
                overkill_avg_dmg_per_attack_list.Add(0);
                dps_list.Add(0);
                overkill_dps_list.Add(0);
                avg_hits_to_kill_list.Add(0);
                time_to_kill_list.Add(0);

                bolt_normal_dmg_array[dps_calc_fix] = 0;
                bolt_proc_dmg_array[dps_calc_fix] = 0;
                bolt_proc_chance_array[dps_calc_fix] = 0;
            }
        }
        private void attack_styles()
        {
            style_bonus_attack_array[dps_calc_fix] = 0;
            style_bonus_str_array[dps_calc_fix] = 0;
            style_bonus_def_array[dps_calc_fix] = 0;
            style_bonus_magic_array[dps_calc_fix] = 0;
            style_bonus_range_array[dps_calc_fix] = 0;

            switch (temp_weapon_type)
            {
                case "ranged":
                    switch (temp_weapon_stance)
                    {
                        case "short fuse":
                        case "accurate":
                            style_bonus_range_array[dps_calc_fix] = 3;
                            break;
                        case "medium fuse":
                        case "rapid":
                            // no stat bonuces, just rapid
                            break;
                        case "long fuse":
                        case "longrange":
                            style_bonus_def_array[dps_calc_fix] = 3;
                            break;
                        default:
                            MessageBox.Show("Incorrect weapon stance range, gl");
                            break;
                    }
                    break;
                case "magic":
                    switch (temp_weapon_stance)
                    {
                        case "accurate":
                            style_bonus_magic_array[dps_calc_fix] = 2;
                            break;
                        case "longrange":
                            style_bonus_def_array[dps_calc_fix] = 3;
                            break;
                        default:
                            MessageBox.Show("Incorrect weapon stance mage, gl");
                            break;
                    }
                    break;
                case "cast":
                case "cast longrange":
                    style_bonus_def_array[dps_calc_fix] = 3;
                    break;
                case "cast accurate":
                    style_bonus_magic_array[dps_calc_fix] = 2;
                    break;
                case "slash":
                case "stab":
                case "crush":
                    switch (temp_weapon_stance)
                    {
                        case "accurate":
                            style_bonus_attack_array[dps_calc_fix] = 3;
                            break;
                        case "aggressive":
                            style_bonus_str_array[dps_calc_fix] = 3;
                            break;
                        case "defensive":
                            style_bonus_def_array[dps_calc_fix] = 3;
                            break;
                        case "controlled":
                            style_bonus_attack_array[dps_calc_fix] = 1;
                            style_bonus_str_array[dps_calc_fix] = 1;
                            style_bonus_def_array[dps_calc_fix] = 1;
                            break;
                        default:
                            MessageBox.Show("Incorrect weapon stance melee, gl");
                            break;
                    }
                    break;
                case "none":
                    // none bonuses
                    break;
                default:
                    MessageBox.Show("Incorrect weapon type, gl");
                    break;
            }
        }
        private void max_hit_and_attack_roll()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 1;
                j = 11;
            }

            double gear_bonus_melee = 1;
            double gear_bonus_range_and_mage = 1;
            if (helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true)
            {
                gear_bonus_melee = 7.0 / 6.0;
                gear_bonus_range_and_mage = 1.15;
            }
            if (amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true)
            {
                gear_bonus_melee = 1.2;
                gear_bonus_range_and_mage = 1.2;
            }
            if (weapon_name_array[i] == "Dragon hunter lance" && monster_is_dragon == true)
            {
                gear_bonus_melee += 0.2;
            }

            bool elite_void = false;
            bool normal_void = false;
            if (helmet_name_array[i] == "Void helmet" && body_name_array[i] == "Elite void top" && legs_name_array[i] == "Elite void robe" && gloves_name_array[i] == "Void gloves")
            {
                elite_void = true;
            }
            if (helmet_name_array[i] == "Void helmet" && (body_name_array[i] == "Void top" || body_name_array[i] == "Elite void top") && (legs_name_array[i] == "Void robe" || legs_name_array[i] == "Elite void robe") && gloves_name_array[i] == "Void gloves" && elite_void == false)
            {
                normal_void = true;
            }

            switch (temp_weapon_type)
            {
                case "ranged":
                    // check to not count ammo range str for weapons that dont use ammo
                    double temp_ranged_str = total_range_str_array[i];
                    if (weapon_name_array[i] == "Bow of faerdhinen" || weapon_name_array[i] == "Crystal bow" || weapon_name_array[i] == "Webweaver bow" || weapon_name_array[i] == "Craw's bow" || weapon_name_array[i].Contains("chinchompa") == true || weapon_name_array[i].Contains("dart") == true || weapon_name_array[i].Contains("knife") == true || weapon_name_array[i].Contains("thrownaxe") == true)
                    {
                        temp_ranged_str = total_range_str_array[i] - range_str_array[j + 3];
                    }

                    // soft max hit calc before specific scenarios
                    temp_effective_range_str = true_range_str + style_bonus_range_array[dps_calc_fix] + 8;
                    if (elite_void == true)
                    {
                        temp_effective_range_str = Math.Floor(temp_effective_range_str * 1.125);
                    }
                    if (normal_void == true)
                    {
                        temp_effective_range_str = Math.Floor(temp_effective_range_str * 1.1);
                    }
                    temp_max_hit = Math.Floor((temp_effective_range_str * (temp_ranged_str + 64) / 640) + 0.5);

                    // soft max attack roll calc before specific scenarios
                    temp_effective_range_lvl = true_range_lvl + style_bonus_range_array[dps_calc_fix] + 8;
                    if (elite_void == true || normal_void == true)
                    {
                        temp_effective_range_lvl = Math.Floor(temp_effective_range_lvl * 1.1);
                    }
                    temp_max_attack_roll = temp_effective_range_lvl * (total_range_atk_array[i] + 64);

                    switch (weapon_name_array[i])
                    {
                        case "Twisted bow":
                            double twisted_bow_modifier = Math.Max(monster_reduced_magic_lvl, monster_aggressive_magic);
                            double twisted_bow_dmg_modifier = 0;
                            double twisted_bow_accuracy_modifier = 0;
                            if (monster_is_in_cox == true)
                            {
                                if (twisted_bow_modifier > 350)
                                {
                                    twisted_bow_modifier = 350;
                                }
                            }
                            else
                            {
                                if (twisted_bow_modifier > 250)
                                {
                                    twisted_bow_modifier = 250;
                                }

                            }

                            twisted_bow_accuracy_modifier = Math.Floor((140 + ((30 * twisted_bow_modifier / 10) - 10) / 100) - ((Math.Pow((3 * twisted_bow_modifier / 10) - 100, 2)) / 100));
                            if (twisted_bow_accuracy_modifier > 140)
                            {
                                twisted_bow_accuracy_modifier = 140;
                            }
                            twisted_bow_dmg_modifier = Math.Floor((250 + ((30 * twisted_bow_modifier / 10) - 14) / 100) - ((Math.Pow((3 * twisted_bow_modifier / 10) - 140, 2)) / 100));
                            if (twisted_bow_dmg_modifier > 250)
                            {
                                twisted_bow_dmg_modifier = 250;
                            }


                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                            temp_max_hit = Math.Floor(temp_max_hit * (twisted_bow_dmg_modifier / 100));


                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * gear_bonus_range_and_mage);
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * (twisted_bow_accuracy_modifier / 100));
                            break;
                        case "Bow of faerdhinen":
                            double crystal_bonus_dmg = 1;
                            double crystal_bonus_accuracy = 1;
                            if (helmet_name_array[i] == "Crystal helm")
                            {
                                crystal_bonus_dmg = crystal_bonus_dmg + 0.025;
                                crystal_bonus_accuracy = crystal_bonus_accuracy + 0.05;
                            }
                            if (body_name_array[i] == "Crystal body")
                            {
                                crystal_bonus_dmg = crystal_bonus_dmg + 0.075;
                                crystal_bonus_accuracy = crystal_bonus_accuracy + 0.15;
                            }
                            if (legs_name_array[i] == "Crystal legs")
                            {
                                crystal_bonus_dmg = crystal_bonus_dmg + 0.05;
                                crystal_bonus_accuracy = crystal_bonus_accuracy + 0.1;
                            }

                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage * crystal_bonus_dmg);

                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * gear_bonus_range_and_mage * crystal_bonus_accuracy);
                            break;
                        case "Dragon hunter crossbow":
                            if (monster_is_dragon == true)
                            {
                                temp_max_hit = Math.Floor(temp_max_hit * (gear_bonus_range_and_mage + 0.25));
                                temp_max_attack_roll = Math.Floor(temp_max_attack_roll * (gear_bonus_range_and_mage + 0.3));
                            }
                            else
                            {
                                temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                                temp_max_attack_roll = Math.Floor(temp_max_attack_roll * gear_bonus_range_and_mage);
                            }
                            break;
                        case "Black chinchompa":
                        case "Red chinchompa":
                        case "Grey chinchompa":
                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);

                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * gear_bonus_range_and_mage);

                            double chin_accuracy_modifier = 1;
                            switch (temp_weapon_stance)
                            {
                                case "short fuse":
                                    if (distance_to_monster > 3)
                                    {
                                        chin_accuracy_modifier = 0.75;
                                    }
                                    if (distance_to_monster > 6)
                                    {
                                        chin_accuracy_modifier = 0.50;
                                    }
                                    break;
                                case "medium fuse":
                                    if (distance_to_monster < 4 || distance_to_monster > 6)
                                    {
                                        chin_accuracy_modifier = 0.75;
                                    }
                                    break;
                                case "long fuse":
                                    if (distance_to_monster < 7)
                                    {
                                        chin_accuracy_modifier = 0.75;
                                    }
                                    if (distance_to_monster < 4)
                                    {
                                        chin_accuracy_modifier = 0.50;
                                    }
                                    break;
                            }
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * chin_accuracy_modifier);

                            break;
                        default:
                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);

                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * gear_bonus_range_and_mage);
                            break;
                    }
                    break;
                case "magic":
                    // welcome to magical spaghetti zone

                    Dispatcher.Invoke(mage_staff_max_hit);
                    double shadow_multiplier = 3;
                    if (monster_is_in_toa == true)
                    {
                        shadow_multiplier = 4;
                    }
                    double temp_magic_dmg = 0;
                    if (amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true)
                    {
                        temp_magic_dmg += 20;
                    }
                    if (elite_void == true)
                    {
                        temp_magic_dmg += 2.5;
                    }
                    if (total_magic_dmg_array[i] != 0 || temp_magic_dmg != 0)
                    {
                        // shadow calcs as its odd for some magic dmg bonuses
                        if (weapon_name_array[i] == "Tumeken's shadow")
                        {
                            if (total_magic_dmg_array[i] != 0)
                            {
                                // slayer helmet wont affect as either salve or void is overwriting it
                                if ((amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true) || elite_void == true)
                                {
                                    temp_max_hit = staff_base_max_hit * (1 + (((total_magic_dmg_array[i] / 100) * shadow_multiplier) + (temp_magic_dmg / 100)));
                                    temp_max_hit = Math.Floor(temp_max_hit);
                                }
                                // salve and void check just happened, so only counting for slayer helmet
                                else
                                {
                                    temp_max_hit = staff_base_max_hit * (1 + ((total_magic_dmg_array[i] / 100) * shadow_multiplier));
                                    temp_max_hit = Math.Floor(temp_max_hit);
                                    if (helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true)
                                    {
                                        temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                                    }
                                }
                            }
                            else
                            {
                                // magic dmg needs to be 0 to get here, so either salve or void must be equipped
                                // and both would overwire slayer helmet
                                temp_max_hit = staff_base_max_hit * (1 + (temp_magic_dmg / 100));
                                temp_max_hit = Math.Floor(temp_max_hit);
                            }
                        }
                        // other staff mage dmg calcs
                        else
                        {
                            if (total_magic_dmg_array[i] != 0)
                            {
                                // slayer helmet wont affect as either salve or void is overwriting it
                                if ((amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true) || elite_void == true)
                                {
                                    temp_max_hit = staff_base_max_hit * (1 + ((total_magic_dmg_array[i] + temp_magic_dmg) / 100));
                                    temp_max_hit = Math.Floor(temp_max_hit);
                                }
                                // salve and void check just happened, so only counting for slayer helmet
                                else
                                {
                                    temp_max_hit = staff_base_max_hit * (1 + (total_magic_dmg_array[i] / 100));
                                    temp_max_hit = Math.Floor(temp_max_hit);
                                    if (helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true)
                                    {
                                        temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                                    }
                                }
                            }
                            else
                            {
                                // magic dmg needs to be 0 to get here, so either salve or void must be equipped
                                // and both would overwire slayer helmet
                                temp_max_hit = staff_base_max_hit * (1 + (temp_magic_dmg / 100));
                                temp_max_hit = Math.Floor(temp_max_hit);
                            }
                        }
                    }
                    else
                    {
                        // cant have salve nor void as both temp_mage_dmg and mage_dmg are 0
                        // can have slayer helmet bonus still tho
                        temp_max_hit = staff_base_max_hit;
                        if (helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true)
                        {
                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                        }
                    }

                    // also dawnbringer is its own thing for being odd
                    if (weapon_name_array[i] == "Dawnbringer")
                    {
                        temp_max_hit = Math.Floor(magic_lvl_and_pot * (1 + ((temp_magic_dmg + total_magic_dmg_array[i]) / 100))) / 6 - 1;
                        temp_max_hit = Math.Floor(temp_max_hit);
                        if ((helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true) && !(amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true))
                        {
                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                        }
                    }

                    // why jamflex mage void works differently from range/mage void with the +8???? and its +9???? and style bonus????
                    if (elite_void == true || normal_void == true)
                    {
                        temp_effective_mage_lvl = Math.Floor(true_mage_lvl * 1.45) + style_bonus_magic_array[dps_calc_fix] + 9;
                    }
                    else
                    {
                        temp_effective_mage_lvl = true_mage_lvl + style_bonus_magic_array[dps_calc_fix] + 9;
                    }
                    switch (weapon_name_array[i])
                    {
                        case "Tumeken's shadow":
                            temp_max_attack_roll = Math.Floor(temp_effective_mage_lvl * ((total_magic_atk_array[i] * shadow_multiplier) + 64) * gear_bonus_range_and_mage);
                            break;
                        default:
                            temp_max_attack_roll = Math.Floor(temp_effective_mage_lvl * (total_magic_atk_array[i] + 64) * gear_bonus_range_and_mage);
                            break;
                    }
                    temp_max_attack_roll = Math.Floor(temp_max_attack_roll);

                    if (weapon_name_array[i] == "Dawnbringer")
                    {
                        if (monster_name != "Verzik vitur P1" || monster_name == "Combat dummy")
                        {
                            temp_max_hit = 0;
                            temp_max_attack_roll = 0;
                        }
                    }
                    break;
                case "cast":
                case "cast accurate":
                case "cast longrange":
                    // welcome to magical spaghetti zone 2.0 electric boogaloo

                    Dispatcher.Invoke(spells_max_hit);
                    temp_magic_dmg = 0;
                    if (amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true)
                    {
                        temp_magic_dmg += 20;
                    }
                    if (elite_void == true)
                    {
                        temp_magic_dmg += 2.5;
                    }

                    if (total_magic_dmg_array[i] != 0 || temp_magic_dmg != 0)
                    {
                        // slayer helmet wont affect as either salve or void is overwriting it
                        if ((amulet_name_array[i] == "Salve amulet (ei)" && monster_is_undead == true) || elite_void == true)
                        {
                            temp_max_hit = Math.Floor(spell_base_max_hit * (1 + ((total_magic_dmg_array[i] + temp_magic_dmg) / 100)));
                        }
                        // salve and void check just happened, so only counting for slayer helmet
                        else
                        {
                            temp_max_hit = Math.Floor(spell_base_max_hit * (1 + ((total_magic_dmg_array[i] + temp_magic_dmg) / 100)));
                            if (helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true)
                            {
                                temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                            }
                        }


                    }
                    else
                    {
                        // cant have salve nor void as both temp_mage_dmg and mage_dmg are 0
                        // can have slayer helmet bonus still tho
                        temp_max_hit = spell_base_max_hit;
                        if (helmet_name_array[i] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true)
                        {
                            temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_range_and_mage);
                        }
                    }

                    if (off_hand_name_array[i] == "Tome of fire" && spell_name_array[i].Contains("Fire") == true)
                    {
                        temp_max_hit = Math.Floor(temp_max_hit * 1.5);
                    }

                    if (off_hand_name_array[i] == "Tome of water" && spell_name_array[i].Contains("Water") == true)
                    {
                        temp_max_hit = Math.Floor(temp_max_hit * 1.2);
                    }

                    // why jamflex mage void works differently from range/mage void with the +9???? also why mage is +9??? and style bonus????
                    if (elite_void == true || normal_void == true)
                    {
                        temp_effective_mage_lvl = Math.Floor(true_mage_lvl * 1.45) + style_bonus_magic_array[dps_calc_fix] + 9;
                    }
                    else
                    {
                        temp_effective_mage_lvl = true_mage_lvl + style_bonus_magic_array[dps_calc_fix] + 9;
                    }

                    temp_max_attack_roll = Math.Floor(temp_effective_mage_lvl * (total_magic_atk_array[i] + 64) * gear_bonus_range_and_mage);

                    if (off_hand_name_array[i] == "Tome of water" && (spell_name_array[i].Contains("Water") == true || spell_book_array[i] == "Curse"))
                    {
                        temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.2);
                    }

                    if (weapon_name_array[i] == "Ice ancient sceptre" && spell_name_array[i].Contains("Ice") == true)
                    {
                        temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.1);
                    }
                    break;
                case "slash":
                case "stab":
                case "crush":
                    if (weapon_name_array[i] == "Soulreaper axe")
                    {
                        temp_effective_strength_lvl = Math.Floor(strength_lvl_and_pot * (strenght_prayer + 0.06 * soulreaper_axe_stack)) + style_bonus_str_array[dps_calc_fix] + 8;
                    }
                    else
                    {
                        temp_effective_strength_lvl = true_strength_lvl + style_bonus_str_array[dps_calc_fix] + 8;
                    }

                    if (elite_void == true || normal_void == true)
                    {
                        temp_effective_strength_lvl = Math.Floor(temp_effective_strength_lvl * 1.1);
                    }
                    temp_max_hit = Math.Floor(((temp_effective_strength_lvl * (total_melee_str_array[i] + 64)) + 320) / 640);
                    temp_max_hit = Math.Floor(temp_max_hit * gear_bonus_melee);

                    temp_effective_attack_lvl = true_attack_lvl + style_bonus_attack_array[dps_calc_fix] + 8;
                    if (elite_void == true || normal_void == true)
                    {
                        temp_effective_attack_lvl = Math.Floor(temp_effective_attack_lvl * 1.1);
                    }

                    if (temp_weapon_type == "stab")
                    {
                        temp_max_attack_roll = temp_effective_attack_lvl * (total_stab_atk_array[i] + 64);
                        temp_max_attack_roll = (temp_max_attack_roll * gear_bonus_melee);
                        temp_max_attack_roll = Math.Floor(temp_max_attack_roll);

                    }
                    else if (temp_weapon_type == "slash")
                    {
                        temp_max_attack_roll = temp_effective_attack_lvl * (total_slash_atk_array[i] + 64);
                        temp_max_attack_roll = (temp_max_attack_roll * gear_bonus_melee);
                        temp_max_attack_roll = Math.Floor(temp_max_attack_roll);
                    }
                    else if (temp_weapon_type == "crush")
                    {
                        double inq_bonus = 1;
                        if (helmet_name_array[i] == "Inquisitor's great helm")
                        {
                            inq_bonus = inq_bonus + 0.005;
                        }
                        if (body_name_array[i] == "Inquisitor's hauberk")
                        {
                            inq_bonus = inq_bonus + 0.005;
                        }
                        if (legs_name_array[i] == "Inquisitor's plateskirt")
                        {
                            inq_bonus = inq_bonus + 0.005;
                        }
                        if (helmet_name_array[i] == "Inquisitor's great helm" && body_name_array[i] == "Inquisitor's hauberk" && legs_name_array[i] == "Inquisitor's plateskirt")
                        {
                            inq_bonus = inq_bonus + 0.01;
                        }
                        temp_max_attack_roll = temp_effective_attack_lvl * (total_crush_atk_array[i] + 64);
                        temp_max_attack_roll = (temp_max_attack_roll * gear_bonus_melee);
                        temp_max_attack_roll = Math.Floor(temp_max_attack_roll);

                        temp_max_attack_roll = Math.Floor(temp_max_attack_roll * inq_bonus);
                        temp_max_hit = Math.Floor(temp_max_hit * inq_bonus);
                    }

                    if (weapon_name_array[i] == "Arclight" && monster_is_demon == true)
                    {
                        if (monster_name == "Duke Sucellus")
                        {
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.49);
                            temp_max_hit = Math.Floor(temp_max_hit * 1.49);
                        }
                        else
                        {
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.7);
                            temp_max_hit = Math.Floor(temp_max_hit * 1.7);
                        }
                    }

                    if (weapon_name_array[i].Contains("Keris") == true && monster_is_kaplhite == true)
                    {
                        temp_max_hit = Math.Floor(temp_max_hit * 1.33);
                        if (weapon_name_array[i] == "Keris partisan of breaching")
                        {
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.33);
                        }
                    }

                    if (weapon_name_array[i] == "Keris partisan of the sun" && monster_is_in_toa == true)
                    {
                        if (monster_reduced_hp_lvl < monster_boosted_hp_lvl * 0.25)
                        {
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.25);
                        }

                    }
                    break;
            }

            if (red_keris_spec_checkbox.IsChecked == true && monster_is_in_toa == true)
            {
                temp_max_hit = Math.Floor(temp_max_hit * 1.25);
            }

            if (monster_is_in_wilderness == true && (weapon_name_array[i] == "Craw's bow" || weapon_name_array[i] == "Webweaver bow" || weapon_name_array[i] == "Thammaron's sceptre" || weapon_name_array[i] == "Accursed sceptre" || weapon_name_array[i] == "Viggora's chainmace" || weapon_name_array[i] == "Ursine chainmace"))
            {
                temp_max_hit = Math.Floor(temp_max_hit * 1.5);
                temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.5);
            }

            if ((monster_name == "Totem" || monster_name == "Phosani's Totem") && (temp_weapon_type == "magic" || temp_weapon_stance == "spell"))
            {
                temp_max_hit = temp_max_hit * 2;
            }

            if (monster_name == "Wardens Core")
            {
                temp_max_hit = temp_max_hit * 5;
            }

            if (temp_max_hit < 0)
            {
                temp_max_hit = 0;
            }
        }
        private void mage_staff_max_hit()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }
            switch (weapon_name_array[i])
            {
                case "Tumeken's shadow":
                    staff_base_max_hit = magic_lvl_and_pot / 3 + 1;
                    staff_base_max_hit = Math.Floor(staff_base_max_hit);
                    if (staff_base_max_hit < 1)
                    {
                        staff_base_max_hit = 1;
                    }
                    break;
                case "Sanguinesti staff":
                    staff_base_max_hit = magic_lvl_and_pot / 3 - 1;
                    staff_base_max_hit = Math.Floor(staff_base_max_hit);
                    if (staff_base_max_hit < 5)
                    {
                        staff_base_max_hit = 5;
                    }
                    break;
                case "Trident of the swamp":
                    staff_base_max_hit = magic_lvl_and_pot / 3 - 2;
                    staff_base_max_hit = Math.Floor(staff_base_max_hit);
                    if (staff_base_max_hit < 4)
                    {
                        staff_base_max_hit = 4;
                    }
                    break;
                case "Trident of the seas":
                    staff_base_max_hit = magic_lvl_and_pot / 3 - 5;
                    staff_base_max_hit = Math.Floor(staff_base_max_hit);
                    if (staff_base_max_hit < 1)
                    {
                        staff_base_max_hit = 1;
                    }
                    break;
                case "Accursed sceptre":
                    staff_base_max_hit = magic_lvl_and_pot / 3 - 6;
                    staff_base_max_hit = Math.Floor(staff_base_max_hit);
                    if (staff_base_max_hit < 0)
                    {
                        staff_base_max_hit = 0;
                    }
                    break;
                case "Thammaron's sceptre":
                    staff_base_max_hit = magic_lvl_and_pot / 3 - 8;
                    staff_base_max_hit = Math.Floor(staff_base_max_hit);
                    if (staff_base_max_hit < 0)
                    {
                        staff_base_max_hit = 0;
                    }
                    break;
                    // dawnbringer is calced in max_hits_and_attack_rolls method
            }

        }
        private void spells_max_hit()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }
            switch (spell_name_array[i])
            {
                case "None":
                    spell_base_max_hit = 0;
                    break;
                case "Fire Surge":
                    spell_base_max_hit = 24;
                    break;
                case "Earth Surge":
                    spell_base_max_hit = 23;
                    break;
                case "Water Surge":
                    spell_base_max_hit = 22;
                    break;
                case "Wind Surge":
                    spell_base_max_hit = 21;
                    break;
                case "Fire Wave":
                    spell_base_max_hit = 20;
                    break;
                case "Earth Wave":
                    spell_base_max_hit = 19;
                    break;
                case "Water Wave":
                    spell_base_max_hit = 18;
                    break;
                case "Wind Wave":
                    spell_base_max_hit = 17;
                    break;
                case "Fire Blast":
                    spell_base_max_hit = 16;
                    break;
                case "Earth Blast":
                    spell_base_max_hit = 15;
                    break;
                case "Water Blast":
                    spell_base_max_hit = 14;
                    break;
                case "Wind Blast":
                    spell_base_max_hit = 13;
                    break;
                case "Fire Bolt":
                    spell_base_max_hit = 12;
                    break;
                case "Earth Bolt":
                    spell_base_max_hit = 11;
                    break;
                case "Water Bolt":
                    spell_base_max_hit = 10;
                    break;
                case "Wind Bolt":
                    spell_base_max_hit = 9;
                    break;
                case "Fire Strike":
                    spell_base_max_hit = 8;
                    break;
                case "Earth Strike":
                    spell_base_max_hit = 6;
                    break;
                case "Water Strike":
                    spell_base_max_hit = 4;
                    break;
                case "Wind Strike":
                    spell_base_max_hit = 2;
                    break;
                case "Crumble Undead":
                    spell_base_max_hit = 15;
                    break;
                case "God Spell":
                    spell_base_max_hit = 20;
                    break;
                case "God Spell (charged)":
                    spell_base_max_hit = 30;
                    break;
                case "Iban Blast":
                    spell_base_max_hit = 25;
                    break;
                case "Magic Dart":
                    spell_base_max_hit = (Math.Floor((magic_lvl_and_pot + magic_lvl_and_pot_modifier) / 10) + 10);
                    break;
                // curses
                case "Snare":
                    spell_base_max_hit = 3;
                    break;
                case "Entangle":
                    spell_base_max_hit = 5;
                    break;
                // ancients
                case "Ice Barrage":
                    spell_base_max_hit = 30;
                    break;
                case "Blood Barrage":
                    spell_base_max_hit = 29;
                    break;
                case "Shadow Brrage":
                    spell_base_max_hit = 28;
                    break;
                case "Smoke Barrage":
                    spell_base_max_hit = 27;
                    break;
                case "Ice Blitz":
                    spell_base_max_hit = 26;
                    break;
                case "Blood Blitz":
                    spell_base_max_hit = 25;
                    break;
                case "Shadow Blitz":
                    spell_base_max_hit = 24;
                    break;
                case "Smoke Blitz":
                    spell_base_max_hit = 23;
                    break;
                case "Ice Burst":
                    spell_base_max_hit = 22;
                    break;
                case "Blood Burst":
                    spell_base_max_hit = 21;
                    break;
                case "Shadow Burst":
                    spell_base_max_hit = 18;
                    break;
                case "Smoke Burst":
                    spell_base_max_hit = 17;
                    break;
                case "Ice Rush":
                    spell_base_max_hit = 16;
                    break;
                case "Blood Rush":
                    spell_base_max_hit = 15;
                    break;
                case "Shadow Rush":
                    spell_base_max_hit = 14;
                    break;
                case "Smoke Rush":
                    spell_base_max_hit = 13;
                    break;
                // arceus
                case "Dark Demonbane":
                    spell_base_max_hit = 30;
                    break;
                case "Superior Demonbane":
                    spell_base_max_hit = 23;
                    break;
                case "Inferior Demonbane":
                    spell_base_max_hit = 16;
                    break;
                case "Undead Grasp":
                    spell_base_max_hit = 24;
                    break;
                case "Skeletal Grasp":
                    spell_base_max_hit = 17;
                    break;
                case "Ghostly Grasp":
                    spell_base_max_hit = 12;
                    break;
                default:
                    spell_base_max_hit = 0;
                    break;

            }
        }
        private void hit_chance()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }

            bool ignores_accuracy = false;
            if (monster_name == "Wardens Core" && (temp_weapon_type == "stab" || temp_weapon_type == "slash" || temp_weapon_type == "crush"))
            {
                ignores_accuracy = true;
            }
            if (monster_name == "Verzik vitur P1" && weapon_name_array[i] == "Dawnbringer" && spell_name_array[i] == "none")
            {
                ignores_accuracy = true;
            }

            if ((monster_name == "Totem" || monster_name == "Phosani's Totem") && (temp_weapon_type == "magic" || temp_weapon_stance == "spell"))
            {
                ignores_accuracy = true;
            }

            if (monster_name == "Sleepwalker")
            {
                ignores_accuracy = true;
            }

            if (temp_weapon_type == "crush" && (monster_name == "Phosani's Husk (range)" || monster_name == "Phosani's Husk (mage)" || monster_name == "Phosani's Parasite (weakened)"))
            {
                ignores_accuracy = true;
            }

            if (monster_name == "Nylocas Matomenos (maiden)" && spell_name_array[i].Contains("Ice") == true && temp_max_attack_roll > 21999)
            {
                ignores_accuracy = true;
            }

            if (monster_name == "Zombified Spawn" && spell_name_array[i] == "Crumble Undead" && total_magic_atk_array[i] > -64)
            {
                ignores_accuracy = true;
            }

            if (ignores_accuracy == false)
            {
                if (temp_max_attack_roll > 0)
                {
                    switch (temp_weapon_type)
                    {
                        case "stab":
                            temp_monster_max_defensive_roll = monster_max_defensive_roll_stab;
                            break;
                        case "slash":
                            temp_monster_max_defensive_roll = monster_max_defensive_roll_slash;
                            break;
                        case "crush":
                            temp_monster_max_defensive_roll = monster_max_defensive_roll_crush;
                            break;
                        case "ranged":
                            temp_monster_max_defensive_roll = monster_max_defensive_roll_range;
                            break;
                        case "magic":
                            if (ring_name_array[i] == "Brimstone ring")
                            {
                                temp_monster_max_defensive_roll = Math.Floor(monster_max_defensive_roll_magic * 0.975);
                            }
                            else
                            {
                                temp_monster_max_defensive_roll = monster_max_defensive_roll_magic;
                            }
                            break;
                        case "cast":
                        case "cast accurate":
                        case "cast longrange":
                            if (ring_name_array[i] == "Brimstone ring")
                            {
                                temp_monster_max_defensive_roll = Math.Floor(monster_max_defensive_roll_magic * 0.975);
                            }
                            else
                            {
                                temp_monster_max_defensive_roll = monster_max_defensive_roll_magic;
                            }
                            break;
                    }
                    if (spell_name_array[i] != "none")
                    {
                        switch (weapon_name_array[i])
                        {
                            case "Osmumten's fang":
                                if (monster_is_in_toa == true)
                                {
                                    if (temp_max_attack_roll > temp_monster_max_defensive_roll)
                                    {
                                        temp_hit_chance = 1 - (temp_monster_max_defensive_roll + 2) / (2 * (temp_max_attack_roll + 1));
                                        temp_hit_chance = temp_hit_chance + (1 - temp_hit_chance) * temp_hit_chance;
                                    }
                                    else
                                    {
                                        temp_hit_chance = temp_max_attack_roll / (2 * (temp_monster_max_defensive_roll + 1));
                                        temp_hit_chance = temp_hit_chance + (1 - temp_hit_chance) * temp_hit_chance;
                                    }
                                }
                                else
                                {
                                    if (temp_max_attack_roll > temp_monster_max_defensive_roll)
                                    {
                                        temp_hit_chance = (1 - (((temp_monster_max_defensive_roll + 2) * (2 * temp_monster_max_defensive_roll + 3)) / (6 * Math.Pow(temp_max_attack_roll + 1, 2))));
                                    }
                                    else
                                    {
                                        temp_hit_chance = (temp_max_attack_roll * (4 * temp_max_attack_roll + 5)) / (6 * (temp_max_attack_roll + 1) * (temp_monster_max_defensive_roll + 1));
                                    }
                                }
                                break;
                            default:
                                if (temp_max_attack_roll > temp_monster_max_defensive_roll)
                                {
                                    temp_hit_chance = 1 - (temp_monster_max_defensive_roll + 2) / (2 * (temp_max_attack_roll + 1));
                                }
                                else
                                {
                                    temp_hit_chance = temp_max_attack_roll / (2 * (temp_monster_max_defensive_roll + 1));
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (temp_max_attack_roll > temp_monster_max_defensive_roll)
                        {
                            temp_hit_chance = 1 - (temp_monster_max_defensive_roll + 2) / (2 * (temp_max_attack_roll + 1));
                        }
                        else
                        {
                            temp_hit_chance = temp_max_attack_roll / (2 * (temp_monster_max_defensive_roll + 1));
                        }
                    }

                }
                else
                {
                    temp_hit_chance = 0;
                }
            }
            else
            {
                temp_hit_chance = 1;
            }



        }
        private void bolt_proc_effects()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }

            bolt_proc_kandarin_bonus = 1;
            if (kandarin_diary_checkbox.IsChecked == true)
            {
                bolt_proc_kandarin_bonus = 1.1;
            }
            switch (ammo_name_array[i])
            {
                case "Ruby dragon bolts (e)":
                case "Ruby bolts (e)": // bypass accuracy roll
                    bolt_proc_chance = 6 * bolt_proc_kandarin_bonus;
                    bolt_proc_chance_acb_spec = bolt_proc_chance + 6;
                    if (weapon_name_array[i] == "Zaryte crossbow")
                    {
                        bolt_proc_dmg = Math.Floor(monster_reduced_hp_lvl * 0.22);
                        bolt_proc_dmg = Math.Min(bolt_proc_dmg, 110);
                    }
                    else
                    {
                        bolt_proc_dmg = Math.Floor(monster_reduced_hp_lvl * 0.2);
                        bolt_proc_dmg = Math.Min(bolt_proc_dmg, 100);
                    }
                    break;
                case "Opal dragon bolts (e)":
                case "Opal bolts (e)": // bypass accuracy roll
                    bolt_proc_chance = 5 * bolt_proc_kandarin_bonus;
                    bolt_proc_chance_acb_spec = bolt_proc_chance + 5;
                    if (weapon_name_array[i] == "Zaryte crossbow")
                    {
                        bolt_proc_dmg = temp_max_hit + Math.Floor(range_lvl_and_pot / 9);
                    }
                    else
                    {
                        bolt_proc_dmg = temp_max_hit + Math.Floor(range_lvl_and_pot / 10);
                    }
                    break;
                case "Dragonstone dragon bolts (e)":
                case "Dragonstone bolts (e)":
                    // If the target is immune to dragonfire, the special effect will not activate. maybe someday added
                    bolt_proc_chance = 6 * bolt_proc_kandarin_bonus;
                    bolt_proc_chance_acb_spec = bolt_proc_chance + 6;
                    if (weapon_name_array[i] == "Zaryte crossbow")
                    {
                        bolt_proc_dmg = temp_max_hit + Math.Floor(range_lvl_and_pot / 4.5454545454545454545454545454545);
                    }
                    else
                    {
                        bolt_proc_dmg = temp_max_hit + Math.Floor(range_lvl_and_pot / 5);
                    }
                    break;
                case "Pearl dragon bolts (e)":
                case "Pearl bolts (e)": // bypass accuracy roll
                    // seems like zcb has no extra bonus??
                    bolt_proc_chance = 6 * bolt_proc_kandarin_bonus;
                    bolt_proc_chance_acb_spec = bolt_proc_chance + 6;
                    bolt_proc_dmg = temp_max_hit + Math.Floor(range_lvl_and_pot / 20);
                    // sorry cbad adding "fiery" type
                    if (monster_name == "King Black Dragon" || monster_name == "Vorkath")
                    {
                        bolt_proc_dmg = temp_max_hit + Math.Floor(range_lvl_and_pot / 15);
                    }
                    break;
                case "Diamond dragon bolts (e)":
                case "Diamond bolts (e)": // bypass accuracy roll
                    bolt_proc_chance = 10 * bolt_proc_kandarin_bonus;
                    bolt_proc_chance_acb_spec = bolt_proc_chance + 10;
                    if (weapon_name_array[i] == "Zaryte crossbow")
                    {
                        bolt_proc_dmg = Math.Floor(temp_max_hit * 1.25);
                    }
                    else
                    {
                        bolt_proc_dmg = Math.Floor(temp_max_hit * 1.15);
                    }
                    break;
                case "Onyx dragon bolts (e)":
                case "Onyx bolts (e)":
                    // undead immune to bonus dmg or just lifesteal??
                    bolt_proc_chance = 11 * bolt_proc_kandarin_bonus;
                    bolt_proc_chance_acb_spec = bolt_proc_chance + 11;
                    if (weapon_name_array[i] == "Zaryte crossbow")
                    {
                        bolt_proc_dmg = Math.Floor(temp_max_hit * 1.30);
                    }
                    else
                    {
                        bolt_proc_dmg = Math.Floor(temp_max_hit * 1.20);
                    }
                    break;
            }
        }
        private void immunities_and_resistances()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }
            // and few damage boosts (guardians and ice demon)

            temp_immune = false;


            if (immune_to_melee == true)
            {
                if (temp_weapon_type == "stab" || temp_weapon_type == "slash" || temp_weapon_stance == "crush")
                {
                    temp_immune = true;
                }
            }

            if (immune_to_range == true)
            {
                if (temp_weapon_type == "ranged")
                {
                    temp_immune = true;
                }
            }

            if (immune_to_mage == true)
            {
                if (temp_weapon_type == "magic" || temp_weapon_stance == "cast")
                {
                    temp_immune = true;
                }
            }


            // pickaxe
            if (monster_name == "Guardian")
            {
                if (weapon_name_array[i].Contains("Pickaxe") == false)
                {
                    temp_immune = true;
                }
            }

            // other dmg modifiers

            if (monster_name == "Alchemical Hydra (not weakened)")
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.25);
            }

            if (monster_name == "Pestilent Bloat (moving)" || monster_name == "Hard mode Pestilent Bloat (moving)")
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.5);
            }

            if (monster_name == "Vorkath (Quickfire Barrage)")
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.5);
            }

            if (monster_name == "The Leviathan (Special)" || monster_name == "Awakened Leviathan (Special)")
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.6666666666666);
            }

            if (monster_name == "Corporeal Beast")
            {
                if (temp_weapon_type == "magic" || temp_weapon_stance == "spell")
                {
                    // do nothing, janky but works
                }
                else if ((weapon_name_array[i].Contains("spear") == true || weapon_name_array[i].Contains("halberd") == true || weapon_name_array[i] == "Osmumten's fang") && temp_weapon_type == "stab")
                {
                    // do nothing, janky but works
                }
                else
                {
                    temp_max_hit = Math.Floor(temp_max_hit * 0.5);
                }
            }

            // cox
            if ((monster_name == "Tekton" || monster_name == "Tekton (enraged)") && (temp_weapon_type == "magic" || temp_weapon_stance == "spell"))
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.2);
            }
            if (monster_name == "Ice demon")
            {
                if (spell_name_array[i].Contains("Fire") == true)
                {
                    temp_max_hit = Math.Floor(temp_max_hit * 1.5);
                }
                else
                {
                    temp_max_hit = Math.Floor(temp_max_hit * 0.3333333333);
                }
            }
            if (monster_name == "Glowing crystal" && (temp_weapon_type == "magic" || temp_weapon_stance == "spell"))
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.3333333333);
            }
            if (monster_name == "Great olm (melee claw)" && (temp_weapon_type == "magic" || temp_weapon_type == "ranged" || temp_weapon_stance == "spell"))
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.3333333333);
            }
            if (monster_name == "Great olm (mage claw)" && (temp_weapon_type != "magic" || temp_weapon_stance == "spell"))
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.3333333333);
            }
            if (monster_name == "Great olm (head)" && temp_weapon_type != "ranged")
            {
                temp_max_hit = Math.Floor(temp_max_hit * 0.3333333333);
            }
            if (monster_name == "Guardian" && weapon_name_array[i].Contains("Pickaxe") == true)
            {
                if (dragon_picaxe_spec_checkbox.IsChecked == true)
                {
                    temp_max_hit = Math.Floor(temp_max_hit * ((50 + mining_lvl + 3 + mining_lvl_req_array[i]) / 150));
                }
                else
                {
                    temp_max_hit = Math.Floor(temp_max_hit * ((50 + mining_lvl + mining_lvl_req_array[i]) / 150));
                }
            }
            // verzik vitur p1 dmg modifier in average_dmg method
        }
        private void average_dmg()
        {
            int x = 0;
            if (gear_set_2 == true)
            {
                x = 1;
            }

            if (monster_name == "Verzik vitur P1" && (weapon_name_array[x] != "Dawnbringer" || temp_weapon_stance == "spell"))
            {
                if (weapon_name_array[x] == "Scythe of vitur" && spell_name_array[x] == "None")
                {
                    scythe_hitsplat_1 = temp_max_hit;
                    scythe_hitsplat_2 = Math.Floor(temp_max_hit * 0.5);
                    scythe_hitsplat_3 = Math.Floor(temp_max_hit * 0.25);
                    double max_hit_probability = 1 / (scythe_hitsplat_1 + 1);
                    double throne_max_hit_cap_probability = 0.090909090909090909;
                    double expected_min = 0;
                    double var_x;

                    for (int i = 0; i < (scythe_hitsplat_1 + 1); i++)
                    {
                        for (int j = 0; j < (11); j++)
                        {
                            var_x = Math.Min(i, j);
                            expected_min += max_hit_probability * throne_max_hit_cap_probability * var_x;
                        }

                    }
                    temp_avg_dmg_per_attack = expected_min * temp_hit_chance;
                    expected_min = 0;
                    max_hit_probability = 1 / (scythe_hitsplat_2 + 1);
                    for (int i = 0; i < (scythe_hitsplat_2 + 1); i++)
                    {
                        for (int j = 0; j < (11); j++)
                        {
                            var_x = Math.Min(i, j);
                            expected_min += max_hit_probability * throne_max_hit_cap_probability * var_x;
                        }

                    }
                    temp_avg_dmg_per_attack += expected_min * temp_hit_chance;
                    expected_min = 0;
                    max_hit_probability = 1 / (scythe_hitsplat_3 + 1);
                    for (int i = 0; i < (scythe_hitsplat_3 + 1); i++)
                    {
                        for (int j = 0; j < (11); j++)
                        {
                            var_x = Math.Min(i, j);
                            expected_min += max_hit_probability * throne_max_hit_cap_probability * var_x;
                        }

                    }
                    temp_avg_dmg_per_attack += expected_min * temp_hit_chance;

                    if (temp_max_hit > 10)
                    {
                        temp_max_hit = 10;
                    }
                    if (scythe_hitsplat_1 > 10)
                    {
                        scythe_hitsplat_1 = 10;
                    }
                    if (scythe_hitsplat_2 > 10)
                    {
                        scythe_hitsplat_2 = 10;
                    }
                    if (scythe_hitsplat_3 > 10)
                    {
                        scythe_hitsplat_3 = 10;
                    }


                }
                else if (weapon_name_array[x] == "Osmumten's fang" && spell_name_array[x] == "None")
                {
                    osmumtens_fang_min_hit = Math.Floor(temp_max_hit * 0.15);
                    if (special_attack_fix == true)
                    {
                        osmumtens_fang_max_hit = temp_max_hit;
                    }
                    else
                    {
                        osmumtens_fang_max_hit = temp_max_hit - osmumtens_fang_min_hit;
                    }
                    double max_hit_probability = 1 / (osmumtens_fang_max_hit - osmumtens_fang_min_hit + 1);
                    double throne_max_hit_cap_probability = 0.090909090909090909;
                    double expected_min = 0;
                    double var_x;

                    for (double i = osmumtens_fang_min_hit; i < (osmumtens_fang_max_hit + 1); i++)
                    {
                        for (int j = 0; j < (11); j++)
                        {
                            var_x = Math.Min(i, j);
                            expected_min += max_hit_probability * throne_max_hit_cap_probability * var_x;
                        }

                    }
                    temp_avg_dmg_per_attack = expected_min * temp_hit_chance;
                    if (temp_max_hit > 10)
                    {
                        temp_max_hit = 10;
                    }
                    if (osmumtens_fang_max_hit > 10)
                    {
                        osmumtens_fang_max_hit = 10;
                    }
                    if (osmumtens_fang_min_hit > 10)
                    {
                        osmumtens_fang_min_hit = 10;
                    }
                }
                else
                {
                    double max_hit_probability = 1 / (temp_max_hit + 1);
                    double throne_max_hit_cap;
                    double expected_min = 0;
                    double var_x;
                    if (temp_weapon_type == "magic" || temp_weapon_type == "ranged" || temp_weapon_stance == "spell")
                    {
                        throne_max_hit_cap = 3;
                    }
                    else
                    {
                        throne_max_hit_cap = 10;
                    }
                    double throne_max_hit_cap_probability = 1 / (throne_max_hit_cap + 1);
                    for (int i = 0; i < (temp_max_hit + 1); i++)
                    {
                        for (int j = 0; j < (throne_max_hit_cap + 1); j++)
                        {
                            var_x = Math.Min(i, j);
                            expected_min += max_hit_probability * throne_max_hit_cap_probability * var_x;
                        }

                    }
                    temp_avg_dmg_per_attack = expected_min * temp_hit_chance;

                    if (temp_weapon_type == "magic" || temp_weapon_type == "ranged" || temp_weapon_stance == "spell")
                    {
                        if (temp_max_hit > 3)
                        {
                            temp_max_hit = 3;
                        }
                    }
                    else
                    {
                        if (temp_max_hit > 10)
                        {
                            temp_max_hit = 10;
                        }
                    }


                }


            }
            else
            {
                if (weapon_name_array[x] == "Scythe of vitur" && spell_name_array[x] == "None")
                {
                    if (monster_size == 1)
                    {
                        scythe_hitsplat_1 = temp_max_hit;
                    }
                    else if (monster_size == 2)
                    {
                        scythe_hitsplat_1 = temp_max_hit;
                        scythe_hitsplat_2 = Math.Floor(temp_max_hit * 0.5);
                        temp_max_hit = scythe_hitsplat_1 + scythe_hitsplat_2;
                    }
                    else
                    {
                        scythe_hitsplat_1 = temp_max_hit;
                        scythe_hitsplat_2 = Math.Floor(temp_max_hit * 0.5);
                        scythe_hitsplat_3 = Math.Floor(temp_max_hit * 0.25);
                        temp_max_hit = scythe_hitsplat_1 + scythe_hitsplat_2 + scythe_hitsplat_3;
                    }
                    temp_avg_dmg_per_attack = (temp_max_hit * temp_hit_chance) / 2;
                }
                else if (weapon_name_array[x] == "Osmumten's fang" && spell_name_array[x] == "None")
                {
                    osmumtens_fang_min_hit = Math.Floor(temp_max_hit * 0.15);
                    if (special_attack_fix == true)
                    {
                        osmumtens_fang_max_hit = temp_max_hit;
                    }
                    else
                    {
                        osmumtens_fang_max_hit = temp_max_hit - osmumtens_fang_min_hit;
                    }
                    if (monster_name == "Wardens Core")
                    {
                        temp_max_hit = osmumtens_fang_max_hit;
                    }
                    temp_avg_dmg_per_attack = ((osmumtens_fang_min_hit + osmumtens_fang_max_hit) * temp_hit_chance) / 2;
                }
                else if (weapon_name_array[x] == "Venator bow")
                {
                    temp_avg_dmg_per_attack = (temp_max_hit * temp_hit_chance) / 2;
                    double temp_max_def_roll;
                    double temp_temp_hit_chance;
                    if (venator_1st_bounce_checkbox.IsChecked == true)
                    {
                        temp_max_def_roll = (venator_bow_1st_bounce_def_lvl + 9) * (venator_bow_1st_bounce_range_def + 64);
                        if (temp_max_attack_roll > temp_max_def_roll)
                        {
                            temp_temp_hit_chance = 1 - (temp_max_def_roll + 2) / (2 * (temp_max_attack_roll + 1));
                        }
                        else
                        {
                            temp_temp_hit_chance = temp_max_attack_roll / (2 * (temp_max_def_roll + 1));
                        }

                        temp_avg_dmg_per_attack += Math.Floor(temp_max_hit / 100.0 * 66) * temp_temp_hit_chance / 2;
                    }
                    if (venator_2nd_bounce_checkbox.IsChecked == true)
                    {
                        temp_max_def_roll = (venator_bow_2nd_bounce_def_lvl + 9) * (venator_bow_2nd_bounce_range_def + 64);
                        if (temp_max_attack_roll > temp_max_def_roll)
                        {
                            temp_temp_hit_chance = 1 - (temp_max_def_roll + 2) / (2 * (temp_max_attack_roll + 1));
                        }
                        else
                        {
                            temp_temp_hit_chance = temp_max_attack_roll / (2 * (temp_max_def_roll + 1));
                        }

                        temp_avg_dmg_per_attack += Math.Floor(temp_max_hit / 100.0 * 66) * temp_temp_hit_chance / 2;
                    }

                }
                else if (weapon_name_array[x].Contains("Keris") == true && monster_is_kaplhite == true && spell_name_array[x] == "None")
                {
                    temp_avg_dmg_per_attack = ((temp_max_hit + (temp_max_hit * 3 * (1.0 / 51.0))) * temp_hit_chance) / 2;
                }
                else
                {
                    temp_avg_dmg_per_attack = (temp_max_hit * temp_hit_chance) / 2;
                }

            }

            // zulrah dmg cap
            if (monster_name.Contains("Zulrah") == true && temp_max_hit > 50)
            {
                double[] zulrah_dmg_dist = new double[Convert.ToInt32(temp_max_hit + 1)];
                zulrah_dmg_dist[0] = 1 - temp_hit_chance;
                for (int i = 1; i < temp_max_hit + 1; i++)
                {
                    if (i < 51)
                    {
                        zulrah_dmg_dist[i] = i * temp_hit_chance;
                    }
                    else
                    {
                        zulrah_dmg_dist[i] = 47.5 * temp_hit_chance;
                    }
                }
                temp_max_hit = 50;
                temp_avg_dmg_per_attack = (zulrah_dmg_dist.Sum() / zulrah_dmg_dist.Length);
            }

            if (weapon_name_array[x].Contains("crossbow") == true && (ammo_name_array[x] == "Ruby dragon bolts (e)" || ammo_name_array[x] == "Ruby bolts (e)"))
            {
                temp_avg_dmg_per_attack = temp_max_hit * temp_hit_chance;
            }

            if (monster_name == "Sleepwalker")
            {
                temp_avg_dmg_per_attack = temp_max_hit;
            }

            if (temp_weapon_type == "crush" && (monster_name == "Phosani's Husk (range)" || monster_name == "Phosani's Husk (mage)" || monster_name == "Phosani's Parasite (weakened)"))
            {
                temp_avg_dmg_per_attack = temp_max_hit;
            }

            if (monster_name == "Wardens Core" && (temp_weapon_type == "stab" || temp_weapon_type == "slash" || temp_weapon_type == "crush"))
            {
                temp_avg_dmg_per_attack = temp_max_hit;
            }

            if (monster_name == "Zombified Spawn" && spell_name_array[x] == "Crumble Undead" && total_magic_atk_array[x] > -64)
            {
                temp_max_hit = monster_reduced_hp_lvl;
                temp_avg_dmg_per_attack = temp_max_hit;
            }
        }
        private void overkill()
        {
            // plan is to rewrite this someday when i know how to make it in a lesser spaghetti mess
            // some odd magic happens here, dont ask. Copied over from Bitterkoekje Dps calcs.
            // where overkill was made by math/code wizard called Inevitably
            // https://docs.google.com/spreadsheets/d/1wBXIlvAmqoQpu5u9XBfD4B0PW7D8owyO_CnRDiTHBKQ/edit#gid=158500257
            // also has some minor problems, like verzik p1 dmg cap messes overkill calcs.
            // and some big problem if max hit needs to be rounded. Mainly from bolt proc special dmg calcs

            int x = 0;
            if (gear_set_2 == true)
            {
                x = 1;
            }


            if (temp_avg_dmg_per_attack != temp_max_hit)
            {
                double accuracy_var = temp_hit_chance * (1 - (1 / (temp_max_hit + 1)));
                int temp_temp_max_hit = Convert.ToInt32(temp_max_hit);
                if (thrall_dps_checkbox.IsChecked == true && thrall_name != "None")
                {
                    temp_temp_max_hit = Convert.ToInt32(temp_temp_max_hit + (thrall_max_hit * 4 / temp_weapon_attack_speed));
                }
                int max_hit_var = Convert.ToInt32(temp_temp_max_hit);
                int monster_hp_var = Convert.ToInt32(monster_reduced_hp_lvl);
                int scythe_1 = Convert.ToInt32(scythe_hitsplat_1);
                int scythe_2 = Convert.ToInt32(scythe_hitsplat_2);
                int scythe_3 = Convert.ToInt32(scythe_hitsplat_3);

                if (monster_reduced_hp_lvl > 0 || monster_name != "None")
                {
                    if (temp_weapon_stance != "spell")
                    {
                        switch (weapon_name_array[x])
                        {
                            case "Scythe of vitur":
                                if (thrall_dps_checkbox.IsChecked == true && thrall_name != "None")
                                {
                                    scythe_1 = scythe_1 + Convert.ToInt32((thrall_max_hit * 4 / temp_weapon_attack_speed));
                                }
                                double acc = temp_hit_chance;
                                int array_size;
                                if (monster_size == 1)
                                {
                                    array_size = scythe_1 + 1;
                                }
                                else if (monster_size == 2)
                                {
                                    array_size = scythe_1 + scythe_2 + 1;
                                }
                                else
                                {
                                    array_size = scythe_1 + scythe_2 + scythe_3 + 1;
                                }


                                double[] dist = new double[array_size];
                                int[] maxdist = { scythe_1 + 1, scythe_2 + 1, scythe_3 + 1 };

                                // monster size 3
                                if (monster_size >= 3)
                                {
                                    int denom = 0;
                                    for (int i = 0; i < maxdist[0]; i++)
                                    {
                                        for (int j = 0; j < maxdist[1]; j++)
                                        {
                                            for (int k = 0; k < maxdist[2]; k++)
                                            {
                                                int hit = i + j + k;
                                                double numer = Math.Pow(acc, 3);
                                                denom = (scythe_1 + 1) * (scythe_2 + 1) * (scythe_3 + 1);
                                                dist[hit] += (numer / denom);
                                            }
                                        }
                                    }
                                    int[][] combs = new int[][]
                                    {
                                    new int[] { maxdist[0], maxdist[1] },
                                    new int[] { maxdist[0], maxdist[2] },
                                    new int[] { maxdist[1], maxdist[2] }
                                    };
                                    for (int i = 0; i < combs.Length; i++)
                                    {
                                        for (int j = 0; j < combs[i][0]; j++)
                                        {
                                            for (int k = 0; k < combs[i][1]; k++)
                                            {
                                                dist[j + k] += Math.Pow(acc, 2) * (1 - acc) / (combs[i][0] * combs[i][1]);
                                            }
                                        }
                                    }

                                    for (int i = 0; i < maxdist.Length; i++)
                                    {
                                        for (int j = 0; j < maxdist[i]; j++)
                                        {
                                            dist[j] += acc * Math.Pow(1 - acc, 2) / maxdist[i];
                                        }
                                    }
                                    dist[0] += Math.Pow(1 - acc, 3);
                                }

                                // monster size 2
                                if (monster_size == 2)
                                {
                                    for (int i = 0; i < maxdist[0]; i++)
                                    {
                                        for (int j = 0; j < maxdist[1]; j++)
                                        {
                                            dist[i + j] += Math.Pow(acc, 2) / (maxdist[0] * maxdist[1]);
                                        }
                                    }

                                    for (int i = 0; i < (maxdist.Length - 1); i++)
                                    {
                                        for (int j = 0; j < maxdist[i]; j++)
                                        {
                                            dist[j] += acc * (1 - acc) / maxdist[i];
                                        }
                                    }
                                    dist[0] += Math.Pow(1 - acc, 2);
                                }

                                // monster size 1
                                if (monster_size == 1)
                                {
                                    for (int i = 0; i < maxdist[0]; i++)
                                    {
                                        dist[i] = acc / maxdist[0];
                                    }
                                    dist[0] += (1 - acc);
                                }

                                List<double> expectation = new List<double> { 0 };
                                double sum = dist.Sum();

                                for (int i = 1; i < (monster_reduced_hp_lvl + 1); i++)
                                {
                                    double temp = 0;
                                    for (int j = 0; j < dist.Length; j++)
                                    {
                                        if (j != 0)
                                        {
                                            temp += dist[j] * expectation[Math.Max(expectation.Count - j, 0)];
                                        }
                                    }
                                    temp /= sum;
                                    expectation.Add((1 + temp) / (1 - dist[0]));
                                }

                                temp_avg_hits_to_kill = expectation.Last();
                                break;
                            case "Osmumten's fang":
                                if (osmumtens_fang_min_hit > 0)
                                {
                                    int fang_max = Convert.ToInt32(osmumtens_fang_max_hit);
                                    int fang_min = Convert.ToInt32(osmumtens_fang_min_hit);
                                    if (thrall_dps_checkbox.IsChecked == true && thrall_name != "None")
                                    {
                                        fang_max = fang_max + Convert.ToInt32((thrall_max_hit * 4 / temp_weapon_attack_speed));
                                    }
                                    double[] dist_fang = new double[fang_max + 1];
                                    double acc_fang = temp_hit_chance;
                                    dist_fang[0] = 1 - temp_hit_chance;
                                    for (int i = 1; i <= fang_max; i++)
                                    {
                                        if (i < fang_min)
                                        {
                                            dist_fang[i] = 0;
                                        }
                                        else
                                        {
                                            dist_fang[i] = acc_fang / (fang_max - fang_min + 1);
                                        }
                                    }

                                    List<double> expectation_fang = new List<double> { 0 };
                                    double sum_fang = dist_fang.Sum();

                                    for (int i = 1; i < (monster_reduced_hp_lvl + 1); i++)
                                    {
                                        double temp = 0;
                                        for (int j = 0; j < dist_fang.Length; j++)
                                        {
                                            if (j != 0)
                                            {
                                                temp += dist_fang[j] * expectation_fang[Math.Max(expectation_fang.Count - j, 0)];
                                            }
                                        }
                                        temp /= sum_fang;
                                        expectation_fang.Add((1 + temp) / (1 - dist_fang[0]));
                                    }

                                    temp_avg_hits_to_kill = expectation_fang.Last();
                                }
                                else
                                {
                                    double[] expected_hits_fang = new double[monster_hp_var + 1];
                                    double sum_var_fang = 0;
                                    int fang_max = Convert.ToInt32(osmumtens_fang_max_hit);
                                    if (thrall_dps_checkbox.IsChecked == true && thrall_name != "None")
                                    {
                                        fang_max = fang_max + Convert.ToInt32((thrall_max_hit * 4 / temp_weapon_attack_speed));
                                    }
                                    for (int i = 1; i < (monster_reduced_hp_lvl + 1); i++)
                                    {
                                        if (i - fang_max - 1 >= 0)
                                        {
                                            sum_var_fang -= expected_hits_fang[i - fang_max - 1];
                                        }
                                        sum_var_fang += expected_hits_fang[i - 1];
                                        expected_hits_fang[i] = 1 / accuracy_var + sum_var_fang / fang_max;
                                    }

                                    temp_avg_hits_to_kill = expected_hits_fang[monster_hp_var];
                                }
                                break;
                            default:
                                double[] expected_hits = new double[monster_hp_var + 1];
                                double sum_var = 0;
                                for (int i = 1; i < (monster_reduced_hp_lvl + 1); i++)
                                {
                                    if (i - temp_temp_max_hit - 1 >= 0)
                                    {
                                        sum_var -= expected_hits[i - max_hit_var - 1];
                                    }
                                    sum_var += expected_hits[i - 1];
                                    expected_hits[i] = 1 / accuracy_var + sum_var / temp_temp_max_hit;
                                }

                                temp_avg_hits_to_kill = expected_hits[monster_hp_var];
                                break;
                        }
                    }
                    else
                    {
                        double[] expected_hits = new double[monster_hp_var + 1];
                        double sum_var = 0;
                        for (int i = 1; i < (monster_reduced_hp_lvl + 1); i++)
                        {
                            if (i - temp_temp_max_hit - 1 >= 0)
                            {
                                sum_var -= expected_hits[i - max_hit_var - 1];
                            }
                            sum_var += expected_hits[i - 1];
                            expected_hits[i] = 1 / accuracy_var + sum_var / temp_temp_max_hit;
                        }

                        temp_avg_hits_to_kill = expected_hits[monster_hp_var];
                    }

                }
                else
                {
                    temp_avg_hits_to_kill = 0;
                }
            }
            else
            {
                temp_avg_hits_to_kill = Math.Ceiling(monster_reduced_hp_lvl / (temp_avg_dmg_per_attack * temp_hit_chance));
            }
        }
        private void thrall_dps()
        {
            temp_max_hit = thrall_max_hit;
            temp_weapon_type = thrall_type;
            Dispatcher.Invoke(immunities_and_resistances);
            thrall_immune = temp_immune;
            // random fixes
            if (monster_name == "Guardian")
            {
                thrall_immune = true;
                temp_max_hit = thrall_max_hit;
            }
            if (monster_name == "Ice demon")
            {
                temp_max_hit = Math.Floor(thrall_max_hit / 3);
            }

            if ((monster_name == "Totem" || monster_name == "Phosani's Totem") && thrall_type == "magic")
            {
                temp_max_hit = temp_max_hit * 2;
            }


            thrall_max_hit = Math.Round(temp_max_hit, 7);

            switch (monster_name)
            {
                case "Verzik vitur P1":
                    double max_hit_probability = 1 / (temp_max_hit + 1);
                    double throne_max_hit_cap;
                    double expected_min = 0;
                    double var_x;
                    if (temp_weapon_type == "magic" || temp_weapon_type == "ranged")
                    {
                        throne_max_hit_cap = 3;
                    }
                    else
                    {
                        throne_max_hit_cap = 10;
                    }
                    double throne_max_hit_cap_probability = 1 / (throne_max_hit_cap + 1);
                    for (int i = 0; i < (temp_max_hit + 1); i++)
                    {
                        for (int j = 0; j < (throne_max_hit_cap + 1); j++)
                        {
                            var_x = Math.Min(i, j);
                            expected_min += max_hit_probability * throne_max_hit_cap_probability * var_x;
                        }

                    }
                    thrall_avg_dmg = Math.Round(expected_min, 7);
                    break;
                default:
                    thrall_avg_dmg = Math.Round(temp_max_hit / 2, 7);
                    break;
            }
            if (thrall_immune == true)
            {
                thrall_max_hit = 0;
                thrall_avg_dmg = 0;
                thrall_damage_per_second = 0;
            }
            else
            {
                thrall_damage_per_second = Math.Round(thrall_avg_dmg / 2.4, 7);
            }
        }
        private void special_attack_modifier()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }

            special_attack_roll_modifier = 1;
            special_dmg_roll_modifier = 1;
            special_additional_dmg = 0;
            switch (weapon_name_array[i])
            {
                default:
                    MessageBox.Show("Special attack not found", "Special attack naming error");
                    break;
                case "Zamorak godsword":
                case "Saradomin godsword":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.1;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Bandos godsword":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.21;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Ancient godsword":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.1;
                    special_additional_dmg = 25;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Armadyl godsword":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.375;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Soulreaper axe":
                    special_attack_roll_modifier = 1 + 0.06 * soulreaper_axe_stack;
                    special_dmg_roll_modifier = 1 + 0.06;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Crystal halberd":
                case "Dragon halberd":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1.1;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Dragon scimitar":
                case "Abyssal tentacle":
                case "Abyssal whip":
                    special_attack_roll_modifier = 1.25;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Arclight":
                case "Darklight":
                case "Bone dagger":
                case "Dragon 2h sword":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "stab";
                    break;
                case "Dragon warhammer":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1.50;
                    special_defence_roll_modifier = "crush";
                    break;
                case "Dragon claws":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Voidwaker":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "magic";
                    break;
                case "Dinh's bulwark":
                    special_attack_roll_modifier = 1.2;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "crush";
                    break;
                case "Dragon longsword":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1.25;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Dragon mace":
                    special_attack_roll_modifier = 1.25;
                    special_dmg_roll_modifier = 1.50;
                    special_defence_roll_modifier = "crush";
                    break;
                case "Abyssal bludgeon":
                case "Ancient mace":
                case "Granite maul":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "crush";
                    break;
                case "Barrelchest anchor":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.1;
                    special_defence_roll_modifier = "crush";
                    break;
                case "Dragon sword":
                    special_attack_roll_modifier = 1.25;
                    special_dmg_roll_modifier = 1.25;
                    special_defence_roll_modifier = "stab";
                    break;
                case "Granite hammer":
                    special_attack_roll_modifier = 1.50;
                    special_dmg_roll_modifier = 1;
                    special_additional_dmg = 5;
                    special_defence_roll_modifier = "crush";
                    break;
                case "Keris partisan of corruption":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.25;
                    special_defence_roll_modifier = "stab";
                    break;
                case "Osmumten's fang":
                    special_attack_roll_modifier = 1.5;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "stab";
                    break;
                case "Saradomin's blessed sword":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1.25;
                    special_defence_roll_modifier = "magic";
                    break;
                case "Abyssal dagger":
                    special_attack_roll_modifier = 1.25;
                    special_dmg_roll_modifier = 0.85;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Dragon dagger":
                    special_attack_roll_modifier = 1.15;
                    special_dmg_roll_modifier = 1.15;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Saradomin sword":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1.10;
                    special_defence_roll_modifier = "slash";
                    break;
                case "Ursine chainmace":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1;
                    special_additional_dmg = 20;
                    special_defence_roll_modifier = "slash";
                    break;
                // mage stuff
                case "Accursed sceptre":
                    special_attack_roll_modifier = 1.5;
                    special_dmg_roll_modifier = 1.5;
                    special_defence_roll_modifier = "magic";
                    break;
                case "Dawnbringer":
                case "Eldritch nightmare staff":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "magic";
                    break;
                case "Volatile nightmare staff":
                    special_attack_roll_modifier = 1.5;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "magic";
                    break;
                // range stuff
                case "Webweaver bow":
                case "Armadyl crossbow":
                case "Zaryte crossbow":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "ranged";
                    break;
                case "Dragon crossbow":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1.2;
                    special_defence_roll_modifier = "ranged";
                    break;
                case "Toxic blowpipe":
                    special_attack_roll_modifier = 2;
                    special_dmg_roll_modifier = 1.5;
                    special_defence_roll_modifier = "ranged";
                    break;
                case "Magic shortbow":
                case "Magic shortbow (i)":
                    special_attack_roll_modifier = 1.4285714285714285714285714285714;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "ranged";
                    break;
                case "Dark bow":
                case "Magic longbow":
                case "Dragon knife":
                    special_attack_roll_modifier = 1;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "ranged";
                    break;
                case "Dragon thrownaxe":
                    special_attack_roll_modifier = 1.25;
                    special_dmg_roll_modifier = 1;
                    special_defence_roll_modifier = "ranged";
                    break;
                case "Heavy ballista":
                case "Light ballista":
                    special_attack_roll_modifier = 1.25;
                    special_dmg_roll_modifier = 1.25;
                    special_defence_roll_modifier = "ranged";
                    break;
            }
        }
        private void special_attack_dps()
        {
            // i hope you are hungry, as there is a lot of premium guality spaghetti here
            special_attack_fix = false;
            int x = 0;
            int y = 0;
            if (gear_set_2 == true)
            {
                x = 1;
                y = 11;
                if (custom_attack_speed_2_checkbox.IsChecked == true)
                {
                    temp_weapon_attack_speed = custom_attack_speed_array[x];
                }
                else
                {
                    temp_weapon_attack_speed = weapon_atk_speed_array[x];
                }
            }
            else
            {
                if (custom_attack_speed_checkbox.IsChecked == true)
                {
                    temp_weapon_attack_speed = custom_attack_speed_array[x];
                }
                else
                {
                    temp_weapon_attack_speed = weapon_atk_speed_array[x];
                }
            }


            if (temp_weapon_type != "none" && temp_weapon_stance != "none")
            {
                Dispatcher.Invoke(attack_styles);
                Dispatcher.Invoke(max_hit_and_attack_roll);
                special_max_hit_1 = Math.Floor(temp_max_hit * special_dmg_roll_modifier);
                special_attack_roll_1 = Math.Floor(temp_max_attack_roll * special_attack_roll_modifier);
                temp_weapon_type = special_defence_roll_modifier;
                special_immune_2_array[x] = true; // sorry no immunity to spaghetti
                double gear_bonus_range_and_mage = 1;
                double slayer_helm_bonus_mega_temp = 1;
                double temp_magic_dmg = 0;  // sorry another 3 layers of spaghettio boilingnese (pls dont look nm staff specs)

                // the big pile of odd spec weapons that have special rules, and default spec weapons that follow basic formula
                switch (weapon_name_array[x])
                {

                    case "Dragon halberd":
                    case "Crystal halberd":
                        if (monster_size == 1)
                        {
                            temp_max_hit = special_max_hit_1;
                            temp_max_attack_roll = special_attack_roll_1;
                            Dispatcher.Invoke(hit_chance);
                            if (temp_max_hit > -1)
                            {
                                Dispatcher.Invoke(immunities_and_resistances);
                                special_immune_array[x] = temp_immune;
                                Dispatcher.Invoke(average_dmg);
                                if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                                {
                                    Dispatcher.Invoke(overkill);
                                }
                                else
                                {
                                    temp_avg_hits_to_kill = 0;
                                }
                            }
                            else
                            {
                                temp_avg_dmg_per_attack = 0;
                                temp_avg_hits_to_kill = 0;

                                special_max_hit_1 = 0;
                                special_max_hit_2 = 0;
                            }
                        }
                        else
                        {
                            special_attack_roll_2 = temp_max_attack_roll * 0.75;
                            special_max_hit_2 = special_max_hit_1;

                            temp_max_hit = special_max_hit_1;
                            temp_max_attack_roll = special_attack_roll_1;
                            Dispatcher.Invoke(hit_chance);                           
                            special_hit_chance_1 = temp_hit_chance;
                            temp_max_attack_roll = special_attack_roll_2;
                            Dispatcher.Invoke(hit_chance);
                            special_hit_chance_2 = temp_hit_chance;
                            if (temp_max_hit > -1)
                            {
                                if (monster_name == "Corporeal Beast")
                                {
                                    temp_weapon_type = weapon_type_array[corp_style_fix];
                                    Dispatcher.Invoke(immunities_and_resistances);
                                    special_immune_array[x] = temp_immune;
                                }
                                else
                                {
                                    Dispatcher.Invoke(immunities_and_resistances);
                                    special_immune_array[x] = temp_immune;
                                }

                                temp_hit_chance = special_hit_chance_1;
                                Dispatcher.Invoke(average_dmg);
                                special_average_dmg_1 = temp_avg_dmg_per_attack;

                                temp_hit_chance = special_hit_chance_2;
                                Dispatcher.Invoke(average_dmg);
                                special_average_dmg_2 = temp_avg_dmg_per_attack;

                                special_max_hit_1 = temp_max_hit;
                                special_max_hit_2 = temp_max_hit;

                                temp_max_attack_roll = (special_attack_roll_1 + special_attack_roll_2) / 2;
                                temp_hit_chance = (special_hit_chance_1 + special_hit_chance_2) / 2;
                                temp_max_hit = special_max_hit_1 + special_max_hit_2;
                                temp_avg_dmg_per_attack = special_average_dmg_1 + special_average_dmg_2;

                                if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                                {
                                    Dispatcher.Invoke(overkill);
                                }
                                else
                                {
                                    temp_avg_hits_to_kill = 0;
                                }
                            }
                            else
                            {
                                temp_avg_dmg_per_attack = 0;
                                temp_avg_hits_to_kill = 0;

                                special_max_hit_1 = 0;
                                special_max_hit_2 = 0;
                            }
                            special_attack_roll_1_array[dps_calc_fix] = special_attack_roll_1;
                            special_attack_roll_2_array[dps_calc_fix] = special_attack_roll_2;
                            special_hit_chance_1_array[dps_calc_fix] = special_hit_chance_1;
                            special_hit_chance_2_array[dps_calc_fix] = special_hit_chance_2;
                            special_average_dmg_1_array[dps_calc_fix] = special_average_dmg_1;
                            special_average_dmg_2_array[dps_calc_fix] = special_average_dmg_2;
                            special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                            special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        }                       
                        break;
                    case "Soulreaper axe":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Bone dagger":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        temp_hit_chance = 1;
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Dragon dagger":
                    case "Dragon knife":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;

                            Dispatcher.Invoke(average_dmg);
                            special_max_hit_1 = temp_max_hit;

                            temp_max_hit = temp_max_hit * 2;
                            temp_avg_dmg_per_attack = temp_avg_dmg_per_attack * 2;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_1;
                        break;
                    case "Abyssal dagger":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;

                            Dispatcher.Invoke(average_dmg);
                            special_max_hit_1 = temp_max_hit;

                            temp_max_hit = temp_max_hit * 2;
                            temp_avg_dmg_per_attack = temp_avg_dmg_per_attack * 2;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_1;
                        break;
                    case "Dragon claws":
                        double temp_avg_dmg_spec_1;
                        double temp_avg_dmg_spec_2;
                        double temp_avg_dmg_spec_3;
                        double temp_avg_dmg_spec_4;
                        double temp_total_dclaw_avg_dmg;
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;

                            Dispatcher.Invoke(average_dmg);

                            // 4-2-1-1 case
                            special_max_hit_1 = temp_max_hit -1;
                            dragon_claw_spec_min_hit = Math.Floor(temp_max_hit / 2);
                            special_max_hit_2 = Math.Floor(special_max_hit_1 / 2);
                            special_max_hit_3 = Math.Floor(special_max_hit_2 / 2);
                            special_max_hit_4 = special_max_hit_3 + 1;

                            temp_avg_dmg_spec_1 = (special_max_hit_1 - dragon_claw_spec_min_hit) / 2 + dragon_claw_spec_min_hit;
                            temp_avg_dmg_spec_2 = special_max_hit_2 / 2;
                            temp_avg_dmg_spec_3 = special_max_hit_3 / 2;
                            temp_avg_dmg_spec_4 = special_max_hit_4 / 2;

                            temp_total_dclaw_avg_dmg = (temp_avg_dmg_spec_1 + temp_avg_dmg_spec_2 + temp_avg_dmg_spec_3 + temp_avg_dmg_spec_4) * temp_hit_chance;

                            // 0-4-2-2 case
                            special_max_hit_1 = 0;
                            special_max_hit_2 = Math.Floor(temp_max_hit * 0.875);
                            dragon_claw_spec_min_hit = Math.Floor(temp_max_hit * 0.375);
                            special_max_hit_3 = Math.Floor(special_max_hit_2 / 2);
                            special_max_hit_4 = special_max_hit_3 + 1;

                            temp_avg_dmg_spec_1 = 0;
                            temp_avg_dmg_spec_2 = (special_max_hit_2 - dragon_claw_spec_min_hit) / 2 + dragon_claw_spec_min_hit;
                            temp_avg_dmg_spec_3 = special_max_hit_3 / 2;
                            temp_avg_dmg_spec_4 = special_max_hit_4 / 2;

                            temp_total_dclaw_avg_dmg += (temp_avg_dmg_spec_1 + temp_avg_dmg_spec_2 + temp_avg_dmg_spec_3 + temp_avg_dmg_spec_4) * ((1 - temp_hit_chance) * temp_hit_chance);

                            // 0-0-3-3 case
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;                            
                            special_max_hit_3 = Math.Floor(temp_max_hit * 0.75);
                            dragon_claw_spec_min_hit = Math.Floor(temp_max_hit * 0.25);
                            special_max_hit_4 = special_max_hit_3 + 1;

                            temp_avg_dmg_spec_1 = 0;
                            temp_avg_dmg_spec_2 = 0;
                            temp_avg_dmg_spec_3 = (special_max_hit_3 - dragon_claw_spec_min_hit) / 2 + dragon_claw_spec_min_hit;
                            temp_avg_dmg_spec_4 = special_max_hit_4 / 2;

                            temp_total_dclaw_avg_dmg += (temp_avg_dmg_spec_1 + temp_avg_dmg_spec_2 + temp_avg_dmg_spec_3 + temp_avg_dmg_spec_4) * (Math.Pow((1 - temp_hit_chance),2) * temp_hit_chance);

                            // 0-0-0-5 case
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                            special_max_hit_3 = 0;              
                            special_max_hit_4 = Math.Floor(temp_max_hit * 1.25);
                            dragon_claw_spec_min_hit = Math.Floor(temp_max_hit * 0.25);

                            temp_avg_dmg_spec_1 = 0;
                            temp_avg_dmg_spec_2 = 0;
                            temp_avg_dmg_spec_3 = 0;
                            temp_avg_dmg_spec_4 = (special_max_hit_4 - dragon_claw_spec_min_hit) / 2 + dragon_claw_spec_min_hit;

                            temp_total_dclaw_avg_dmg += (temp_avg_dmg_spec_1 + temp_avg_dmg_spec_2 + temp_avg_dmg_spec_3 + temp_avg_dmg_spec_4) * (Math.Pow((1 - temp_hit_chance), 3) * temp_hit_chance);

                            // 0-0-0-0 case
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                            special_max_hit_3 = 0;
                            special_max_hit_4 = 1;

                            temp_avg_dmg_spec_1 = 0;
                            temp_avg_dmg_spec_2 = 0;
                            temp_avg_dmg_spec_3 = 0;
                            temp_avg_dmg_spec_4 = 1;

                            temp_total_dclaw_avg_dmg += (temp_avg_dmg_spec_1 + temp_avg_dmg_spec_2 + temp_avg_dmg_spec_3 + temp_avg_dmg_spec_4) * (Math.Pow((1 - temp_hit_chance), 4) * temp_hit_chance);

                            temp_avg_dmg_per_attack = temp_total_dclaw_avg_dmg;

                            special_max_hit_1 = temp_max_hit - 1;
                            special_max_hit_2 = Math.Floor(special_max_hit_1 / 2);
                            special_max_hit_3 = Math.Floor(special_max_hit_2 / 2);
                            special_max_hit_4 = special_max_hit_3 + 1;

                            temp_max_hit = special_max_hit_1 + special_max_hit_2 + special_max_hit_3 + special_max_hit_4;

                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                            special_max_hit_3 = 0;
                            special_max_hit_4 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        special_max_hit_3_array[dps_calc_fix] = special_max_hit_3;
                        special_max_hit_4_array[dps_calc_fix] = special_max_hit_4;
                        break;
                    case "Voidwaker":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        temp_hit_chance = 1;
                        if (temp_max_hit > -1)
                        {
                            spec_min_hit = Math.Floor(temp_max_hit * 0.5);
                            special_max_hit_1 = Math.Floor(temp_max_hit * 1.5);

                            temp_max_hit = spec_min_hit;
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            spec_min_hit = temp_max_hit;

                            temp_max_hit = special_max_hit_1;
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);         
                            special_max_hit_1 = temp_max_hit;

                            

                            temp_avg_dmg_per_attack = (special_max_hit_1 - spec_min_hit) / 2 + spec_min_hit;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            spec_min_hit = 0;
                        }
                        spec_min_hit_array[dps_calc_fix] = spec_min_hit;
                        break;
                    case "Granite hammer":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        special_max_hit_2 = special_additional_dmg;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_array[x] = temp_immune;
                            special_max_hit_1 = temp_max_hit;

                            temp_max_hit = special_additional_dmg;
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_2_array[x] = temp_immune;
                            special_max_hit_2 = temp_max_hit;

                            temp_max_hit = special_max_hit_1 + special_max_hit_2;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        break;
                    case "Granite maul":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        temp_weapon_attack_speed = 0;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            special_max_hit_1 = temp_max_hit;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Ursine chainmace":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        special_max_hit_2 = special_additional_dmg;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {

                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_array[x] = temp_immune;
                            special_max_hit_1 = temp_max_hit;

                            temp_max_hit = special_additional_dmg;
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_2_array[x] = temp_immune;
                            special_max_hit_2 = temp_max_hit;

                            temp_max_hit = special_max_hit_1 + special_max_hit_2;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        break;
                    case "Ancient godsword":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            temp_weapon_type = "slash";
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_array[x] = temp_immune;
                            special_max_hit_1 = temp_max_hit;

                            temp_weapon_type = "magic";
                            temp_max_hit = special_additional_dmg;
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_2_array[x] = temp_immune;
                            special_max_hit_2 = temp_max_hit;

                            temp_max_hit = special_max_hit_1 + special_max_hit_2;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        break;
                    case "Osmumten's fang":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            if (monster_name == "Corporeal Beast")
                            {
                                temp_weapon_type = weapon_type_array[corp_style_fix];
                                Dispatcher.Invoke(immunities_and_resistances);
                                special_immune_array[x] = temp_immune;
                            }
                            else
                            {
                                Dispatcher.Invoke(immunities_and_resistances);
                                special_immune_array[x] = temp_immune;
                            }
                            special_attack_fix = true;
                            Dispatcher.Invoke(average_dmg);
                            special_attack_fix = false;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;

                            osmumtens_fang_max_hit = 0;
                            osmumtens_fang_min_hit = 0;
                        }
                        spec_min_hit_array[dps_calc_fix] = osmumtens_fang_min_hit;
                        break;
                    case "Dragon warhammer":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            dwh_avg_def_reduction_list[dps_calc_fix] = Math.Floor(monster_reduced_def_lvl * (0.3 * (temp_hit_chance * (temp_max_hit / (temp_max_hit + 1)))));

                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Keris partisan of corruption":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Abyssal bludgeon":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        if (prayer_remaining < prayer_lvl)
                        {
                            temp_max_hit = Math.Floor(temp_max_hit * (1 + ((prayer_lvl - prayer_remaining) * 0.005)));
                        }                       
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Saradomin's blessed sword":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            temp_weapon_type = "slash";
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Saradomin sword": // also known as spaghetti monster
                        temp_max_hit = special_max_hit_1;
                        special_max_hit_2 = 16;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        special_hit_chance_1 = temp_hit_chance;
                        temp_weapon_type = "magic";
                        Dispatcher.Invoke(hit_chance);
                        special_hit_chance_2 = temp_hit_chance;
                        if (temp_max_hit > -1)
                        {
                            temp_weapon_type = "slash";
                            temp_hit_chance = special_hit_chance_1;
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_array[x] = temp_immune;
                            special_max_hit_1 = temp_max_hit;
                            special_average_dmg_1 = temp_avg_dmg_per_attack;

                            temp_weapon_type = "magic";
                            temp_max_hit = special_max_hit_2;
                            temp_hit_chance = special_hit_chance_2;
                            Dispatcher.Invoke(immunities_and_resistances);
                            Dispatcher.Invoke(average_dmg);
                            special_immune_2_array[x] = temp_immune;
                            special_max_hit_2 = temp_max_hit;
                            special_average_dmg_2 = temp_avg_dmg_per_attack;

                            temp_hit_chance = (special_hit_chance_1 + special_hit_chance_2) / 2;

                            temp_avg_dmg_per_attack = special_average_dmg_1 + special_average_dmg_2;
                            temp_max_hit = special_max_hit_1 + special_max_hit_2;

                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                            special_max_hit_2 = 0;
                            special_average_dmg_1 = 0;
                            special_average_dmg_2 = 0;
                        }

                        special_hit_chance_1_array[dps_calc_fix] = special_hit_chance_1;
                        special_hit_chance_2_array[dps_calc_fix] = special_hit_chance_2;
                        special_average_dmg_1_array[dps_calc_fix] = special_average_dmg_1;
                        special_average_dmg_2_array[dps_calc_fix] = special_average_dmg_2;
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        break;
                    case "Dawnbringer":
                        if (monster_name == "Verzik vitur P1" || monster_name == "Combat dummy")
                        {
                            temp_max_hit = 150;
                            temp_hit_chance = 1;
                            temp_max_attack_roll = special_attack_roll_1;
                        }
                        else
                        {
                            temp_max_hit = 0;
                            temp_hit_chance = 0;
                            temp_max_attack_roll = 0;
                        }                                             
                        if (temp_max_hit > -1)
                        {
                            temp_avg_dmg_per_attack = 112.5;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        spec_min_hit = Math.Floor(temp_max_hit * 0.5);
                        spec_min_hit_array[dps_calc_fix] = spec_min_hit;
                        break;
                    case "Eldritch nightmare staff":
                    case "Volatile nightmare staff": // also known as spaghetti monster 2 and 3
                        double magic_number;
                        if (weapon_name_array[x] == "Volatile nightmare staff")
                        {
                            magic_number = 0.58585858585858585858585858585859;
                        }
                        else
                        {
                            magic_number = 0.44444444444444444444444444444444;
                        }

                        if ((helmet_name_array[x] == "Slayer helmet (i)" && slayer_task_checkbox.IsChecked == true) && !(amulet_name_array[x] == "Salve amulet (ei)" && monster_is_undead == true))
                        {
                            slayer_helm_bonus_mega_temp = 1.15;
                            gear_bonus_range_and_mage = 1.15;
                        }                     
                        if (amulet_name_array[x] == "Salve amulet (ei)" && monster_is_undead == true)
                        {
                            temp_magic_dmg += 20;
                            gear_bonus_range_and_mage = 1.2;
                        }
                        if (helmet_name_array[x] == "Void helmet" && body_name_array[x] == "Elite void top" && legs_name_array[x] == "Elite void robe" && gloves_name_array[x] == "Void gloves")
                        {
                            temp_magic_dmg += 2.5;
                        }

                        if (magic_lvl_and_pot > 98)
                        {
                            temp_max_hit = Math.Floor(Math.Floor(1 + (magic_number * 98)) * slayer_helm_bonus_mega_temp);
                            temp_max_hit = Math.Floor(temp_max_hit * (1 + ((temp_magic_dmg + total_magic_dmg_array[x]) / 100)));
                        }
                        else
                        {
                            temp_max_hit = Math.Floor(Math.Floor(1 + (magic_number * magic_lvl_and_pot)) * slayer_helm_bonus_mega_temp);
                            temp_max_hit = Math.Floor(temp_max_hit * (1 + ((temp_magic_dmg + total_magic_dmg_array[x]) / 100)));
                        }
                        
                        if (temp_max_hit < 1)
                        {
                            temp_max_hit = 1;
                        }

                        if (helmet_name_array[x] == "Void helmet" && (body_name_array[x] == "Void top" || body_name_array[x] == "Elite void top") && (legs_name_array[x] == "Void robe" || legs_name_array[x] == "Elite void robe") && gloves_name_array[x] == "Void gloves")
                        {
                            temp_effective_mage_lvl = Math.Floor(true_mage_lvl * 1.45) + 9;
                        }
                        else
                        {
                            temp_effective_mage_lvl = true_mage_lvl + 9;
                        }

                        temp_max_attack_roll = Math.Floor(temp_effective_mage_lvl * (total_magic_atk_array[x] + 64) * gear_bonus_range_and_mage);
                        if (weapon_name_array[x] == "Volatile nightmare staff")
                        {
                            temp_max_attack_roll = Math.Floor(temp_max_attack_roll * 1.5);
                            Dispatcher.Invoke(hit_chance);
                        }
                        Dispatcher.Invoke(hit_chance);

                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Dragon crossbow":
                    case "Armadyl crossbow":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(bolt_proc_effects);
                            if (weapon_name_array[x] == "Armadyl crossbow")
                            {
                                bolt_proc_chance = bolt_proc_chance_acb_spec;
                            }
                            else
                            {
                                bolt_proc_chance = 0;
                            }
                            switch (ammo_name_array[x])
                            {
                                case "Dragonstone dragon bolts (e)":
                                case "Dragonstone bolts (e)":
                                case "Onyx dragon bolts (e)":
                                case "Onyx bolts (e)": // bolt needs to hit to get bolt proc effect
                                    Dispatcher.Invoke(immunities_and_resistances);
                                    special_immune_array[x] = temp_immune;
                                    Dispatcher.Invoke(average_dmg);
                                    double temp_temp_max_hit = temp_max_hit;
                                    double temp_temp_avg_dmg = temp_avg_dmg_per_attack;
                                    temp_max_hit = bolt_proc_dmg;
                                    Dispatcher.Invoke(immunities_and_resistances);
                                    Dispatcher.Invoke(average_dmg);

                                    bolt_normal_dmg_array[dps_calc_fix + 8] = temp_temp_max_hit;
                                    bolt_proc_dmg_array[dps_calc_fix + 8] = temp_max_hit;
                                    bolt_proc_chance_array[dps_calc_fix + 8] = bolt_proc_chance;
                                    temp_max_hit = ((100 - bolt_proc_chance) / 100 * temp_temp_max_hit) + (bolt_proc_chance / 100 * temp_max_hit);
                                    temp_avg_dmg_per_attack = ((100 - bolt_proc_chance) / 100 * temp_temp_avg_dmg) + (bolt_proc_chance / 100 * temp_avg_dmg_per_attack);

                                    break;
                                default: // bypasses accuracy check
                                    Dispatcher.Invoke(immunities_and_resistances);
                                    special_immune_array[x] = temp_immune;
                                    Dispatcher.Invoke(average_dmg);
                                    temp_temp_max_hit = temp_max_hit;
                                    temp_temp_avg_dmg = temp_avg_dmg_per_attack;
                                    double temp_temp_hit_chance = temp_hit_chance;
                                    if (ammo_name_array[x] == "Ruby dragon bolts (e)" || ammo_name_array[x] == "Ruby bolts (e)")
                                    {
                                        temp_temp_avg_dmg = temp_temp_avg_dmg / 2;
                                    }
                                    temp_max_hit = bolt_proc_dmg;
                                    temp_hit_chance = 1;
                                    Dispatcher.Invoke(immunities_and_resistances);
                                    Dispatcher.Invoke(average_dmg);

                                    bolt_normal_dmg_array[dps_calc_fix + 8] = temp_temp_max_hit;
                                    bolt_proc_dmg_array[dps_calc_fix + 8] = temp_max_hit;
                                    bolt_proc_chance_array[dps_calc_fix + 8] = bolt_proc_chance;

                                    temp_hit_chance = temp_temp_hit_chance;
                                    temp_max_hit = ((100 - bolt_proc_chance) / 100 * temp_temp_max_hit) + (bolt_proc_chance / 100 * temp_max_hit);
                                    temp_avg_dmg_per_attack = ((100 - bolt_proc_chance) / 100 * temp_temp_avg_dmg) + (bolt_proc_chance / 100 * temp_avg_dmg_per_attack);
                                    break;
                            }
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Zaryte crossbow":
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        Dispatcher.Invoke(bolt_proc_effects);
                        temp_max_hit = bolt_proc_dmg;
                        Dispatcher.Invoke(immunities_and_resistances);
                        special_immune_array[x] = temp_immune;
                        Dispatcher.Invoke(average_dmg);
                        if (temp_max_hit > -1)
                        {
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    // the odd dmg calcs for range spec
                    case "Magic shortbow":
                    case "Magic shortbow (i)":
                        temp_effective_range_str = 3; // spec uses allways accurate style bonus?? but attack speed stays on rapid if was on rapid
                        temp_effective_range_str = temp_effective_range_str + range_lvl_and_pot + 8; // prayer has no effect
                        temp_max_hit = ((temp_effective_range_str * (range_str_array[y + 3] + 64)) / 640) + 0.5; // only considers range str bonus from arrows
                        temp_max_hit = Math.Floor(temp_max_hit);
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            special_max_hit_1 = temp_max_hit;
                            special_max_hit_2 = temp_max_hit;

                            temp_max_hit = temp_max_hit * 2;
                            temp_avg_dmg_per_attack = temp_avg_dmg_per_attack * 2;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_2;
                        break;
                    case "Magic longbow":
                        temp_effective_range_str = 3; // spec uses allways accurate style bonus?? but attack speed stays on rapid if was on rapid
                        temp_effective_range_str = temp_effective_range_str + range_lvl_and_pot + 8; // prayer has no effect
                        temp_max_hit = ((temp_effective_range_str * (range_str_array[y + 3] + 64)) / 640) + 0.5; // only considers range str bonus from arrows
                        temp_max_hit = Math.Floor(temp_max_hit);
                        temp_max_attack_roll = special_attack_roll_1;
                        temp_hit_chance = 1;
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);

                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    case "Dark bow":
                        if (ammo_name_array[x] == "Dragon arrows")
                        {
                            temp_max_hit = Math.Floor(special_max_hit_1 * 1.5);
                            spec_min_hit = 8;
                        }
                        else
                        {
                            temp_max_hit = Math.Floor(special_max_hit_1 * 1.3);
                            spec_min_hit = 5;
                        }

                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            special_max_hit_1 = temp_max_hit;

                            temp_max_hit = spec_min_hit;
                            Dispatcher.Invoke(immunities_and_resistances);
                            spec_min_hit = temp_max_hit;

                            if (monster_name == "Verzik vitur P1")
                            {
                                special_max_hit_1 = 3;
                                spec_min_hit = 3;
                            }

                            temp_max_hit = Math.Min(special_max_hit_1, 48) * 2;

                            double[] dark_bow_dmg_dist = new double[Convert.ToInt32(special_max_hit_1)];
                            dark_bow_dmg_dist[0] = 1 - temp_hit_chance;
                            for (int i = 1; i < special_max_hit_1; i++)
                            {
                                if (i < spec_min_hit)
                                {
                                    dark_bow_dmg_dist[i] = spec_min_hit * temp_hit_chance;
                                }
                                else if (i < 49)
                                {
                                    dark_bow_dmg_dist[i] = i * temp_hit_chance;
                                }
                                else
                                {
                                    dark_bow_dmg_dist[i] = 48 * temp_hit_chance;
                                }
                            }

                            temp_avg_dmg_per_attack = (dark_bow_dmg_dist.Sum() / dark_bow_dmg_dist.Length) * 2;

                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        spec_min_hit_array[dps_calc_fix] = spec_min_hit;
                        break;
                    case "Webweaver bow":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            temp_max_hit = Math.Floor(temp_max_hit * 0.4);
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            special_max_hit_1 = temp_max_hit;
                            temp_max_hit = temp_max_hit * 4;
                            temp_avg_dmg_per_attack = temp_avg_dmg_per_attack * 4;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                            special_max_hit_1 = 0;
                        }
                        special_max_hit_1_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_2_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_3_array[dps_calc_fix] = special_max_hit_1;
                        special_max_hit_4_array[dps_calc_fix] = special_max_hit_1;
                        break;
                    case "Dragon thrownaxe":
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        temp_weapon_attack_speed = 1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            special_max_hit_1 = temp_max_hit;
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                    default:
                        temp_max_hit = special_max_hit_1;
                        temp_max_attack_roll = special_attack_roll_1;
                        Dispatcher.Invoke(hit_chance);
                        if (temp_max_hit > -1)
                        {
                            Dispatcher.Invoke(immunities_and_resistances);
                            special_immune_array[x] = temp_immune;
                            Dispatcher.Invoke(average_dmg);
                            if (overkill_checkbox.IsChecked == true && temp_max_hit > 0)
                            {
                                Dispatcher.Invoke(overkill);
                            }
                            else
                            {
                                temp_avg_hits_to_kill = 0;
                            }
                        }
                        else
                        {
                            temp_avg_dmg_per_attack = 0;
                            temp_avg_hits_to_kill = 0;
                        }
                        break;
                }

                if (temp_hit_chance > 0)
                {
                    max_hit_list.Add(temp_max_hit);

                    max_attack_roll_list.Add(temp_max_attack_roll);

                    hit_chance_list.Add(Math.Round(temp_hit_chance, 15) * 100);

                    avg_dmg_per_attack_list.Add(Math.Round(temp_avg_dmg_per_attack, 15));

                    if (temp_avg_hits_to_kill == 0)
                    {
                        overkill_avg_dmg_per_attack_list.Add(0);
                    }
                    else
                    {
                        overkill_avg_dmg_per_attack_list.Add(Math.Round(monster_reduced_hp_lvl / temp_avg_hits_to_kill, 15));
                    }

                    // odd spec weapons where base and spec dmg types are different
                    if (weapon_name_array[x] == "Saradomin sword" || weapon_name_array[x] == "Ancient godsword")
                    {
                        if ((special_immune_array[x] == true && special_immune_2_array[x] == true) || temp_max_hit == 0)
                        {
                            dps_list.Add(0);
                            overkill_dps_list.Add(0);
                            time_to_kill_list.Add(0);
                            avg_hits_to_kill_list.Add(0);
                        }
                        else
                        {
                            avg_hits_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill, 15));
                            dps_list.Add(Math.Round(temp_avg_dmg_per_attack / (temp_weapon_attack_speed * 0.6), 15));
                            if (temp_avg_hits_to_kill == 0)
                            {
                                overkill_dps_list.Add(0);
                                time_to_kill_list.Add(0);
                            }
                            else
                            {
                                overkill_dps_list.Add(Math.Round(monster_reduced_hp_lvl / (temp_avg_hits_to_kill * (temp_weapon_attack_speed * 0.6)), 15));
                                time_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill * (temp_weapon_attack_speed * 0.6), 15));
                            }
                        }
                    }
                    // normal spec weapons
                    else
                    {
                        if (special_immune_array[x] == true || temp_max_hit == 0)
                        {
                            dps_list.Add(0);
                            overkill_dps_list.Add(0);
                            time_to_kill_list.Add(0);
                            avg_hits_to_kill_list.Add(0);
                        }
                        else
                        {
                            avg_hits_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill, 15));

                            if (temp_weapon_stance == "rapid" && weapon_name_array[x] != "Dragon thrownaxe") // yeah spaghetti fix
                            {
                                dps_list.Add(Math.Round(temp_avg_dmg_per_attack / ((temp_weapon_attack_speed - 1) * 0.6), 15));
                                if (temp_avg_hits_to_kill == 0)
                                {
                                    overkill_dps_list.Add(0);
                                    time_to_kill_list.Add(0);
                                }
                                else
                                {
                                    overkill_dps_list.Add(Math.Round(monster_reduced_hp_lvl / (temp_avg_hits_to_kill * ((temp_weapon_attack_speed - 1) * 0.6)), 15));
                                    time_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill * ((temp_weapon_attack_speed - 1) * 0.6), 15));
                                }

                            }
                            else
                            {
                                dps_list.Add(Math.Round(temp_avg_dmg_per_attack / (temp_weapon_attack_speed * 0.6), 15));
                                if (temp_avg_hits_to_kill == 0)
                                {
                                    overkill_dps_list.Add(0);
                                    time_to_kill_list.Add(0);
                                }
                                else
                                {
                                    overkill_dps_list.Add(Math.Round(monster_reduced_hp_lvl / (temp_avg_hits_to_kill * (temp_weapon_attack_speed * 0.6)), 15));
                                    time_to_kill_list.Add(Math.Round(temp_avg_hits_to_kill * (temp_weapon_attack_speed * 0.6), 15));
                                }

                            }
                        }
                    }

                }
                else
                {
                    max_hit_list.Add(0);
                    max_attack_roll_list.Add(temp_max_attack_roll);
                    hit_chance_list.Add(0);
                    avg_dmg_per_attack_list.Add(0);
                    overkill_avg_dmg_per_attack_list.Add(0);
                    dps_list.Add(0);
                    overkill_dps_list.Add(0);
                    avg_hits_to_kill_list.Add(0);
                    time_to_kill_list.Add(0);
                }
            }
            else
            {
                max_hit_list.Add(0);
                max_attack_roll_list.Add(0);
                hit_chance_list.Add(0);
                avg_dmg_per_attack_list.Add(0);
                overkill_avg_dmg_per_attack_list.Add(0);
                dps_list.Add(0);
                overkill_dps_list.Add(0);
                avg_hits_to_kill_list.Add(0);
                time_to_kill_list.Add(0);

                bolt_normal_dmg_array[dps_calc_fix + 8] = 0;
                bolt_proc_dmg_array[dps_calc_fix + 8] = 0;
                bolt_proc_chance_array[dps_calc_fix + 8] = 0;
            }


        }
        private void monster_max_hit_and_atk_roll()
        {
            // max hits and attack rolls
            // set 1
            monster_max_hit_array[0] = Math.Floor((((monster_reduced_str_lvl + 9) * (monster_aggressive_str + 64)) + 320) / 640.0);
            monster_max_hit_array[1] = monster_max_hit_array[0];
            monster_max_hit_array[2] = monster_max_hit_array[0];
            monster_max_hit_array[3] = Math.Floor(((monster_boosted_magic_lvl + 9) * (monster_aggressive_magic_dmg + 64) / 640.0) + 0.5); // gets max hit from "base" mage lvl before reductions
            monster_max_hit_array[4] = Math.Floor(((monster_reduced_range_lvl + 9) * (monster_aggressive_range_str + 64) / 640.0) + 0.5);

            monster_attack_roll_array[0] = (monster_reduced_atk_lvl + 9) * (monster_aggressive_atk + 64);
            monster_attack_roll_array[1] = monster_attack_roll_array[0];
            monster_attack_roll_array[2] = monster_attack_roll_array[0];
            monster_attack_roll_array[4] = (monster_reduced_magic_lvl + 9) * (monster_aggressive_magic + 64);
            monster_attack_roll_array[3] = (monster_reduced_range_lvl + 9) * (monster_aggressive_range + 64);

            // set 2
            monster_max_hit_array[5] = monster_max_hit_array[0];
            monster_max_hit_array[6] = monster_max_hit_array[0];
            monster_max_hit_array[7] = monster_max_hit_array[0];
            monster_max_hit_array[8] = monster_max_hit_array[3];
            monster_max_hit_array[9] = monster_max_hit_array[4];

            monster_attack_roll_array[5] = monster_attack_roll_array[0];
            monster_attack_roll_array[6] = monster_attack_roll_array[0];
            monster_attack_roll_array[7] = monster_attack_roll_array[0];
            monster_attack_roll_array[8] = monster_attack_roll_array[3];
            monster_attack_roll_array[9] = monster_attack_roll_array[4];

            // toa scaling
            if (monster_is_in_toa == true)
            {
                double max_hit_modifier = 1 + toa_raid_lvl * 0.004;
                double attack_roll_modifier = 1 + toa_raid_lvl * 0.004;

                if (toa_path_lvl > 0)
                {
                    max_hit_modifier = max_hit_modifier * (1.03 + 0.05 * toa_path_lvl);
                }

                for (int i = 0; i < 10; i++)
                {
                    monster_max_hit_array[i] = Math.Floor(monster_max_hit_array[i] * Math.Min(max_hit_modifier, 2.5));
                    monster_attack_roll_array[i] = Math.Floor(monster_attack_roll_array[i] * attack_roll_modifier);
                }
            }

        }
        private void monster_hit_chance_and_avg_dmg()
        {

            // get style bonus from set comparison data
            if (compare_styles_set_1_combobox.SelectedItem == null)
            {
                compare_styles_set_1_combobox.SelectedIndex = 0;
            }
            if (compare_styles_set_2_combobox.SelectedItem == null)
            {
                compare_styles_set_2_combobox.SelectedIndex = 0;
            }

            int style_bonus_set_1 = compare_styles_set_1_combobox.SelectedIndex;
            int style_bonus_set_2 = compare_styles_set_2_combobox.SelectedIndex + 4;

            // recycle special attack selection back to normal attack selection index
            if (style_bonus_set_1 >= 4)
            {
                style_bonus_set_1 -= 4;
            }
            if (style_bonus_set_2 >= 8)
            {
                style_bonus_set_2 -= 4;
            }

            int style_bonus = style_bonus_set_1;
            int k = 0;
            if (show_set_2 == true)
            {
                style_bonus = style_bonus_set_2;
                k = 5;
            }


            // player defence roll and justiciar armour set dmg reduction 

            int j = 0;
            for (int i = k; i < 5 + k; i++)
            {
                if (i == 5)
                {
                    j = 1;
                }

                switch (i)
                {
                    case 0:
                    case 5:
                        player_def_roll_array[i] = (true_defence_lvl + style_bonus_def_array[style_bonus] + 8) * (total_stab_def_array[j] + 64);
                        if (helmet_name_array[j] == "Justiciar faceguard" && body_name_array[j] == "Justiciar chestguard" && legs_name_array[j] == "Justiciar legguards")
                        {
                            monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * Math.Max(total_stab_def_array[j] / 3000.0, 0));
                        }
                        monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * melee_prayer_effectiviness / 100.0);
                        break;
                    case 1:
                    case 6:
                        player_def_roll_array[i] = (true_defence_lvl + style_bonus_def_array[style_bonus] + 8 ) * (total_slash_def_array[j] + 64);
                        if (helmet_name_array[j] == "Justiciar faceguard" && body_name_array[j] == "Justiciar chestguard" && legs_name_array[j] == "Justiciar legguards")
                        {
                            monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * Math.Max(total_slash_def_array[j] / 3000.0, 0));
                        }
                        monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * melee_prayer_effectiviness / 100.0);
                        break;
                    case 2:
                    case 7:
                        player_def_roll_array[i] = (true_defence_lvl + style_bonus_def_array[style_bonus] + 8) * (total_crush_def_array[j] + 64);
                        if (helmet_name_array[j] == "Justiciar faceguard" && body_name_array[j] == "Justiciar chestguard" && legs_name_array[j] == "Justiciar legguards")
                        {
                            monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * Math.Max(total_crush_def_array[j] / 3000.0, 0));
                        }
                        monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * melee_prayer_effectiviness / 100.0);
                        break;
                    case 3:
                    case 8:
                        player_def_roll_array[i] = Math.Floor(true_defence_lvl * 0.30 + true_mage_lvl * 0.70 + style_bonus_def_array[style_bonus] + 8) * (total_magic_def_array[j] + 64);
                        if (helmet_name_array[j] == "Justiciar faceguard" && body_name_array[j] == "Justiciar chestguard" && legs_name_array[j] == "Justiciar legguards")
                        {
                            monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * Math.Max(total_magic_def_array[j] / 3000.0, 0));
                        }
                        monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * mage_prayer_effectiviness / 100.0);
                        break;
                    case 4:
                    case 9:
                        player_def_roll_array[i] = (true_defence_lvl + style_bonus_def_array[style_bonus] + 8) * (total_range_def_array[j] + 64);
                        if (helmet_name_array[j] == "Justiciar faceguard" && body_name_array[j] == "Justiciar chestguard" && legs_name_array[j] == "Justiciar legguards")
                        {
                            monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * Math.Max(total_range_def_array[j] / 3000.0, 0));
                        }
                        monster_max_hit_array[i] = monster_max_hit_array[i] - Math.Floor(monster_max_hit_array[i] * range_prayer_effectiviness / 100.0);
                        break;
                }
            }

            // hit chance and avg dmg for all styles

            for (int i = k; i < 5 + k; i++)
            {

                if (monster_attack_roll_array[i] > player_def_roll_array[i])
                {
                    monster_hit_chance_array[i] = Math.Round(1 - (player_def_roll_array[i] + 2) / (2 * (monster_attack_roll_array[i] + 1)), 5);
                }
                else
                {
                    monster_hit_chance_array[i] = Math.Round(monster_attack_roll_array[i] / (2 * (player_def_roll_array[i] + 1)), 5);
                }

                monster_avg_dmg_array[i] = Math.Round((monster_max_hit_array[i] * monster_hit_chance_array[i]) / 2.0, 5);
            }

            // update textboxes

            for (int i = k; i < 5 + k; i++)
            {
                TextBox textBox = (TextBox)FindName($"monster_max_hit_{i - k + 1}_textbox");
                textBox.Text = "" + monster_max_hit_array[i];
                textBox = (TextBox)FindName($"monster_attack_roll_{i - k + 1}_textbox");
                textBox.Text = "" + monster_attack_roll_array[i] + " || " + player_def_roll_array[i];
                textBox = (TextBox)FindName($"monster_hit_chance_{i - k + 1}_textbox");
                textBox.Text = "" + monster_hit_chance_array[i] * 100 + "%";
                textBox = (TextBox)FindName($"monster_avg_dmg_{i - k + 1}_textbox");
                textBox.Text = "" + monster_avg_dmg_array[i];
            }
        }
        private void UpdateUI()
        {
            string tooltip_content = "";
            ToolTip customToolTip = new ToolTip
            {
                Content = tooltip_content,
                Template = FindResource("CustomTooltipTemplate") as ControlTemplate
            };

            // multiple calcs is false, so update ui
            if (multiple_calcs == false)
            {
                presets_set_1_combobox.Text = "Presets";
                presets_potions_combobox.Text = "Presets";
                presets_prayers_combobox.Text = "Presets";

                for (int i = 1; i < 3; i++)
                {
                    int j = 0;

                    if (i == 2)
                    {
                        j = 11;
                    }


                    ComboBox ComboBox = (ComboBox)FindName($"weapon_set_{i}_combobox");
                    ComboBox.Text = weapon_name_array[i - 1];
                    tooltip_content = weapon_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 4] + " || Magic " + magic_atk_array[j + 4] + "\n Slash " + slash_atk_array[j + 4] + " || Magic dmg " + magic_dmg_array[j + 4] + "\n Crush " + crush_atk_array[j + 4] + " || Range " + range_atk_array[j + 4] + "\n Str " + melee_str_array[j + 4] + " || Range str " + range_str_array[j + 4];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 4] + " || Magic " + magic_def_array[j + 4] + "\n Slash " + slash_def_array[j + 4] + " || Range " + range_def_array[j + 4] + "\n Crush " + crush_def_array[j + 4] + " || Prayer " + prayer_bonus_array[j + 4];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"spell_set_{i}_combobox");
                    ComboBox.Text = spell_name_array[i - 1];
                    tooltip_content = spell_name_array[i - 1];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"ammo_set_{i}_combobox");
                    ComboBox.Text = ammo_name_array[i - 1];
                    tooltip_content = ammo_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 3] + " || Magic " + magic_atk_array[j + 3] + "\n Slash " + slash_atk_array[j + 3] + " || Magic dmg " + magic_dmg_array[j + 3] + "\n Crush " + crush_atk_array[j + 3] + " || Range " + range_atk_array[j + 3] + "\n Str " + melee_str_array[j + 3] + " || Range str " + range_str_array[j + 3];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 3] + " || Magic " + magic_def_array[j + 3] + "\n Slash " + slash_def_array[j + 3] + " || Range " + range_def_array[j + 3] + "\n Crush " + crush_def_array[j + 3] + " || Prayer " + prayer_bonus_array[j + 3];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"helmet_set_{i}_combobox");
                    ComboBox.Text = helmet_name_array[i - 1];
                    tooltip_content = helmet_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 0] + " || Magic " + magic_atk_array[j + 0] + "\n Slash " + slash_atk_array[j + 0] + " || Magic dmg " + magic_dmg_array[j + 0] + "\n Crush " + crush_atk_array[j + 0] + " || Range " + range_atk_array[j + 0] + "\n Str " + melee_str_array[j + 0] + " || Range str " + range_str_array[j + 0];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 0] + " || Magic " + magic_def_array[j + 0] + "\n Slash " + slash_def_array[j + 0] + " || Range " + range_def_array[j + 0] + "\n Crush " + crush_def_array[j + 0] + " || Prayer " + prayer_bonus_array[j + 0];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"cape_set_{i}_combobox");
                    ComboBox.Text = cape_name_array[i - 1];
                    tooltip_content = cape_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 1] + " || Magic " + magic_atk_array[j + 1] + "\n Slash " + slash_atk_array[j + 1] + " || Magic dmg " + magic_dmg_array[j + 1] + "\n Crush " + crush_atk_array[j + 1] + " || Range " + range_atk_array[j + 1] + "\n Str " + melee_str_array[j + 1] + " || Range str " + range_str_array[j + 1];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 1] + " || Magic " + magic_def_array[j + 1] + "\n Slash " + slash_def_array[j + 1] + " || Range " + range_def_array[j + 1] + "\n Crush " + crush_def_array[j + 1] + " || Prayer " + prayer_bonus_array[j + 1];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"necklace_set_{i}_combobox");
                    ComboBox.Text = amulet_name_array[i - 1];
                    tooltip_content = amulet_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 2] + " || Magic " + magic_atk_array[j + 2] + "\n Slash " + slash_atk_array[j + 2] + " || Magic dmg " + magic_dmg_array[j + 2] + "\n Crush " + crush_atk_array[j + 2] + " || Range " + range_atk_array[j + 2] + "\n Str " + melee_str_array[j + 2] + " || Range str " + range_str_array[j + 2];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 2] + " || Magic " + magic_def_array[j + 2] + "\n Slash " + slash_def_array[j + 2] + " || Range " + range_def_array[j + 2] + "\n Crush " + crush_def_array[j + 2] + " || Prayer " + prayer_bonus_array[j + 2];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"body_set_{i}_combobox");
                    ComboBox.Text = body_name_array[i - 1];
                    tooltip_content = body_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 5] + " || Magic " + magic_atk_array[j + 5] + "\n Slash " + slash_atk_array[j + 5] + " || Magic dmg " + magic_dmg_array[j + 5] + "\n Crush " + crush_atk_array[j + 5] + " || Range " + range_atk_array[j + 5] + "\n Str " + melee_str_array[j + 5] + " || Range str " + range_str_array[j + 5];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 5] + " || Magic " + magic_def_array[j + 5] + "\n Slash " + slash_def_array[j + 5] + " || Range " + range_def_array[j + 5] + "\n Crush " + crush_def_array[j + 5] + " || Prayer " + prayer_bonus_array[j + 5];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"legs_set_{i}_combobox");
                    ComboBox.Text = legs_name_array[i - 1];
                    tooltip_content = legs_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 7] + " || Magic " + magic_atk_array[j + 7] + "\n Slash " + slash_atk_array[j + 7] + " || Magic dmg " + magic_dmg_array[j + 7] + "\n Crush " + crush_atk_array[j + 7] + " || Range " + range_atk_array[j + 7] + "\n Str " + melee_str_array[j + 7] + " || Range str " + range_str_array[j + 7];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 7] + " || Magic " + magic_def_array[j + 7] + "\n Slash " + slash_def_array[j + 7] + " || Range " + range_def_array[j + 7] + "\n Crush " + crush_def_array[j + 7] + " || Prayer " + prayer_bonus_array[j + 7];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"off_hand_set_{i}_combobox");
                    ComboBox.Text = off_hand_name_array[i - 1];
                    tooltip_content = off_hand_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 6] + " || Magic " + magic_atk_array[j + 6] + "\n Slash " + slash_atk_array[j + 6] + " || Magic dmg " + magic_dmg_array[j + 6] + "\n Crush " + crush_atk_array[j + 6] + " || Range " + range_atk_array[j + 6] + "\n Str " + melee_str_array[j + 6] + " || Range str " + range_str_array[j + 6];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 6] + " || Magic " + magic_def_array[j + 6] + "\n Slash " + slash_def_array[j + 6] + " || Range " + range_def_array[j + 6] + "\n Crush " + crush_def_array[j + 6] + " || Prayer " + prayer_bonus_array[j + 6];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"gloves_set_{i}_combobox");
                    ComboBox.Text = gloves_name_array[i - 1];
                    tooltip_content = gloves_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 8] + " || Magic " + magic_atk_array[j + 8] + "\n Slash " + slash_atk_array[j + 8] + " || Magic dmg " + magic_dmg_array[j + 8] + "\n Crush " + crush_atk_array[j + 8] + " || Range " + range_atk_array[j + 8] + "\n Str " + melee_str_array[j + 8] + " || Range str " + range_str_array[j + 8];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 8] + " || Magic " + magic_def_array[j + 8] + "\n Slash " + slash_def_array[j + 8] + " || Range " + range_def_array[j + 8] + "\n Crush " + crush_def_array[j + 8] + " || Prayer " + prayer_bonus_array[j + 8];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"boots_set_{i}_combobox");
                    ComboBox.Text = boots_name_array[i - 1];
                    tooltip_content = boots_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 9] + " || Magic " + magic_atk_array[j + 9] + "\n Slash " + slash_atk_array[j + 9] + " || Magic dmg " + magic_dmg_array[j + 9] + "\n Crush " + crush_atk_array[j + 9] + " || Range " + range_atk_array[j + 9] + "\n Str " + melee_str_array[j + 9] + " || Range str " + range_str_array[j + 9];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 9] + " || Magic " + magic_def_array[j + 9] + "\n Slash " + slash_def_array[j + 9] + " || Range " + range_def_array[j + 9] + "\n Crush " + crush_def_array[j + 9] + " || Prayer " + prayer_bonus_array[j + 9];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;
                    ComboBox = (ComboBox)FindName($"ring_set_{i}_combobox");
                    ComboBox.Text = ring_name_array[i - 1];
                    tooltip_content = ring_name_array[i - 1] + "\n Offensive stats" + "\n Stab " + stab_atk_array[j + 10] + " || Magic " + magic_atk_array[j + 10] + "\n Slash " + slash_atk_array[j + 10] + " || Magic dmg " + magic_dmg_array[j + 10] + "\n Crush " + crush_atk_array[j + 10] + " || Range " + range_atk_array[j + 10] + "\n Str " + melee_str_array[j + 10] + " || Range str " + range_str_array[j + 10];
                    tooltip_content += "\n Defensive stats" + "\n Stab " + stab_def_array[j + 10] + " || Magic " + magic_def_array[j + 10] + "\n Slash " + slash_def_array[j + 10] + " || Range " + range_def_array[j + 10] + "\n Crush " + crush_def_array[j + 10] + " || Prayer " + prayer_bonus_array[j + 10];
                    customToolTip = new ToolTip
                    {
                        Content = tooltip_content,
                        Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                    };
                    ComboBox.ToolTip = customToolTip;

                    TextBox TextBox = (TextBox)FindName($"stab_atk_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(stab_atk_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"stab_atk_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_stab_atk_array[i - 1]);
                    TextBox = (TextBox)FindName($"stab_def_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(stab_def_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"stab_def_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_stab_def_array[i - 1]);

                    TextBox = (TextBox)FindName($"slash_atk_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(slash_atk_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"slash_atk_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_slash_atk_array[i - 1]);
                    TextBox = (TextBox)FindName($"slash_def_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(slash_def_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"slash_def_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_slash_def_array[i - 1]);

                    TextBox = (TextBox)FindName($"crush_atk_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(crush_atk_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"crush_atk_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_crush_atk_array[i - 1]);
                    TextBox = (TextBox)FindName($"crush_def_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(crush_def_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"crush_def_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_crush_def_array[i - 1]);

                    TextBox = (TextBox)FindName($"magic_atk_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(magic_atk_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"magic_atk_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_magic_atk_array[i - 1]);
                    TextBox = (TextBox)FindName($"magic_def_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(magic_def_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"magic_def_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_magic_def_array[i - 1]);

                    TextBox = (TextBox)FindName($"range_atk_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(range_atk_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"range_atk_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_range_atk_array[i - 1]);
                    TextBox = (TextBox)FindName($"range_def_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(range_def_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"range_def_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_range_def_array[i - 1]);

                    TextBox = (TextBox)FindName($"str_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(melee_str_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"str_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_melee_str_array[i - 1]);

                    TextBox = (TextBox)FindName($"range_str_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(range_str_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"range_str_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_range_str_array[i - 1]);

                    TextBox = (TextBox)FindName($"magic_dmg_{i}_modifier_textbox");
                    TextBox.Text = Convert.ToString(magic_dmg_modifier_array[i - 1]);
                    TextBox = (TextBox)FindName($"magic_dmg_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_magic_dmg_array[i - 1]);

                    TextBox = (TextBox)FindName($"weapon_attack_speed_{i}_textbox");
                    TextBox.Text = Convert.ToString(weapon_atk_speed_array[i - 1]);
                    TextBox = (TextBox)FindName($"custom_weapon_atk_speed_{i}_textbox");
                    TextBox.Text = Convert.ToString(custom_attack_speed_array[i - 1]);

                    TextBox = (TextBox)FindName($"prayer_bonus_{i}_textbox");
                    TextBox.Text = Convert.ToString(total_prayer_bonus_array[i - 1]);
                }

                attack_potions_combobox.Text = atk_pot_name;
                customToolTip = new ToolTip
                {
                    Content = atk_pot_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                attack_potions_combobox.ToolTip = customToolTip;

                strength_potions_combobox.Text = str_pot_name;
                customToolTip = new ToolTip
                {
                    Content = str_pot_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                strength_potions_combobox.ToolTip = customToolTip;

                defence_potions_combobox.Text = def_pot_name;
                customToolTip = new ToolTip
                {
                    Content = def_pot_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                defence_potions_combobox.ToolTip = customToolTip;

                magic_potions_combobox.Text = magic_pot_name;
                customToolTip = new ToolTip
                {
                    Content = magic_pot_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                magic_potions_combobox.ToolTip = customToolTip;

                range_potions_combobox.Text = range_pot_name;
                customToolTip = new ToolTip
                {
                    Content = range_pot_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                range_potions_combobox.ToolTip = customToolTip;

                attack_prayer_combobox.Text = atk_prayer_name;
                customToolTip = new ToolTip
                {
                    Content = atk_prayer_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                attack_prayer_combobox.ToolTip = customToolTip;

                strength_prayer_combobox.Text = str_prayer_name;
                customToolTip = new ToolTip
                {
                    Content = str_prayer_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                strength_prayer_combobox.ToolTip = customToolTip;

                defence_prayer_combobox.Text = def_prayer_name;
                customToolTip = new ToolTip
                {
                    Content = def_prayer_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                defence_prayer_combobox.ToolTip = customToolTip;

                magic_prayer_combobox.Text = magic_prayer_name;
                customToolTip = new ToolTip
                {
                    Content = magic_prayer_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                magic_prayer_combobox.ToolTip = customToolTip;

                range_prayer_combobox.Text = range_prayer_name;
                customToolTip = new ToolTip
                {
                    Content = range_prayer_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                range_prayer_combobox.ToolTip = customToolTip;

                monsters_combobox.Text = monster_name;
                customToolTip = new ToolTip
                {
                    Content = monster_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                monsters_combobox.ToolTip = customToolTip;

                thralls_combobox.Text = thrall_name;
                customToolTip = new ToolTip
                {
                    Content = thrall_name,
                    Template = FindResource("CustomTooltipTemplate") as ControlTemplate
                };
                thralls_combobox.ToolTip = customToolTip;

                distance_to_monster_textbox.Text = "" + distance_to_monster;

                // displaying loadout stats for
                attack_lvl_textbox.Text = "" + attack_lvl;
                strength_lvl_textbox.Text = "" + strength_lvl;
                defence_lvl_textbox.Text = "" + defence_lvl;
                magic_lvl_textbox.Text = "" + magic_lvl;
                range_lvl_textbox.Text = "" + range_lvl;
                hp_lvl_textbox.Text = "" + hp_lvl;
                prayer_lvl_textbox.Text = "" + prayer_lvl;
                mining_lvl_textbox.Text = "" + mining_lvl;

                attack_lvl_and_pot_modifier_textbox.Text = "" + attack_lvl_and_pot_modifier;
                strength_lvl_and_pot_modifier_textbox.Text = "" + strength_lvl_and_pot_modifier;
                defence_lvl_and_pot_modifier_textbox.Text = "" + defence_lvl_and_pot_modifier;
                magic_lvl_and_pot_modifier_textbox.Text = "" + magic_lvl_and_pot_modifier;
                range_lvl_and_pot_modifier_textbox.Text = "" + range_lvl_and_pot_modifier;
                hp_remaining_textbox.Text = "" + hp_remaining;
                prayer_remaining_textbox.Text = "" + prayer_remaining;

                attack_lvl_and_pot_textbox.Text = "" + attack_lvl_and_pot + "/" + attack_lvl;
                strength_lvl_and_pot_textbox.Text = "" + strength_lvl_and_pot + "/" + strength_lvl;
                defence_lvl_and_pot_textbox.Text = "" + defence_lvl_and_pot + "/" + defence_lvl;
                magic_lvl_and_pot_textbox.Text = "" + magic_lvl_and_pot + "/" + magic_lvl;
                range_lvl_and_pot_textbox.Text = "" + range_lvl_and_pot + "/" + range_lvl;
                hp_remaining_and_lvl_textbox.Text = "" + hp_remaining + "/" + hp_lvl;
                prayer_remaining_and_lvl_textbox.Text = "" + prayer_remaining + "/" + prayer_lvl;

                true_attack_lvl_textbox.Text = "" + true_attack_lvl;
                true_str_lvl_textbox.Text = "" + true_strength_lvl;
                true_defence_lvl_textbox.Text = "" + true_defence_lvl;
                true_magic_lvl_textbox.Text = "" + true_mage_lvl;
                true_range_lvl_textbox.Text = "" + true_range_lvl;
                true_range_str_textbox.Text = "" + true_range_str;

                combat_lvl_textbox.Text = "" + combat_lvl;

                soulreaper_axe_stack_textbox.Text = "" + soulreaper_axe_stack;
                venator_bow_1st_bounce_def_lvl_textbox.Text = "" + venator_bow_1st_bounce_def_lvl;
                venator_bow_1st_bounce_range_def_textbox.Text = "" + venator_bow_1st_bounce_range_def;
                venator_bow_2nd_bounce_def_lvl_textbox.Text = "" + venator_bow_2nd_bounce_def_lvl;
                venator_bow_2nd_bounce_range_def_textbox.Text = "" + venator_bow_2nd_bounce_range_def;

                // monster stats
                if (monster_name == "Phosani's Totem" || monster_name == "Totem")
                {
                    monster_atk_lvl_textbox.Text = "?? " + monster_reduced_atk_lvl + "/" + monster_boosted_atk_lvl + " ??";
                    monster_str_lvl_textbox.Text = "?? " + monster_reduced_str_lvl + "/" + monster_boosted_str_lvl + " ??";
                    monster_def_lvl_textbox.Text = "?? " + monster_reduced_def_lvl + "/" + monster_boosted_def_lvl + " ??";
                    monster_magic_lvl_textbox.Text = "?? " + monster_reduced_magic_lvl + "/" + monster_boosted_magic_lvl + " ??";
                    monster_range_lvl_textbox.Text = "?? " + monster_reduced_range_lvl + "/" + monster_boosted_range_lvl + " ??";
                    monster_hp_lvl_textbox.Text = "" + monster_reduced_hp_lvl + "/" + monster_boosted_hp_lvl;

                    monster_stab_def_textbox.Text = "?? " + monster_defensive_stab + " ??";
                    monster_slash_def_textbox.Text = "?? " + monster_defensive_slash + " ??";
                    monster_crush_def_textbox.Text = "?? " + monster_defensive_crush + " ??";
                    monster_magic_def_textbox.Text = "?? " + monster_defensive_magic + " ??";
                    monster_range_def_textbox.Text = "?? " + monster_defensive_range + " ??";

                    max_defence_roll_stab_textbox.Text = "?? " + monster_max_defensive_roll_stab + " ??";
                    max_defence_roll_slash_textbox.Text = "?? " + monster_max_defensive_roll_slash + " ??";
                    max_defence_roll_crush_textbox.Text = "?? " + monster_max_defensive_roll_crush + " ??";
                    max_defence_roll_magic_textbox.Text = "?? " + monster_max_defensive_roll_magic + " ??";
                    max_defence_roll_range_textbox.Text = "?? " + monster_max_defensive_roll_range + " ??";
                }
                else
                {
                    monster_atk_lvl_textbox.Text = "" + monster_reduced_atk_lvl + "/" + monster_boosted_atk_lvl;
                    monster_str_lvl_textbox.Text = "" + monster_reduced_str_lvl + "/" + monster_boosted_str_lvl;
                    monster_def_lvl_textbox.Text = "" + monster_reduced_def_lvl + "/" + monster_boosted_def_lvl;
                    monster_magic_lvl_textbox.Text = "" + monster_reduced_magic_lvl + "/" + monster_boosted_magic_lvl;
                    monster_range_lvl_textbox.Text = "" + monster_reduced_range_lvl + "/" + monster_boosted_range_lvl;
                    monster_hp_lvl_textbox.Text = "" + monster_reduced_hp_lvl + "/" + monster_boosted_hp_lvl;

                    monster_stab_def_textbox.Text = "" + monster_defensive_stab;
                    monster_slash_def_textbox.Text = "" + monster_defensive_slash;
                    monster_crush_def_textbox.Text = "" + monster_defensive_crush;
                    monster_magic_def_textbox.Text = "" + monster_defensive_magic;
                    monster_range_def_textbox.Text = "" + monster_defensive_range;

                    max_defence_roll_stab_textbox.Text = "" + monster_max_defensive_roll_stab;
                    max_defence_roll_slash_textbox.Text = "" + monster_max_defensive_roll_slash;
                    max_defence_roll_crush_textbox.Text = "" + monster_max_defensive_roll_crush;
                    max_defence_roll_magic_textbox.Text = "" + monster_max_defensive_roll_magic;
                    max_defence_roll_range_textbox.Text = "" + monster_max_defensive_roll_range;

                }

                monster_aggressive_atk_textbox.Text = "" + monster_aggressive_atk;
                monster_aggressive_str_textbox.Text = "" + monster_aggressive_str;
                monster_aggressive_mage_textbox.Text = "" + monster_aggressive_magic;
                monster_aggressive_mage_dmg_textbox.Text = "" + monster_aggressive_magic_dmg;
                monster_aggressive_range_textbox.Text = "" + monster_aggressive_range;
                monster_aggressive_range_str_textbox.Text = "" + monster_aggressive_range_str;

                if (thrall_type == "crush")
                {
                    thrall_type = "melee";
                }

                if (thrall_immune == true && thrall_name != "None")
                {
                    thrall_combat_style_textbox.Text = "IMMUNE " + thrall_type;
                }
                else
                {
                    thrall_combat_style_textbox.Text = "" + thrall_type;
                }
                thrall_max_hit_textbox.Text = "Max hit " + thrall_max_hit;
                thrall_avg_dmg_textbox.Text = "Avg dmg " + thrall_avg_dmg;
                thrall_dps_textbox.Text = "DPS " + thrall_damage_per_second;

                // multiple cals stuff
                multiple_calcs_iterations.Text = "Loadouts " + multiple_dps_loadouts_combobox.Items.Count + " | Monsters " + multiple_dps_monster_name_combobox.Items.Count + " | Iterations " + multiple_dps_loadouts_combobox.Items.Count * multiple_dps_monster_name_combobox.Items.Count;
            }

            // info boxes

            temp_combat_style_textbox_list.Clear();
            temp_max_hit_textbox_list.Clear();
            temp_max_attack_roll_textbox_list.Clear();
            temp_hit_chance_textbox_list.Clear();
            temp_avg_dmg_textbox_list.Clear();
            temp_dps_textbox_list.Clear();
            temp_avg_dmg_overkill_textbox_list.Clear();
            temp_dps_overkill_textbox_list.Clear();
            temp_avg_hits_to_kill_textbox_list.Clear();
            temp_avg_time_to_kill_textbox_list.Clear();
            temp_extra_info_textbox_list.Clear();


            // writing down the stats

            // if multi calc, dont do set 2 check
            int set_2 = 1;
            if (multiple_calcs == false)
            {
                set_2 = 2;
            }

            for (int y = 0; y < set_2; y++)
            {
                // normal attacks
                for (int i = 0; i < 4; i++)
                {
                    if (weapon_stance_array[i + (y * 4)] != "none" && weapon_type_array[i + (y * 4)] != "none")
                    {
                        if (is_immune_array[y] == true)
                        {
                            temp_combat_style_textbox_list.Add("IMMUNE " + weapon_stance_array[i + (y * 4)] + " " + weapon_type_array[i + (y * 4)]);
                        }
                        else
                        {
                            temp_combat_style_textbox_list.Add(weapon_stance_array[i + (y * 4)] + " " + weapon_type_array[i + (y * 4)]);
                        }

                        if (weapon_stance_array[i + (y * 4)] != "spell")
                        {
                            switch (weapon_name_array[y])
                            {
                                case "Scythe of vitur":
                                    if (monster_size == 1)
                                    {
                                        temp_extra_info_textbox_list.Add("Nothing special");
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    }
                                    else if (monster_size == 2)
                                    {
                                        temp_extra_info_textbox_list.Add("(" + max_hit_list[i + (y * 8)] + ") " + scythe_hitsplat_1_array[i + (y * 4)] + " | " + scythe_hitsplat_2_array[i + (y * 4)]);
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    }
                                    else
                                    {
                                        temp_extra_info_textbox_list.Add("(" + max_hit_list[i + (y * 8)] + ") " + scythe_hitsplat_1_array[i + (y * 4)] + " | " + scythe_hitsplat_2_array[i + (y * 4)] + " | " + scythe_hitsplat_3_array[i + (y * 4)]);
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    }
                                    break;
                                case "Osmumten's fang":
                                    temp_extra_info_textbox_list.Add("Max hit " + osmumtens_fang_max_hit_array[i + (y * 4)] + " Min hit " + osmumtens_fang_min_hit_array[i + (y * 4)]);
                                    temp_max_hit_textbox_list.Add("" + osmumtens_fang_max_hit_array[i + (y * 4)]);
                                    break;
                                case "Keris":
                                case "Keris partisan":
                                case "Keris partisan of breaching":
                                case "Keris partisan of corruption":
                                case "Keris partisan of the sun":
                                    if (monster_is_kaplhite == true)
                                    {
                                        temp_extra_info_textbox_list.Add("Crit (" + max_hit_list[i + (y * 8)] * 3 + ") " + max_hit_list[i + (y * 8)]);
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    }
                                    else
                                    {
                                        temp_extra_info_textbox_list.Add("Nothing special");
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    }
                                    break;
                                case "Dark bow":
                                    temp_extra_info_textbox_list.Add("(" + max_hit_list[i + (y * 8)] + ") | " + max_hit_list[i + (y * 8)] / 2 + " | " + max_hit_list[i + (y * 8)] / 2);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    break;
                                default:
                                    if (weapon_name_array[y].Contains("crossbow") == true && ammo_name_array[y].Contains("bolts (e)") == true)
                                    {
                                        temp_extra_info_textbox_list.Add("" + bolt_normal_dmg_array[i + (y * 4)] + "(" + bolt_proc_dmg_array[i + (y * 4)] + " Chance " + bolt_proc_chance_array[i + (y * 4)] + " %)");
                                        temp_max_hit_textbox_list.Add("" + bolt_normal_dmg_array[i + (y * 4)]);
                                    }
                                    else
                                    {
                                        temp_extra_info_textbox_list.Add("Nothing special");
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                                    }
                                    break;

                            }
                        }
                        else
                        {
                            temp_extra_info_textbox_list.Add("Nothing special");
                            temp_max_hit_textbox_list.Add("" + max_hit_list[i + (y * 8)]);
                        }
                        temp_max_attack_roll_textbox_list.Add("" + max_attack_roll_list[i + (y * 8)]);
                        temp_hit_chance_textbox_list.Add("" + hit_chance_list[i + (y * 8)]);
                        temp_avg_dmg_textbox_list.Add("" + avg_dmg_per_attack_list[i + (y * 8)]);
                        temp_dps_textbox_list.Add("" + dps_list[i + (y * 8)]);
                        temp_avg_dmg_overkill_textbox_list.Add("" + overkill_avg_dmg_per_attack_list[i + (y * 8)]);
                        temp_dps_overkill_textbox_list.Add("" + overkill_dps_list[i + (y * 8)]);
                        temp_avg_hits_to_kill_textbox_list.Add("" + avg_hits_to_kill_list[i + (y * 8)]);
                        temp_avg_time_to_kill_textbox_list.Add("" + time_to_kill_list[i + (y * 8)]);
                    }
                    else
                    {
                        temp_combat_style_textbox_list.Add("No style");
                        temp_extra_info_textbox_list.Add("Nothing special");
                        temp_max_hit_textbox_list.Add("0");
                        temp_max_attack_roll_textbox_list.Add("0");
                        temp_hit_chance_textbox_list.Add("0");
                        temp_avg_dmg_textbox_list.Add("0");
                        temp_dps_textbox_list.Add("0");
                        temp_avg_dmg_overkill_textbox_list.Add("0");
                        temp_dps_overkill_textbox_list.Add("0");
                        temp_avg_hits_to_kill_textbox_list.Add("0");
                        temp_avg_time_to_kill_textbox_list.Add("0");
                    }
                }

                // special attack
                for (int i = 0; i < 4; i++)
                {
                    if (has_special_attack_array[y] == true && spell_name_array[y] == "None")
                    {
                        if (weapon_stance_array[i + (y * 4)] != "none" && weapon_type_array[i + (y * 4)] != "none")
                        {

                            if (special_immune_array[y] == true && special_immune_2_array[y] == true)
                            {
                                temp_combat_style_textbox_list.Add("IMMUNE " + weapon_stance_array[i + (y * 4)] + " " + weapon_type_array[i + (y * 4)]);
                            }
                            else
                            {
                                if ((special_immune_array[y] == true || special_immune_2_array[y] == true) && (weapon_name_array[y] == "Saradomin sword" || weapon_name_array[y] == "Ancient godsword"))
                                {
                                    temp_combat_style_textbox_list.Add("IMMUNEN'T " + weapon_stance_array[i + (y * 4)] + " " + weapon_type_array[i + (y * 4)]);
                                }
                                else
                                {
                                    temp_combat_style_textbox_list.Add("SPECIAL " + weapon_stance_array[i + (y * 4)] + " " + weapon_type_array[i + (y * 4)]);
                                }

                            }

                            switch (weapon_name_array[y])
                            {
                                case "Dragon halberd":
                                case "Crystal halberd":
                                    if (monster_size == 1)
                                    {
                                        temp_extra_info_textbox_list.Add("Nothing special");
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    }
                                    else
                                    {
                                        temp_extra_info_textbox_list.Add("(" + max_hit_list[i + 4 + (y * 8)] + ") " + special_max_hit_1_array[i + (y * 4)] + " | " + special_max_hit_2_array[i + (y * 4)]);
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    }
                                    break;
                                case "Dawnbringer":
                                case "Osmumten's fang":
                                case "Voidwaker":
                                    temp_extra_info_textbox_list.Add("Max hit " + max_hit_list[i + 4 + (y * 8)] + " Min hit " + spec_min_hit_array[i + (y * 4)]);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Granite hammer":
                                case "Ursine chainmace":
                                case "Ancient godsword":
                                    temp_extra_info_textbox_list.Add("" + special_max_hit_1_array[i + (y * 4)] + " (+" + special_max_hit_2_array[i + (y * 4)] + ")");
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Dragon knife":
                                case "Dragon dagger":
                                case "Abyssal dagger":
                                case "Magic shortbow":
                                case "Magic shortbow (i)":
                                    temp_extra_info_textbox_list.Add("(" + max_hit_list[i + 4 + (y * 8)] + ") " + special_max_hit_1_array[i + (y * 4)] + " | " + special_max_hit_2_array[i + (y * 4)]);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Webweaver bow":
                                case "Dragon claws":
                                    temp_extra_info_textbox_list.Add("(" + max_hit_list[i + 4 + (y * 8)] + ") " + special_max_hit_1_array[i + (y * 4)] + " | " + special_max_hit_2_array[i + (y * 4)] + " | " + special_max_hit_3_array[i + (y * 4)] + " | " + special_max_hit_3_array[i + (y * 4)]);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Dragon warhammer":
                                    temp_extra_info_textbox_list.Add("Avg def reduction " + dwh_avg_def_reduction_list[i + (y * 4)]);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Keris partisan of corruption":
                                    if (monster_is_kaplhite == true)
                                    {
                                        temp_extra_info_textbox_list.Add("Crit (" + max_hit_list[i + 4 + (y * 8)] * 3 + ") " + max_hit_list[i + 4 + (y * 8)]);
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    }
                                    else
                                    {
                                        temp_extra_info_textbox_list.Add("Nothing special");
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    }
                                    break;
                                case "Saradomin sword":
                                    temp_extra_info_textbox_list.Add("(" + max_hit_list[i + 4 + (y * 8)] + ") " + special_max_hit_1_array[i + (y * 4)] + " | " + special_max_hit_2_array[i + (y * 4)]);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Eldritch nightmare staff":
                                case "Volatile nightmare staff":
                                    temp_extra_info_textbox_list.Add("Max hit ±1, Not accurate");
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                case "Dragon crossbow":
                                case "Armadyl crossbow":
                                    if (ammo_name_array[y].Contains("bolts (e)") == true)
                                    {
                                        temp_extra_info_textbox_list.Add("" + bolt_normal_dmg_array[i + 4 + (y * 8)] + " (" + bolt_proc_dmg_array[i + 4 + (y * 8)] + " Chance " + bolt_proc_chance_array[i + 4 + (y * 8)] + "%)");
                                        temp_max_hit_textbox_list.Add("" + bolt_normal_dmg_array[i + 4 + (y * 8)]);
                                    }
                                    else
                                    {
                                        temp_extra_info_textbox_list.Add("Nothing special");
                                        temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    }
                                    break;
                                case "Dark bow":
                                    temp_extra_info_textbox_list.Add("(" + max_hit_list[i + 4 + (y * 8)] + " Min hit " + spec_min_hit_array[i + (y * 4)] * 2 + ") | " + max_hit_list[i + 4 + (y * 8)] / 2 + " | " + max_hit_list[i + 4 + (y * 8)] / 2);
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                                default:
                                    temp_extra_info_textbox_list.Add("Nothing special");
                                    temp_max_hit_textbox_list.Add("" + max_hit_list[i + 4 + (y * 8)]);
                                    break;
                            }
                            temp_max_attack_roll_textbox_list.Add("" + max_attack_roll_list[i + 4 + (y * 8)]);
                            temp_hit_chance_textbox_list.Add("" + hit_chance_list[i + 4 + (y * 8)]);
                            temp_avg_dmg_textbox_list.Add("" + avg_dmg_per_attack_list[i + 4 + (y * 8)]);
                            temp_dps_textbox_list.Add("" + dps_list[i + 4 + (y * 8)]);
                            temp_avg_dmg_overkill_textbox_list.Add("" + overkill_avg_dmg_per_attack_list[i + 4 + (y * 8)]);
                            temp_dps_overkill_textbox_list.Add("" + overkill_dps_list[i + 4 + (y * 8)]);
                            temp_avg_hits_to_kill_textbox_list.Add("" + avg_hits_to_kill_list[i + 4 + (y * 8)]);
                            temp_avg_time_to_kill_textbox_list.Add("" + time_to_kill_list[i + 4 + (y * 8)]);
                        }
                        else
                        {
                            temp_combat_style_textbox_list.Add("No style");
                            temp_extra_info_textbox_list.Add("Nothing special");
                            temp_max_hit_textbox_list.Add("0");
                            temp_max_attack_roll_textbox_list.Add("0");
                            temp_hit_chance_textbox_list.Add("0");
                            temp_avg_dmg_textbox_list.Add("0");
                            temp_dps_textbox_list.Add("0");
                            temp_avg_dmg_overkill_textbox_list.Add("0");
                            temp_dps_overkill_textbox_list.Add("0");
                            temp_avg_hits_to_kill_textbox_list.Add("0");
                            temp_avg_time_to_kill_textbox_list.Add("0");
                        }
                    }
                    else
                    {
                        temp_combat_style_textbox_list.Add("No special");
                        temp_extra_info_textbox_list.Add("Nothing special");
                        temp_max_hit_textbox_list.Add("0");
                        temp_max_attack_roll_textbox_list.Add("0");
                        temp_hit_chance_textbox_list.Add("0");
                        temp_avg_dmg_textbox_list.Add("0");
                        temp_dps_textbox_list.Add("0");
                        temp_avg_dmg_overkill_textbox_list.Add("0");
                        temp_dps_overkill_textbox_list.Add("0");
                        temp_avg_hits_to_kill_textbox_list.Add("0");
                        temp_avg_time_to_kill_textbox_list.Add("0");
                    }
                }
            }




            // multiple calcs is false, so update rest of the ui
            if (multiple_calcs == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (compare_styles_set_1_combobox.Items[i].ToString() != temp_combat_style_textbox_list[i])
                    {
                        compare_styles_set_1_combobox.Items[i] = temp_combat_style_textbox_list[i];
                    }

                    if (compare_styles_set_2_combobox.Items[i].ToString() != temp_combat_style_textbox_list[i + 8])
                    {
                        compare_styles_set_2_combobox.Items[i] = temp_combat_style_textbox_list[i + 8];
                    }
                }

                int j = 0;
                if (show_set_2 == true)
                {
                    j = 8;
                }

                for (int i = 0; i < 4; i++)
                {
                    // normal
                    TextBox textBox = (TextBox)FindName($"weapon_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_combat_style_textbox_list[i + j];
                    textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_max_hit_textbox_list[i + j];
                    textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_max_attack_roll_textbox_list[i + j];
                    textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_hit_chance_textbox_list[i + j] + "%";
                    textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_avg_dmg_textbox_list[i + j];
                    textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_dps_textbox_list[i + j];
                    textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_textbox");
                    textBox.Text = temp_avg_dmg_overkill_textbox_list[i + j];
                    textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_textbox");
                    textBox.Text = temp_dps_overkill_textbox_list[i + j];
                    textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_textbox");
                    textBox.Text = temp_avg_hits_to_kill_textbox_list[i + j];
                    textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_textbox");
                    textBox.Text = temp_avg_time_to_kill_textbox_list[i + j];
                    textBox = (TextBox)FindName($"extra_info_style_{i + 1}_textbox");
                    textBox.Text = temp_extra_info_textbox_list[i + j];

                    //special
                    textBox = (TextBox)FindName($"weapon_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_combat_style_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_max_hit_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_max_attack_roll_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_hit_chance_textbox_list[i + 4 + j] + "%";
                    textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_avg_dmg_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_dps_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_special_textbox");
                    textBox.Text = temp_avg_dmg_overkill_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_special_textbox");
                    textBox.Text = temp_dps_overkill_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_special_textbox");
                    textBox.Text = temp_avg_hits_to_kill_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_special_textbox");
                    textBox.Text = temp_avg_time_to_kill_textbox_list[i + 4 + j];
                    textBox = (TextBox)FindName($"extra_info_style_{i + 1}_special_textbox");
                    textBox.Text = temp_extra_info_textbox_list[i + 4 + j];
                }

                Dispatcher.Invoke(compare_data);
            }
            // multiple calcs data is true
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    multiple_loadout_name_data_list.Add(loadout_name);
                    multiple_weapon_name_data_list.Add(weapon_name_array[0]);
                    multiple_combat_style_data_list.Add(temp_combat_style_textbox_list[i]);
                    multiple_max_hit_data_list.Add(temp_max_hit_textbox_list[i]);
                    multiple_max_attack_roll_data_list.Add(temp_max_attack_roll_textbox_list[i]);
                    multiple_hit_chance_data_list.Add(temp_hit_chance_textbox_list[i]);
                    multiple_avg_dmg_data_list.Add(temp_avg_dmg_textbox_list[i]);
                    multiple_dps_data_list.Add(temp_dps_textbox_list[i]);
                    multiple_avg_dmg_overkill_data_list.Add(temp_avg_dmg_overkill_textbox_list[i]);
                    multiple_dps_overkill_data_list.Add(temp_dps_overkill_textbox_list[i]);
                    multiple_avg_hits_to_kill_data_list.Add(temp_avg_hits_to_kill_textbox_list[i]);
                    multiple_time_to_kill_data_list.Add(temp_avg_time_to_kill_textbox_list[i]);
                }

                multiple_monsters_stats_data_list.Add(monster_reduced_atk_lvl + "/" + monster_boosted_atk_lvl);
                multiple_monsters_stats_data_list.Add(monster_reduced_str_lvl + "/" + monster_boosted_str_lvl);
                multiple_monsters_stats_data_list.Add(monster_reduced_def_lvl + "/" + monster_boosted_def_lvl);
                multiple_monsters_stats_data_list.Add(monster_reduced_magic_lvl + "/" + monster_boosted_magic_lvl);
                multiple_monsters_stats_data_list.Add(monster_reduced_range_lvl + "/" + monster_boosted_range_lvl);
                multiple_monsters_stats_data_list.Add(monster_reduced_hp_lvl + "/" + monster_boosted_hp_lvl);
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_defensive_stab));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_defensive_slash));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_defensive_crush));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_defensive_magic));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_defensive_range));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_max_defensive_roll_stab));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_max_defensive_roll_slash));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_max_defensive_roll_crush));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_max_defensive_roll_magic));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_max_defensive_roll_range));

                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_aggressive_atk));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_aggressive_str));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_aggressive_magic));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_aggressive_magic_dmg));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_aggressive_range));
                multiple_monsters_stats_data_list.Add(Convert.ToString(monster_aggressive_range_str));
                multiple_monsters_stats_data_list.Add(Convert.ToString(arclight_hits));
                multiple_monsters_stats_data_list.Add(Convert.ToString(dwh_hits));
                multiple_monsters_stats_data_list.Add(Convert.ToString(bgs_dmg));
                multiple_monsters_stats_data_list.Add(Convert.ToString(dmg_delt));
                multiple_monsters_stats_data_list.Add(Convert.ToString(team_size));
                multiple_monsters_stats_data_list.Add(Convert.ToString(toa_raid_lvl));
                multiple_monsters_stats_data_list.Add(Convert.ToString(toa_path_lvl));
                multiple_monsters_stats_data_list.Add(Convert.ToString(CM_cox_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(slayer_task_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(kandarin_diary_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(red_keris_spec_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(tome_of_water_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(vulnerability_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(enfeeble_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(stun_checkbox.IsChecked));
                multiple_monsters_stats_data_list.Add(Convert.ToString(accursed_secptre_checkbox.IsChecked));

            }
        }
        private void compare_data()
        {

            if (compare_styles_set_1_combobox.SelectedItem == null)
            {
                compare_styles_set_1_combobox.SelectedIndex = 0;
            }

            if (compare_styles_set_2_combobox.SelectedItem == null)
            {
                compare_styles_set_2_combobox.SelectedIndex = 0;
            }


            int i = compare_styles_set_1_combobox.SelectedIndex;
            int j = compare_styles_set_2_combobox.SelectedIndex + 8;
            int l = i;
            int m = j;

            compare_styles_set_1_combobox.Text = Convert.ToString(compare_styles_set_1_combobox.SelectedItem);
            compare_styles_set_1_combobox.ToolTip = Convert.ToString(compare_styles_set_1_combobox.SelectedItem);

            compare_styles_set_2_combobox.Text = Convert.ToString(compare_styles_set_2_combobox.SelectedItem);
            compare_styles_set_2_combobox.ToolTip = Convert.ToString(compare_styles_set_2_combobox.SelectedItem);

            compare_maxhit_set_1_textbox.Text = temp_max_hit_textbox_list[i];
            compare_hit_chance_set_1_textbox.Text = temp_hit_chance_textbox_list[i] + "%";
            compare_average_dmg_set_1_textbox.Text = temp_avg_dmg_textbox_list[i];
            compare_dps_set_1_textbox.Text = temp_dps_textbox_list[i];
            compare_average_dmg_overkill_set_1_textbox.Text = temp_avg_dmg_overkill_textbox_list[i];
            compare_dps_overkill_set_1_textbox.Text = temp_dps_overkill_textbox_list[i];
            compare_time_to_kill_set_1_textbox.Text = temp_avg_time_to_kill_textbox_list[i];

            compare_maxhit_set_2_textbox.Text = temp_max_hit_textbox_list[j];
            compare_hit_chance_set_2_textbox.Text = temp_hit_chance_textbox_list[j] + "%";
            compare_average_dmg_set_2_textbox.Text = temp_avg_dmg_textbox_list[j];
            compare_dps_set_2_textbox.Text = temp_dps_textbox_list[j];
            compare_average_dmg_overkill_set_2_textbox.Text = temp_avg_dmg_overkill_textbox_list[j];
            compare_dps_overkill_set_2_textbox.Text = temp_dps_overkill_textbox_list[j];
            compare_time_to_kill_set_2_textbox.Text = temp_avg_time_to_kill_textbox_list[j];

            double temp_compare_max_hit_1;
            double temp_compare_max_hit_2;

            if (weapon_name_array[0] == "Osmumten's fang" && l < 4)
            {
                temp_compare_max_hit_1 = osmumtens_fang_max_hit_array[l];
            }
            else
            {
                temp_compare_max_hit_1 = max_hit_list[i];
            }

            if (weapon_name_array[1] == "Osmumten's fang" && m < 8)
            {
                temp_compare_max_hit_2 = osmumtens_fang_max_hit_array[m];
            }
            else
            {
                temp_compare_max_hit_2 = max_hit_list[j];
            }

            compare_maxhit_difference_textbox.Text = Math.Round((Math.Max(temp_compare_max_hit_1, temp_compare_max_hit_2) / Math.Min(temp_compare_max_hit_1, temp_compare_max_hit_2) - 1) * 100, 5) + "%";
            compare_hit_chance_difference_textbox.Text = Math.Round((Math.Max(hit_chance_list[i], hit_chance_list[j]) / Math.Min(hit_chance_list[i], hit_chance_list[j]) - 1) * 100, 5) + "%";
            compare_average_dmg_difference_textbox.Text = Math.Round((Math.Max(avg_dmg_per_attack_list[i], avg_dmg_per_attack_list[j]) / Math.Min(avg_dmg_per_attack_list[i], avg_dmg_per_attack_list[j]) - 1) * 100, 5) + "%";
            compare_dps_difference_textbox.Text = Math.Round((Math.Max(dps_list[i], dps_list[j]) / Math.Min(dps_list[i], dps_list[j]) - 1) * 100, 5) + "%";
            compare_average_dmg_overkill_difference_textbox.Text = Math.Round((Math.Max(overkill_avg_dmg_per_attack_list[i], overkill_avg_dmg_per_attack_list[j]) / Math.Min(overkill_avg_dmg_per_attack_list[i], overkill_avg_dmg_per_attack_list[j]) - 1) * 100, 5) + "%";
            compare_dps_overkill_difference_textbox.Text = Math.Round((Math.Max(overkill_dps_list[i], overkill_dps_list[j]) / Math.Min(overkill_dps_list[i], overkill_dps_list[j]) - 1) * 100, 5) + "%";
            compare_time_to_kill_difference_textbox.Text = Math.Round((Math.Max(time_to_kill_list[i], time_to_kill_list[j]) / Math.Min(time_to_kill_list[i], time_to_kill_list[j]) - 1) * 100, 5) + "%";

            // coloring
            // max hit
            if (temp_compare_max_hit_1 == Math.Max(temp_compare_max_hit_1, temp_compare_max_hit_2))
            {
                compare_maxhit_set_1_textbox.BorderBrush = Brushes.Green;
                compare_maxhit_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                compare_maxhit_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_maxhit_set_2_textbox.BorderBrush = Brushes.Green;
            }

            if (temp_compare_max_hit_1 == temp_compare_max_hit_2)
            {
                compare_maxhit_set_1_textbox.BorderBrush = Brushes.Green;
                compare_maxhit_set_2_textbox.BorderBrush = Brushes.Green;
            }

            // hit chance
            if (hit_chance_list[i] == Math.Max(hit_chance_list[i], hit_chance_list[j]))
            {
                compare_hit_chance_set_1_textbox.BorderBrush = Brushes.Green;
                compare_hit_chance_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                compare_hit_chance_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_hit_chance_set_2_textbox.BorderBrush = Brushes.Green;
            }

            if (hit_chance_list[i] == hit_chance_list[j])
            {
                compare_hit_chance_set_1_textbox.BorderBrush = Brushes.Green;
                compare_hit_chance_set_2_textbox.BorderBrush = Brushes.Green;
            }

            // avg dmg
            if (avg_dmg_per_attack_list[i] == Math.Max(avg_dmg_per_attack_list[i], avg_dmg_per_attack_list[j]))
            {
                compare_average_dmg_set_1_textbox.BorderBrush = Brushes.Green;
                compare_average_dmg_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                compare_average_dmg_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_average_dmg_set_2_textbox.BorderBrush = Brushes.Green;
            }

            if (avg_dmg_per_attack_list[i] == avg_dmg_per_attack_list[j])
            {
                compare_average_dmg_set_1_textbox.BorderBrush = Brushes.Green;
                compare_average_dmg_set_2_textbox.BorderBrush = Brushes.Green;
            }

            // dps
            if (dps_list[i] == Math.Max(dps_list[i], dps_list[j]))
            {
                compare_dps_set_1_textbox.BorderBrush = Brushes.Green;
                compare_dps_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                compare_dps_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_dps_set_2_textbox.BorderBrush = Brushes.Green;
            }

            if (dps_list[i] == dps_list[j])
            {
                compare_dps_set_1_textbox.BorderBrush = Brushes.Green;
                compare_dps_set_2_textbox.BorderBrush = Brushes.Green;
            }

            // avg dmg overkill
            if (overkill_avg_dmg_per_attack_list[i] == Math.Max(overkill_avg_dmg_per_attack_list[i], overkill_avg_dmg_per_attack_list[j]))
            {
                compare_average_dmg_overkill_set_1_textbox.BorderBrush = Brushes.Green;
                compare_average_dmg_overkill_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                compare_average_dmg_overkill_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_average_dmg_overkill_set_2_textbox.BorderBrush = Brushes.Green;
            }

            if (overkill_avg_dmg_per_attack_list[i] == overkill_avg_dmg_per_attack_list[j])
            {
                compare_average_dmg_overkill_set_1_textbox.BorderBrush = Brushes.Green;
                compare_average_dmg_overkill_set_2_textbox.BorderBrush = Brushes.Green;
            }

            // dps overkill
            if (overkill_dps_list[i] == Math.Max(overkill_dps_list[i], overkill_dps_list[j]))
            {
                compare_dps_overkill_set_1_textbox.BorderBrush = Brushes.Green;
                compare_dps_overkill_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                compare_dps_overkill_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_dps_overkill_set_2_textbox.BorderBrush = Brushes.Green;
            }

            if (overkill_dps_list[i] == overkill_dps_list[j])
            {
                compare_dps_overkill_set_1_textbox.BorderBrush = Brushes.Green;
                compare_dps_overkill_set_2_textbox.BorderBrush = Brushes.Green;
            }

            // time to kill
            if (time_to_kill_list[i] == Math.Max(time_to_kill_list[i], time_to_kill_list[j]))
            {
                compare_time_to_kill_set_1_textbox.BorderBrush = Brushes.DarkRed;
                compare_time_to_kill_set_2_textbox.BorderBrush = Brushes.Green;
            }
            else
            {
                compare_time_to_kill_set_1_textbox.BorderBrush = Brushes.Green;
                compare_time_to_kill_set_2_textbox.BorderBrush = Brushes.DarkRed;
            }

            if (time_to_kill_list[i] == time_to_kill_list[j])
            {
                compare_time_to_kill_set_1_textbox.BorderBrush = Brushes.Green;
                compare_time_to_kill_set_2_textbox.BorderBrush = Brushes.Green;
            }


        }
        private void coloring_menu()
        {

            int j = 0;
            int k = 0;
            if (show_set_2 == true)
            {
                j = 4;
                k = 1;
            }

            double highest_number;
            List<double> coloring_stats = new List<double>();

            // max hit box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(max_hit_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // max attack roll box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(max_attack_roll_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // hit chance box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(hit_chance_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // avg dmg box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(avg_dmg_per_attack_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // overkill avg dmg box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(overkill_avg_dmg_per_attack_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // dps box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(dps_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // overkill dps box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                coloring_stats.Add(overkill_dps_list[i + j]);
            }
            highest_number = coloring_stats.Max();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // avg hits to kill box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                if (avg_hits_to_kill_list[i + j] == 0)
                {
                    coloring_stats.Add(9999999999999);
                }
                else
                {
                    coloring_stats.Add(avg_hits_to_kill_list[i + j]);
                }
            }
            highest_number = coloring_stats.Min();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // time to kill box

            coloring_stats.Clear();
            for (int i = j; i < j + 4; i++)
            {
                if (time_to_kill_list[i + j] == 0)
                {
                    coloring_stats.Add(9999999999999);
                }
                else
                {
                    coloring_stats.Add(time_to_kill_list[i + j]);
                }
            }
            highest_number = coloring_stats.Min();

            for (int i = 0; i < 4; i++)
            {
                if (highest_number == coloring_stats[i])
                {
                    TextBox textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.Green;
                }
                else
                {
                    TextBox textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

            // aaaaaaaaaaand same for special
            if (has_special_attack_array[k] == true && spell_name_array[k] == "None")
            {
                // max hit box special
                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(max_hit_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // max attack roll box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(max_attack_roll_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // hit chance box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(hit_chance_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // avg dmg box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(avg_dmg_per_attack_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // overkill avg dmg box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(overkill_avg_dmg_per_attack_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // dps box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(dps_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // overkill dps box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    coloring_stats.Add(overkill_dps_list[i + j + 4]);
                }
                highest_number = coloring_stats.Max();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // avg hits to kill box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    if (avg_hits_to_kill_list[i + j + 4] == 0)
                    {
                        coloring_stats.Add(9999999999999);
                    }
                    else
                    {
                        coloring_stats.Add(avg_hits_to_kill_list[i + j + 4]);
                    }
                }
                highest_number = coloring_stats.Min();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }

                // time to kill box special

                coloring_stats.Clear();
                for (int i = j; i < j + 4; i++)
                {
                    if (time_to_kill_list[i + j + 4] == 0)
                    {
                        coloring_stats.Add(9999999999999);
                    }
                    else
                    {
                        coloring_stats.Add(time_to_kill_list[i + j + 4]);
                    }
                }
                highest_number = coloring_stats.Min();

                for (int i = 0; i < 4; i++)
                {
                    if (highest_number == coloring_stats[i])
                    {
                        TextBox textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        TextBox textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }
            }

            // defence roll box

            coloring_stats.Clear();
            coloring_stats.Add(monster_max_defensive_roll_stab);
            coloring_stats.Add(monster_max_defensive_roll_slash);
            coloring_stats.Add(monster_max_defensive_roll_crush);
            coloring_stats.Add(monster_max_defensive_roll_magic);
            coloring_stats.Add(monster_max_defensive_roll_range);

            highest_number = coloring_stats.Min();

            if (highest_number == coloring_stats[0])
            {
                max_defence_roll_stab_textbox.BorderBrush = Brushes.Green;
            }
            else
            {
                max_defence_roll_stab_textbox.BorderBrush = Brushes.DarkRed;
            }

            if (highest_number == coloring_stats[1])
            {
                max_defence_roll_slash_textbox.BorderBrush = Brushes.Green;
            }
            else
            {
                max_defence_roll_slash_textbox.BorderBrush = Brushes.DarkRed;
            }

            if (highest_number == coloring_stats[2])
            {
                max_defence_roll_crush_textbox.BorderBrush = Brushes.Green;
            }
            else
            {
                max_defence_roll_crush_textbox.BorderBrush = Brushes.DarkRed;
            }

            if (highest_number == coloring_stats[3])
            {
                max_defence_roll_magic_textbox.BorderBrush = Brushes.Green;
            }
            else
            {
                max_defence_roll_magic_textbox.BorderBrush = Brushes.DarkRed;
            }


            if (highest_number == coloring_stats[4])
            {
                max_defence_roll_range_textbox.BorderBrush = Brushes.Green;
            }
            else
            {
                max_defence_roll_range_textbox.BorderBrush = Brushes.DarkRed;
            }

            // combat style box and immunity
            weapon_combat_style_1_textbox.BorderBrush = dps_combat_style_1_textbox.BorderBrush;
            weapon_combat_style_2_textbox.BorderBrush = dps_combat_style_2_textbox.BorderBrush;
            weapon_combat_style_3_textbox.BorderBrush = dps_combat_style_3_textbox.BorderBrush;
            weapon_combat_style_4_textbox.BorderBrush = dps_combat_style_4_textbox.BorderBrush;
            if (is_immune_array[k] == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    TextBox textBox = (TextBox)FindName($"weapon_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }
            if (has_special_attack_array[k] == true)
            {
                weapon_combat_style_1_special_textbox.BorderBrush = dps_combat_style_1_special_textbox.BorderBrush;
                weapon_combat_style_2_special_textbox.BorderBrush = dps_combat_style_2_special_textbox.BorderBrush;
                weapon_combat_style_3_special_textbox.BorderBrush = dps_combat_style_3_special_textbox.BorderBrush;
                weapon_combat_style_4_special_textbox.BorderBrush = dps_combat_style_4_special_textbox.BorderBrush;
                if (special_immune_array[k] == true && special_immune_2_array[k] == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        TextBox textBox = (TextBox)FindName($"weapon_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                        textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                        textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                        textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                        textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_special_textbox");
                        textBox.BorderBrush = Brushes.DarkRed;
                    }
                }
                else
                {
                    if ((special_immune_array[k] == true || special_immune_2_array[k] == true) && (weapon_name_array[k] == "Saradomin sword" || weapon_name_array[k] == "Ancient godsword"))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            TextBox textBox = (TextBox)FindName($"weapon_combat_style_{i + 1}_special_textbox");
                            textBox.BorderBrush = Brushes.DarkOrange;
                            textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_special_textbox");
                            textBox.BorderBrush = Brushes.DarkOrange;
                            textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_special_textbox");
                            textBox.BorderBrush = Brushes.DarkOrange;
                            textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_special_textbox");
                            textBox.BorderBrush = Brushes.DarkOrange;
                            textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_special_textbox");
                            textBox.BorderBrush = Brushes.DarkOrange;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    TextBox textBox = (TextBox)FindName($"weapon_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"max_hit_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"max_attackroll_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"hit_chance_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"avg_dmg_per_attack_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"dps_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"overkill_avg_dmg_per_attack_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"overkill_dps_combat_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"avg_hits_to_kill_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                    textBox = (TextBox)FindName($"time_to_kill_style_{i + 1}_special_textbox");
                    textBox.BorderBrush = Brushes.DarkRed;
                }
            }

        }
        // multiple dps calcs
        private void multiple_monster_names()
        {
            string inputName = monster_name;

            bool nameExists = false;
            int numberSuffix = 1;

            foreach (var item in multiple_dps_monster_name_combobox.Items)
            {
                if (item is string itemName && itemName == inputName)
                {
                    nameExists = true;
                    break;
                }
            }

            // If the name exists, add a number suffix until a unique name is found
            while (nameExists)
            {
                string newName = $"{inputName} ({numberSuffix})";

                // Check if the new name already exists in the ComboBox
                nameExists = false;
                foreach (var item in multiple_dps_monster_name_combobox.Items)
                {
                    if (item is string itemName && itemName == newName)
                    {
                        nameExists = true;
                        numberSuffix++;
                        break;
                    }
                }

                // If a unique name is found, add it to the ComboBox
                if (!nameExists)
                {
                    multiple_dps_monster_name_combobox.Items.Add(newName);
                    inputName = newName;
                }
            }

            // If the name doesn't exist, add it directly to the ComboBox
            if (!multiple_dps_monster_name_combobox.Items.Contains(inputName))
            {
                multiple_dps_monster_name_combobox.Items.Add(inputName);
            }

            Dispatcher.Invoke(multiple_monster_stats);
        }
        private void multiple_monster_stats()
        {
            multiple_monsters_data = monster_name + ";" + tome_of_water_checkbox.IsChecked + ";" + vulnerability_checkbox.IsChecked + ";" + enfeeble_checkbox.IsChecked + ";" + stun_checkbox.IsChecked + ";" + accursed_secptre_checkbox.IsChecked + ";";
            multiple_monsters_data += arclight_hits + ";" + dwh_hits + ";" + bgs_dmg + ";" + dmg_delt + ";" + kandarin_diary_checkbox.IsChecked + ";" + slayer_task_checkbox.IsChecked + ";" + red_keris_spec_checkbox.IsChecked + ";";
            multiple_monsters_data += CM_cox_checkbox.IsChecked + ";" + team_size + ";" + toa_raid_lvl + ";" + toa_path_lvl;

            multiple_monsters_data_list.Add(multiple_monsters_data);
        }
        private void multiple_calcs_dps()
        {
            multiple_loadout_name_data_list.Clear();
            multiple_weapon_name_data_list.Clear();
            multiple_combat_style_data_list.Clear();
            multiple_max_hit_data_list.Clear();
            multiple_max_attack_roll_data_list.Clear();
            multiple_hit_chance_data_list.Clear();
            multiple_avg_dmg_data_list.Clear();
            multiple_dps_data_list.Clear();
            multiple_avg_dmg_overkill_data_list.Clear();
            multiple_dps_overkill_data_list.Clear();
            multiple_avg_hits_to_kill_data_list.Clear();
            multiple_time_to_kill_data_list.Clear();

            multiple_monsters_stats_data_list.Clear();
            multiple_monsters_names_data_list.Clear();

            monster_count.Clear();

            multiple_calcs = true;

            if (multiple_dps_loadouts_combobox.Items.Count != 0 && multiple_dps_monster_name_combobox.Items.Count != 0)
            {

                for (int i = 0; i < multiple_dps_loadouts_combobox.Items.Count; i++)
                {
                    loadout_name = multiple_dps_loadouts_combobox.Items[i].ToString();
                    // set 1 and set 2 usage in multi calc
                    if (loadout_name == "Set 1" || loadout_name == "Set 2")
                    {
                        Dispatcher.Invoke(load_set_1_and_2_data);
                    }
                    else
                    {
                        Dispatcher.Invoke(load_loadout_data);
                    }

                    for (int j = 0; j < multiple_dps_monster_name_combobox.Items.Count; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            multiple_monsters_names_data_list.Add(Convert.ToString(multiple_dps_monster_name_combobox.Items[j]));
                        }             
                        string[] data_entries = multiple_monsters_data_list[j].Split(';');
                        monster_name = data_entries[0];
                        tome_of_water_checkbox.IsChecked = Convert.ToBoolean(data_entries[1]);
                        vulnerability_checkbox.IsChecked = Convert.ToBoolean(data_entries[2]);
                        enfeeble_checkbox.IsChecked = Convert.ToBoolean(data_entries[3]);
                        stun_checkbox.IsChecked = Convert.ToBoolean(data_entries[4]);
                        accursed_secptre_checkbox.IsChecked = Convert.ToBoolean(data_entries[5]);

                        arclight_hits = Convert.ToInt32(data_entries[6]);
                        dwh_hits = Convert.ToInt32(data_entries[7]);
                        bgs_dmg = Convert.ToInt32(data_entries[8]);
                        dmg_delt = Convert.ToInt32(data_entries[9]);
                        kandarin_diary_checkbox.IsChecked = Convert.ToBoolean(data_entries[10]);
                        slayer_task_checkbox.IsChecked = Convert.ToBoolean(data_entries[11]);
                        red_keris_spec_checkbox.IsChecked = Convert.ToBoolean(data_entries[12]);

                        CM_cox_checkbox.IsChecked = Convert.ToBoolean(data_entries[13]);
                        team_size = Convert.ToInt32(data_entries[14]);
                        toa_raid_lvl = Convert.ToInt32(data_entries[15]);
                        toa_path_lvl = Convert.ToInt32(data_entries[16]);

                        Dispatcher.Invoke(monsters);
                    }
                }
                monster_count.Add(Convert.ToString(multiple_dps_monster_name_combobox.Items.Count));
                giga_data_list.Clear();

                giga_data_list.Add(multiple_loadout_name_data_list); // 0
                giga_data_list.Add(multiple_weapon_name_data_list); // 1
                giga_data_list.Add(multiple_combat_style_data_list); // 2
                giga_data_list.Add(multiple_max_hit_data_list); // 3
                giga_data_list.Add(multiple_max_attack_roll_data_list); // 4
                giga_data_list.Add(multiple_hit_chance_data_list); // 5
                giga_data_list.Add(multiple_avg_dmg_data_list); // 6
                giga_data_list.Add(multiple_dps_data_list); // 7
                giga_data_list.Add(multiple_avg_dmg_overkill_data_list); // 8
                giga_data_list.Add(multiple_dps_overkill_data_list); // 9
                giga_data_list.Add(multiple_avg_hits_to_kill_data_list); // 10
                giga_data_list.Add(multiple_time_to_kill_data_list); // 11

                giga_data_list.Add(multiple_monsters_names_data_list); // 12
                giga_data_list.Add(multiple_monsters_stats_data_list); // 13

                giga_data_list.Add(monster_count); //giga janky 14

                multiple_calcs = false;
                show_results_button.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("No iterations to calculate");
                multiple_calcs = false;
            }
        }
        // loadouts
        private void save_loadout_data()
        {
            // player levels and potions + dragon pickaxe spec
            loadout_data = attack_lvl + ";" + strength_lvl + ";" + defence_lvl + ";" + magic_lvl + ";" + range_lvl + ";" + hp_lvl + ";" + prayer_lvl + ";" + mining_lvl + ";" + atk_pot_name + ";" + str_pot_name + ";" + def_pot_name + ";" + magic_pot_name + ";" + range_pot_name + ";" + dragon_picaxe_spec_checkbox.IsChecked + ";";
            // player level modifiers and prayers
            loadout_data += attack_lvl_and_pot_modifier + ";" + strength_lvl_and_pot_modifier + ";" + defence_lvl_and_pot_modifier + ";" + magic_lvl_and_pot_modifier + ";" + range_lvl_and_pot_modifier + ";" + hp_remaining + ";" + prayer_remaining + ";" + atk_prayer_name + ";" + str_prayer_name + ";" + def_prayer_name + ";" + magic_prayer_name + ";" + range_prayer_name + ";";
            // player gear
            loadout_data += weapon_name_array[0] + ";" + spell_name_array[0] + ";" + ammo_name_array[0] + ";" + helmet_name_array[0] + ";" + cape_name_array[0] + ";" + amulet_name_array[0] + ";" + body_name_array[0] + ";" + legs_name_array[0] + ";" + off_hand_name_array[0] + ";" + gloves_name_array[0] + ";" + boots_name_array[0] + ";" + ring_name_array[0] + ";";
            // offencive stats modifiers
            loadout_data += stab_atk_modifier_array[0] + ";" + slash_atk_modifier_array[0] + ";" + crush_atk_modifier_array[0] + ";" + melee_str_modifier_array[0] + ";" + magic_atk_modifier_array[0] + ";" + magic_dmg_modifier_array[0] + ";" + range_atk_modifier_array[0] + ";" + range_str_modifier_array[0]  + ";" + custom_attack_speed_array[0] + ";" + custom_attack_speed_checkbox.IsChecked + ";";
            // defensive stats modifiers
            loadout_data += stab_def_modifier_array[0] + ";" + slash_def_modifier_array[0] + ";" + crush_def_modifier_array[0] + ";" + magic_def_modifier_array[0] + ";" + range_def_modifier_array[0] + ";";
            // venator bow
            loadout_data += venator_bow_1st_bounce_def_lvl + ";" + venator_bow_1st_bounce_range_def + ";" + venator_1st_bounce_checkbox.IsChecked + ";" + venator_bow_2nd_bounce_def_lvl + ";" + venator_bow_2nd_bounce_range_def + ";" + venator_2nd_bounce_checkbox.IsChecked + ";";
            // thralls, soulreaper axe stac, chin
            loadout_data += thrall_name + ";" + thrall_dps_checkbox.IsChecked + ";" + soulreaper_axe_stack + ";" + distance_to_monster;

            if (custom_loadout_name_textbox.Text != "")
            {
                if (custom_loadout_name_textbox.Text != "Set 1" && custom_loadout_name_textbox.Text != "Set 2")
                {
                    try
                    {
                        string folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        string new_folder_path = System.IO.Path.Combine(folder_path, "Osrs dps calculator loadouts");
                        if (!Directory.Exists(new_folder_path))
                        {
                            Directory.CreateDirectory(new_folder_path);
                        }

                        string file_path = System.IO.Path.Combine(new_folder_path, custom_loadout_name_textbox.Text + ".txt");

                        if (File.Exists(file_path))
                        {
                            var Result = MessageBox.Show($"Loadout '{custom_loadout_name_textbox.Text}' already exists. Would you like to overwrite it?", "Loadout name already exists", MessageBoxButton.YesNo);
                            if (Result == MessageBoxResult.Yes)
                            {
                                File.WriteAllText(file_path, loadout_data);
                                MessageBox.Show($"Loadout '{custom_loadout_name_textbox.Text}' was overwritten", "Loadout overwritten");
                            }
                            else
                            {
                                MessageBox.Show($"Loadout '{custom_loadout_name_textbox.Text}' was not saved", "Loadout not saved");
                            }
                        }
                        else
                        {
                            File.WriteAllText(file_path, loadout_data);
                            MessageBox.Show($"Loadout '{custom_loadout_name_textbox.Text}' was saved", "Loadout saved");
                        }
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        MessageBox.Show("" + ex, "Error while writing data to file");
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show("" + ex, "Error while writing data to file");
                    }
                    catch (PathTooLongException ex)
                    {
                        MessageBox.Show("" + ex, "Error while writing data to file");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Access to file denied by operating system \n" + ex, "Error while writing data to file");
                    }
                    catch (Exception ex)
                    {
                        // default
                        MessageBox.Show("Error saving loadout \n" + ex, "Error while writing data to file");
                    }
                }
                else
                {
                    MessageBox.Show("Loadout name can't be Set 1, or Set 2", "Error while writing data to file");
                }              
            }
            else
            {
                MessageBox.Show("Please insert a name for your loadout", "Error while writing data to file");
            }


        }
        private void load_loadout_names_data()
        {
            try
            {
                string folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string new_folder_path = System.IO.Path.Combine(folder_path, "Osrs dps calculator loadouts");

                if (!Directory.Exists(new_folder_path))
                {
                    var Result = MessageBox.Show("Would you like to use loadouts? Loadouts are your custom made gear, potion, prayer, stat modifier setups. This will make folder in \"My documents\"", "Loadout", MessageBoxButton.YesNo);
                    if (Result == MessageBoxResult.Yes)
                    {
                        Directory.CreateDirectory(new_folder_path);
                        MessageBox.Show("Loadouts enabled", "Loadout");
                    }
                    else
                    {
                        MessageBox.Show("Loadouts disabled", "Loadout");
                    }
                }

                load_loadout_combobox.Items.Clear();
                string[] textfiles = Directory.GetFiles(new_folder_path, "*.txt");
                foreach (string filepath in textfiles)
                {
                    string file_name = System.IO.Path.GetFileName(filepath);
                    load_loadout_combobox.Items.Add(file_name.Substring(0, file_name.Length - 4));
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("" + ex, "Error while reading data from file");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("" + ex, "Error while reading data from file");
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show("" + ex, "Error while reading data from file");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Access to file denied by operating system \n" + ex, "Error while reading data from file");
            }
            catch (Exception ex)
            {
                // default
                MessageBox.Show("Error loading loadout \n" + ex, "Error while reading data from file");
            }
        }
        private void load_set_1_and_2_data()
        {
            string[] data_entries = set_1_during_multicalc.Split(';');

            if (loadout_name == "Set 2")
            {
                data_entries = set_2_during_multicalc.Split(';');
            }

            // player levels and potions + dragon pickaxe spec
            attack_lvl = Convert.ToDouble(data_entries[0]);
            strength_lvl = Convert.ToDouble(data_entries[1]);
            defence_lvl = Convert.ToDouble(data_entries[2]);
            magic_lvl = Convert.ToDouble(data_entries[3]);
            range_lvl = Convert.ToDouble(data_entries[4]);
            hp_lvl = Convert.ToDouble(data_entries[5]);
            prayer_lvl = Convert.ToDouble(data_entries[6]);
            mining_lvl = Convert.ToDouble(data_entries[7]);
            atk_pot_name = data_entries[8];
            str_pot_name = data_entries[9];
            def_pot_name = data_entries[10];
            magic_pot_name = data_entries[11];
            range_pot_name = data_entries[12];
            dragon_picaxe_spec_checkbox.IsChecked = Convert.ToBoolean(data_entries[13]);

            // player level modifiers and prayers
            attack_lvl_and_pot_modifier = Convert.ToDouble(data_entries[14]);
            strength_lvl_and_pot_modifier = Convert.ToDouble(data_entries[15]);
            defence_lvl_and_pot_modifier = Convert.ToDouble(data_entries[16]);
            magic_lvl_and_pot_modifier = Convert.ToDouble(data_entries[17]);
            range_lvl_and_pot_modifier = Convert.ToDouble(data_entries[18]);
            hp_remaining = Convert.ToDouble(data_entries[19]);
            prayer_remaining = Convert.ToDouble(data_entries[20]);
            atk_prayer_name = data_entries[21];
            str_prayer_name = data_entries[22];
            def_prayer_name = data_entries[23];
            magic_prayer_name = data_entries[24];
            range_prayer_name = data_entries[25];

            // player gear
            weapon_name_array[0] = data_entries[26];
            spell_name_array[0] = data_entries[27];
            ammo_name_array[0] = data_entries[28];
            helmet_name_array[0] = data_entries[29];
            cape_name_array[0] = data_entries[30];
            amulet_name_array[0] = data_entries[31];
            body_name_array[0] = data_entries[32];
            legs_name_array[0] = data_entries[33];
            off_hand_name_array[0] = data_entries[34];
            gloves_name_array[0] = data_entries[35];
            boots_name_array[0] = data_entries[36];
            ring_name_array[0] = data_entries[37];

            // offencive stats modifiers
            stab_atk_modifier_array[0] = Convert.ToDouble(data_entries[38]);
            slash_atk_modifier_array[0] = Convert.ToDouble(data_entries[39]);
            crush_atk_modifier_array[0] = Convert.ToDouble(data_entries[40]);
            melee_str_modifier_array[0] = Convert.ToDouble(data_entries[41]);
            magic_atk_modifier_array[0] = Convert.ToDouble(data_entries[42]);
            magic_dmg_modifier_array[0] = Convert.ToDouble(data_entries[43]);
            range_atk_modifier_array[0] = Convert.ToDouble(data_entries[44]);
            range_str_modifier_array[0] = Convert.ToDouble(data_entries[45]);
            custom_attack_speed_array[0] = Convert.ToDouble(data_entries[46]);
            custom_attack_speed_checkbox.IsChecked = Convert.ToBoolean(data_entries[47]);

            // defensive stats modifiers
            stab_def_modifier_array[0] = Convert.ToDouble(data_entries[48]);
            slash_def_modifier_array[0] = Convert.ToDouble(data_entries[49]);
            crush_def_modifier_array[0] = Convert.ToDouble(data_entries[50]);
            magic_def_modifier_array[0] = Convert.ToDouble(data_entries[51]);
            range_def_modifier_array[0] = Convert.ToDouble(data_entries[52]);

            // venator bow
            venator_bow_1st_bounce_def_lvl = Convert.ToDouble(data_entries[53]);
            venator_bow_1st_bounce_range_def = Convert.ToDouble(data_entries[54]);
            venator_1st_bounce_checkbox.IsChecked = Convert.ToBoolean(data_entries[55]);
            venator_bow_2nd_bounce_def_lvl = Convert.ToDouble(data_entries[56]);
            venator_bow_2nd_bounce_range_def = Convert.ToDouble(data_entries[57]);
            venator_2nd_bounce_checkbox.IsChecked = Convert.ToBoolean(data_entries[58]);

            // thralls, soulreaper axe stac, chin
            thrall_name = data_entries[59];
            thrall_dps_checkbox.IsChecked = Convert.ToBoolean(data_entries[60]);
            soulreaper_axe_stack = Convert.ToDouble(data_entries[61]);
            distance_to_monster = Convert.ToDouble(data_entries[62]);


            from_load = true;

            Dispatcher.Invoke(gear);
            Dispatcher.Invoke(potions);
            Dispatcher.Invoke(prayers);
            Dispatcher.Invoke(spell_gear);

            from_load = false;

            if (multiple_calcs == false)
            {
                Dispatcher.Invoke(Stats);
            }
        }
        private void load_loadout_data()
        {
            try
            {
                string folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string new_folder_path = System.IO.Path.Combine(folder_path, "Osrs dps calculator loadouts");
                string file_path = System.IO.Path.Combine(new_folder_path, loadout_name + ".txt");
                string file_content = File.ReadAllText(file_path);
                string[] data_entries = file_content.Split(';');

                // player levels and potions + dragon pickaxe spec
                attack_lvl = Convert.ToDouble(data_entries[0]);
                strength_lvl = Convert.ToDouble(data_entries[1]);
                defence_lvl = Convert.ToDouble(data_entries[2]);
                magic_lvl = Convert.ToDouble(data_entries[3]);
                range_lvl = Convert.ToDouble(data_entries[4]);
                hp_lvl = Convert.ToDouble(data_entries[5]);
                prayer_lvl = Convert.ToDouble(data_entries[6]);
                mining_lvl = Convert.ToDouble(data_entries[7]);
                atk_pot_name = data_entries[8];
                str_pot_name = data_entries[9];
                def_pot_name = data_entries[10];
                magic_pot_name = data_entries[11];
                range_pot_name = data_entries[12];
                dragon_picaxe_spec_checkbox.IsChecked = Convert.ToBoolean(data_entries[13]);

                // player level modifiers and prayers
                attack_lvl_and_pot_modifier = Convert.ToDouble(data_entries[14]);
                strength_lvl_and_pot_modifier = Convert.ToDouble(data_entries[15]);
                defence_lvl_and_pot_modifier = Convert.ToDouble(data_entries[16]);
                magic_lvl_and_pot_modifier = Convert.ToDouble(data_entries[17]);
                range_lvl_and_pot_modifier = Convert.ToDouble(data_entries[18]);
                hp_remaining = Convert.ToDouble(data_entries[19]);
                prayer_remaining = Convert.ToDouble(data_entries[20]);
                atk_prayer_name = data_entries[21];
                str_prayer_name = data_entries[22];
                def_prayer_name = data_entries[23];
                magic_prayer_name = data_entries[24];
                range_prayer_name = data_entries[25];

                // player gear
                weapon_name_array[0] = data_entries[26];
                spell_name_array[0] = data_entries[27];
                ammo_name_array[0] = data_entries[28];
                helmet_name_array[0] = data_entries[29];
                cape_name_array[0] = data_entries[30];
                amulet_name_array[0] = data_entries[31];
                body_name_array[0] = data_entries[32];
                legs_name_array[0] = data_entries[33];
                off_hand_name_array[0] = data_entries[34];
                gloves_name_array[0] = data_entries[35];
                boots_name_array[0] = data_entries[36];
                ring_name_array[0] = data_entries[37];

                // offencive stats modifiers
                stab_atk_modifier_array[0] = Convert.ToDouble(data_entries[38]);
                slash_atk_modifier_array[0] = Convert.ToDouble(data_entries[39]);
                crush_atk_modifier_array[0] = Convert.ToDouble(data_entries[40]);
                melee_str_modifier_array[0] = Convert.ToDouble(data_entries[41]);
                magic_atk_modifier_array[0] = Convert.ToDouble(data_entries[42]);
                magic_dmg_modifier_array[0] = Convert.ToDouble(data_entries[43]);
                range_atk_modifier_array[0] = Convert.ToDouble(data_entries[44]);
                range_str_modifier_array[0] = Convert.ToDouble(data_entries[45]);
                custom_attack_speed_array[0] = Convert.ToDouble(data_entries[46]);
                custom_attack_speed_checkbox.IsChecked = Convert.ToBoolean(data_entries[47]);

                // defensive stats modifiers
                stab_def_modifier_array[0] = Convert.ToDouble(data_entries[48]);
                slash_def_modifier_array[0] = Convert.ToDouble(data_entries[49]);
                crush_def_modifier_array[0] = Convert.ToDouble(data_entries[50]);
                magic_def_modifier_array[0] = Convert.ToDouble(data_entries[51]);
                range_def_modifier_array[0] = Convert.ToDouble(data_entries[52]);

                // venator bow
                venator_bow_1st_bounce_def_lvl = Convert.ToDouble(data_entries[53]);
                venator_bow_1st_bounce_range_def = Convert.ToDouble(data_entries[54]);
                venator_1st_bounce_checkbox.IsChecked = Convert.ToBoolean(data_entries[55]);
                venator_bow_2nd_bounce_def_lvl = Convert.ToDouble(data_entries[56]);
                venator_bow_2nd_bounce_range_def = Convert.ToDouble(data_entries[57]);
                venator_2nd_bounce_checkbox.IsChecked = Convert.ToBoolean(data_entries[58]);

                // thralls, soulreaper axe stac, chin
                thrall_name = data_entries[59];
                thrall_dps_checkbox.IsChecked = Convert.ToBoolean(data_entries[60]);
                soulreaper_axe_stack = Convert.ToDouble(data_entries[61]);
                distance_to_monster = Convert.ToDouble(data_entries[62]);


                from_load = true;

                Dispatcher.Invoke(gear);
                Dispatcher.Invoke(potions);
                Dispatcher.Invoke(prayers);
                Dispatcher.Invoke(spell_gear);

                from_load = false;

                if (multiple_calcs == false)
                {
                    Dispatcher.Invoke(Stats);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("" + ex, "Error while reading data from file");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("" + ex, "Error while reading data from file");
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show("" + ex, "Error while reading data from file");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Access to file denied by operating system \n" + ex, "Error while reading data from file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading loadouts \n" + ex, "Error while reading data from file");
            }
        }
        private void delete_loadout()
        {
            try
            {
                if (load_loadout_combobox.Text != "")
                {
                    string folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string new_folder_path = System.IO.Path.Combine(folder_path, "Osrs dps calculator loadouts");
                    string file_path = System.IO.Path.Combine(new_folder_path, load_loadout_combobox.Text + ".txt");

                    var Result = MessageBox.Show($"Are you sure you want to delete loadout '{load_loadout_combobox.Text}' ?", "Loadout deleting", MessageBoxButton.YesNo);
                    if (Result == MessageBoxResult.Yes)
                    {
                        File.Delete(file_path);
                        MessageBox.Show($"Loadout '{load_loadout_combobox.Text}' was deleted", "Loadout deleted");
                        loadout_was_deleted = true;
                        deleted_loadout_name = load_loadout_combobox.Text;
                    }
                    else
                    {
                        MessageBox.Show($"Loadout '{load_loadout_combobox.Text}' was not deleted", "Loadout not deleted");
                    }
                }
                else
                {
                    MessageBox.Show("No loadout selected", "Error while reading data from file");
                }


            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("" + ex, "Error while deleting data from file");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("" + ex, "Error while deleting data from file");
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show("" + ex, "Error while deleting data from file");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Access to file denied by operating system \n" + ex, "Error while deleting data from file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting loadout \n" + ex, "Error while deleting data from file");
            }
        }
        // -------------------------------------------------------------------------------------
        // just way too much gear,monster, stats, userinputs etc coded from this point onwards       
        // ----------------GEAR----------------
        private void gear()
        {
            gear_set_2 = false;

            Dispatcher.Invoke(weapon_gear);
            Dispatcher.Invoke(ammo_gear);
            Dispatcher.Invoke(helmet_gear);
            Dispatcher.Invoke(cape_gear);
            Dispatcher.Invoke(amulet_gear);
            Dispatcher.Invoke(body_gear);
            Dispatcher.Invoke(legs_gear);
            Dispatcher.Invoke(off_hand_gear);
            Dispatcher.Invoke(gloves_gear);
            Dispatcher.Invoke(boots_gear);
            Dispatcher.Invoke(ring_gear);

            if (from_load == false)
            {
                Dispatcher.Invoke(Stats);
            }           
        }
        private void copy_1_to_2_gear(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(helmet_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                helmet_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(helmet_gear);
            }
            temp_string = Convert.ToString(cape_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                cape_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(cape_gear);
            }
            temp_string = Convert.ToString(necklace_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                amulet_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(amulet_gear);
            }
            temp_string = Convert.ToString(ammo_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                ammo_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ammo_gear);
            }
            temp_string = Convert.ToString(weapon_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                weapon_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(weapon_gear);
            }
            temp_string = Convert.ToString(body_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                body_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(body_gear);
            }
            temp_string = Convert.ToString(off_hand_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                off_hand_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(off_hand_gear);
            }
            temp_string = Convert.ToString(legs_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                legs_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(legs_gear);
            }
            temp_string = Convert.ToString(gloves_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                gloves_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gloves_gear);
            }
            temp_string = Convert.ToString(boots_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                boots_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(boots_gear);
            }
            temp_string = Convert.ToString(ring_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                ring_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ring_gear);
            }
            temp_string = Convert.ToString(spell_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                spell_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(spell_gear);
            }

            Dispatcher.Invoke(Stats);
        }
        private void copy_2_to_1_gear(object sender, RoutedEventArgs e)
        {
            gear_set_2 = false;
            string temp_string = Convert.ToString(helmet_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                helmet_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(helmet_gear);
            }
            temp_string = Convert.ToString(cape_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                cape_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(cape_gear);
            }
            temp_string = Convert.ToString(necklace_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                amulet_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(amulet_gear);
            }
            temp_string = Convert.ToString(ammo_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                ammo_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ammo_gear);
            }
            temp_string = Convert.ToString(weapon_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                weapon_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(weapon_gear);
            }
            temp_string = Convert.ToString(body_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                body_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(body_gear);
            }
            temp_string = Convert.ToString(off_hand_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                off_hand_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(off_hand_gear);
            }
            temp_string = Convert.ToString(legs_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                legs_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(legs_gear);
            }
            temp_string = Convert.ToString(gloves_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gloves_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gloves_gear);
            }
            temp_string = Convert.ToString(boots_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                boots_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(boots_gear);
            }
            temp_string = Convert.ToString(ring_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                ring_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ring_gear);
            }
            temp_string = Convert.ToString(spell_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                spell_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(spell_gear);
            }

            Dispatcher.Invoke(Stats);
        }
        // ----------------HELMETS----------------
        private void helmet_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (helmet_name_array[j])
            {
                default:
                    MessageBox.Show("Helmet not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 0;
                    range_atk_array[i+0] = 0;
                    stab_def_array[i+0] = 0;
                    slash_def_array[i+0] = 0;
                    crush_def_array[i+0] = 0;
                    magic_def_array[i+0] = 0;
                    range_def_array[i+0] = 0;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "Torva full helm":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = -5;
                    range_atk_array[i+0] = -5;
                    stab_def_array[i + 0] = 59;
                    slash_def_array[i + 0] = 60;
                    crush_def_array[i + 0] = 62;
                    magic_def_array[i + 0] = -2;
                    range_def_array[i + 0] = 57;
                    melee_str_array[i+0] = 8;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 1;
                    break;
                case "Neitiznot faceguard":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 0;
                    range_atk_array[i+0] = 0;
                    stab_def_array[i + 0] = 36;
                    slash_def_array[i + 0] = 34;
                    crush_def_array[i + 0] = 38;
                    magic_def_array[i + 0] = 3;
                    range_def_array[i + 0] = 34;
                    melee_str_array[i+0] = 6;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 3;
                    break;
                case "Inquisitor's great helm":
                    stab_atk_array[i+0] = -2;
                    slash_atk_array[i+0] = -2;
                    crush_atk_array[i+0] = +8;
                    magic_atk_array[i+0] = -5;
                    range_atk_array[i+0] = -5;
                    stab_def_array[i + 0] = 19;
                    slash_def_array[i + 0] = 10;
                    crush_def_array[i + 0] = 21;
                    magic_def_array[i + 0] = 0;
                    range_def_array[i + 0] = 12;
                    melee_str_array[i+0] = 4;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 1;
                    break;
                case "Serpentine helm":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = -5;
                    range_atk_array[i+0] = -5;
                    stab_def_array[i + 0] = 52;
                    slash_def_array[i + 0] = 55;
                    crush_def_array[i + 0] = 58;
                    magic_def_array[i + 0] = 0;
                    range_def_array[i + 0] = 50;
                    melee_str_array[i+0] = 5;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "Justiciar faceguard":
                    stab_atk_array[i + 0] = 0;
                    slash_atk_array[i + 0] = 0;
                    crush_atk_array[i + 0] = 0;
                    magic_atk_array[i + 0] = -6;
                    range_atk_array[i + 0] = -2;
                    stab_def_array[i + 0] = 60;
                    slash_def_array[i + 0] = 63;
                    crush_def_array[i + 0] = 59;
                    magic_def_array[i + 0] = -6;
                    range_def_array[i + 0] = 67;
                    melee_str_array[i + 0] = 0;
                    range_str_array[i + 0] = 0;
                    magic_dmg_array[i + 0] = 0;
                    prayer_bonus_array[i + 0] = 2;
                    break;
                case "Ancestral hat":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 8;
                    range_atk_array[i+0] = -2;
                    stab_def_array[i + 0] = 12;
                    slash_def_array[i + 0] = 11;
                    crush_def_array[i + 0] = 13;
                    magic_def_array[i + 0] = 5;
                    range_def_array[i + 0] = 0;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 2;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "Virtus mask":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 8;
                    range_atk_array[i+0] = -3;
                    stab_def_array[i + 0] = 15;
                    slash_def_array[i + 0] = 14;
                    crush_def_array[i + 0] = 16;
                    magic_def_array[i + 0] = 6;
                    range_def_array[i + 0] = 0;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 1;
                    prayer_bonus_array[i + 0] = 1;
                    break;
                case "Ahrim's hood":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 6;
                    range_atk_array[i+0] = -2;
                    stab_def_array[i + 0] = 15;
                    slash_def_array[i + 0] = 13;
                    crush_def_array[i + 0] = 16;
                    magic_def_array[i + 0] = 6;
                    range_def_array[i + 0] = 0;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "Masori mask (f)":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = -1;
                    range_atk_array[i+0] = 12;
                    stab_def_array[i + 0] = 8;
                    slash_def_array[i + 0] = 10;
                    crush_def_array[i + 0] = 12;
                    magic_def_array[i + 0] = 12;
                    range_def_array[i + 0] = 12;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 2;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 1;
                    break;
                case "Armadyl helmet":
                    stab_atk_array[i+0] = -5;
                    slash_atk_array[i+0] = -5;
                    crush_atk_array[i+0] = -5;
                    magic_atk_array[i+0] = -5;
                    range_atk_array[i+0] = 10;
                    stab_def_array[i + 0] = 6;
                    slash_def_array[i + 0] = 8;
                    crush_def_array[i + 0] = 10;
                    magic_def_array[i + 0] = 10;
                    range_def_array[i + 0] = 8;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 1;
                    break;
                case "Crystal helm":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = -10;
                    range_atk_array[i+0] = 9;
                    stab_def_array[i + 0] = 12;
                    slash_def_array[i + 0] = 8;
                    crush_def_array[i + 0] = 14;
                    magic_def_array[i + 0] = 10;
                    range_def_array[i + 0] = 18;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 2;
                    break;
                case "Robin hood hat":
                    stab_atk_array[i + 0] = 0;
                    slash_atk_array[i + 0] = 0;
                    crush_atk_array[i + 0] = 0;
                    magic_atk_array[i + 0] = -10;
                    range_atk_array[i + 0] = 8;
                    stab_def_array[i + 0] = 4;
                    slash_def_array[i + 0] = 6;
                    crush_def_array[i + 0] = 8;
                    magic_def_array[i + 0] = 4;
                    range_def_array[i + 0] = 4;
                    melee_str_array[i + 0] = 0;
                    range_str_array[i + 0] = 0;
                    magic_dmg_array[i + 0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "God d'hide coif":
                    stab_atk_array[i + 0] = 0;
                    slash_atk_array[i + 0] = 0;
                    crush_atk_array[i + 0] = 0;
                    magic_atk_array[i + 0] = -1;
                    range_atk_array[i + 0] = 7;
                    stab_def_array[i + 0] = 4;
                    slash_def_array[i + 0] = 7;
                    crush_def_array[i + 0] = 10;
                    magic_def_array[i + 0] = 4;
                    range_def_array[i + 0] = 8;
                    melee_str_array[i + 0] = 0;
                    range_str_array[i + 0] = 0;
                    magic_dmg_array[i + 0] = 0;
                    prayer_bonus_array[i + 0] = 1;
                    break;
                case "Archer helm":
                    stab_atk_array[i + 0] = 0;
                    slash_atk_array[i + 0] = 0;
                    crush_atk_array[i + 0] = 0;
                    magic_atk_array[i + 0] = -5;
                    range_atk_array[i + 0] = 6;
                    stab_def_array[i + 0] = 6;
                    slash_def_array[i + 0] = 8;
                    crush_def_array[i + 0] = 10;
                    magic_def_array[i + 0] = 6;
                    range_def_array[i + 0] = 6;
                    melee_str_array[i + 0] = 0;
                    range_str_array[i + 0] = 0;
                    magic_dmg_array[i + 0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "Slayer helmet (i)":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 3;
                    range_atk_array[i+0] = 3;
                    stab_def_array[i + 0] = 30;
                    slash_def_array[i + 0] = 32;
                    crush_def_array[i + 0] = 27;
                    magic_def_array[i + 0] = 10;
                    range_def_array[i + 0] = 30;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
                case "Void helmet":
                    stab_atk_array[i+0] = 0;
                    slash_atk_array[i+0] = 0;
                    crush_atk_array[i+0] = 0;
                    magic_atk_array[i+0] = 0;
                    range_atk_array[i+0] = 0;
                    stab_def_array[i + 0] = 6;
                    slash_def_array[i + 0] = 6;
                    crush_def_array[i + 0] = 6;
                    magic_def_array[i + 0] = 6;
                    range_def_array[i + 0] = 6;
                    melee_str_array[i+0] = 0;
                    range_str_array[i+0] = 0;
                    magic_dmg_array[i+0] = 0;
                    prayer_bonus_array[i + 0] = 0;
                    break;
            }

            gear_set_2 = false;
        }
        private void helmet_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(helmet_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                helmet_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(helmet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void helmet_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(helmet_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                helmet_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(helmet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_helmet(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(helmet_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                helmet_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(helmet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_helmet(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(helmet_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                helmet_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(helmet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        // ----------------CAPES----------------
        private void cape_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (cape_name_array[j])
            {
                default:
                    MessageBox.Show("Cape not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+1] = 0;
                    slash_atk_array[i+1] = 0;
                    crush_atk_array[i+1] = 0;
                    magic_atk_array[i+1] = 0;
                    range_atk_array[i+1] = 0;
                    stab_def_array[i + 1] = 0;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 0;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i+1] = 0;
                    range_str_array[i+1] = 0;
                    magic_dmg_array[i+1] = 0;
                    prayer_bonus_array[i + 1] = 0;
                    break;
                case "Infernal cape":
                    stab_atk_array[i+1] = 4;
                    slash_atk_array[i+1] = 4;
                    crush_atk_array[i+1] = 4;
                    magic_atk_array[i+1] = 1;
                    range_atk_array[i+1] = 1;
                    stab_def_array[i + 1] = 12;
                    slash_def_array[i + 1] = 12;
                    crush_def_array[i + 1] = 12;
                    magic_def_array[i + 1] = 12;
                    range_def_array[i + 1] = 12;
                    melee_str_array[i+1] = 8;
                    range_str_array[i+1] = 0;
                    magic_dmg_array[i+1] = 0;
                    prayer_bonus_array[i + 1] = 2;
                    break;
                case "Fire cape":
                    stab_atk_array[i+1] = 1;
                    slash_atk_array[i+1] = 1;
                    crush_atk_array[i+1] = 1;
                    magic_atk_array[i+1] = 1;
                    range_atk_array[i+1] = 1;
                    stab_def_array[i + 1] = 11;
                    slash_def_array[i + 1] = 11;
                    crush_def_array[i + 1] = 11;
                    magic_def_array[i + 1] = 11;
                    range_def_array[i + 1] = 11;
                    melee_str_array[i+1] = 4;
                    range_str_array[i+1] = 0;
                    magic_dmg_array[i+1] = 0;
                    prayer_bonus_array[i + 1] = 2;
                    break;
                case "Mythical cape":
                    stab_atk_array[i+1] = 0;
                    slash_atk_array[i+1] = 0;
                    crush_atk_array[i+1] = 6;
                    magic_atk_array[i+1] = 0;
                    range_atk_array[i+1] = 0;
                    stab_def_array[i + 1] = 8;
                    slash_def_array[i + 1] = 8;
                    crush_def_array[i + 1] = 8;
                    magic_def_array[i + 1] = 8;
                    range_def_array[i + 1] = 8;
                    melee_str_array[i+1] = 1;
                    range_str_array[i+1] = 0;
                    magic_dmg_array[i+1] = 0;
                    prayer_bonus_array[i + 1] = 1;
                    break;
                case "God cape (i)":
                    stab_atk_array[i+1] = 0;
                    slash_atk_array[i+1] = 0;
                    crush_atk_array[i+1] = 0;
                    magic_atk_array[i+1] = 15;
                    range_atk_array[i+1] = 0;
                    stab_def_array[i + 1] = 3;
                    slash_def_array[i + 1] = 3;
                    crush_def_array[i + 1] = 3;
                    magic_def_array[i + 1] = 15;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i+1] = 0;
                    range_str_array[i+1] = 0;
                    magic_dmg_array[i+1] = 2;
                    prayer_bonus_array[i + 1] = 0;
                    break;
                case "God cape":
                    stab_atk_array[i+1] = 0;
                    slash_atk_array[i+1] = 0;
                    crush_atk_array[i+1] = 0;
                    magic_atk_array[i+1] = 10;
                    range_atk_array[i+1] = 0;
                    stab_def_array[i + 1] = 1;
                    slash_def_array[i + 1] = 1;
                    crush_def_array[i + 1] = 2;
                    magic_def_array[i + 1] = 10;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i+1] = 0;
                    range_str_array[i+1] = 0;
                    magic_dmg_array[i+1] = 0;
                    prayer_bonus_array[i + 1] = 0;
                    break;
                case "Ardougne cloak 4":
                    stab_atk_array[i + 1] = 6;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 6;
                    range_atk_array[i + 1] = 0;
                    stab_def_array[i + 1] = 6;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 6;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 6;
                    break;
                case "Ardougne cloak 3":
                    stab_atk_array[i + 1] = 5;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 5;
                    range_atk_array[i + 1] = 0;
                    stab_def_array[i + 1] = 5;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 5;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 5;
                    break;
                case "Ghostly cloak":
                    stab_atk_array[i + 1] = 0;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 5;
                    range_atk_array[i + 1] = 0;
                    stab_def_array[i + 1] = 0;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 5;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 0;
                    break;
                case "Ardougne cloak 2":
                    stab_atk_array[i + 1] = 4;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 4;
                    range_atk_array[i + 1] = 0;
                    stab_def_array[i + 1] = 4;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 4;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 4;
                    break;
                case "Ardougne cloak 1":
                    stab_atk_array[i + 1] = 2;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 2;
                    range_atk_array[i + 1] = 0;
                    stab_def_array[i + 1] = 2;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 2;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 2;
                    break;
                case "God cloak":
                    stab_atk_array[i + 1] = 0;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 1;
                    range_atk_array[i + 1] = 0;
                    stab_def_array[i + 1] = 3;
                    slash_def_array[i + 1] = 3;
                    crush_def_array[i + 1] = 3;
                    magic_def_array[i + 1] = 3;
                    range_def_array[i + 1] = 3;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 3;
                    break;
                case "Ava's assembler":
                    stab_atk_array[i+1] = 0;
                    slash_atk_array[i+1] = 0;
                    crush_atk_array[i+1] = 0;
                    magic_atk_array[i+1] = 0;
                    range_atk_array[i+1] = 8;
                    stab_def_array[i + 1] = 1;
                    slash_def_array[i + 1] = 1;
                    crush_def_array[i + 1] = 1;
                    magic_def_array[i + 1] = 8;
                    range_def_array[i + 1] = 2;
                    melee_str_array[i+1] = 0;
                    range_str_array[i+1] = 2;
                    magic_dmg_array[i+1] = 0;
                    prayer_bonus_array[i + 1] = 0;
                    break;
                case "Ava's accumulator":
                    stab_atk_array[i + 1] = 0;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 0;
                    range_atk_array[i + 1] = 4;
                    stab_def_array[i + 1] = 0;
                    slash_def_array[i + 1] = 1;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 4;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 0;
                    break;
                case "Ava's attractor":
                    stab_atk_array[i + 1] = 0;
                    slash_atk_array[i + 1] = 0;
                    crush_atk_array[i + 1] = 0;
                    magic_atk_array[i + 1] = 0;
                    range_atk_array[i + 1] = 2;
                    stab_def_array[i + 1] = 0;
                    slash_def_array[i + 1] = 0;
                    crush_def_array[i + 1] = 0;
                    magic_def_array[i + 1] = 2;
                    range_def_array[i + 1] = 0;
                    melee_str_array[i + 1] = 0;
                    range_str_array[i + 1] = 0;
                    magic_dmg_array[i + 1] = 0;
                    prayer_bonus_array[i + 1] = 0;
                    break;
            }

            gear_set_2 = false;
        }
        private void cape_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(cape_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                cape_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(cape_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void cape_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(cape_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                cape_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(cape_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_cape(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(cape_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                cape_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(cape_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_cape(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(cape_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                cape_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(cape_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------AMULETS----------------
        private void amulet_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (amulet_name_array[j])
            {
                default:
                    MessageBox.Show("Amulet not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+2] = 0;
                    slash_atk_array[i+2] = 0;
                    crush_atk_array[i+2] = 0;
                    magic_atk_array[i+2] = 0;
                    range_atk_array[i+2] = 0;
                    stab_def_array[i + 2] = 0;
                    slash_def_array[i + 2] = 0;
                    crush_def_array[i + 2] = 0;
                    magic_def_array[i + 2] = 0;
                    range_def_array[i + 2] = 0;
                    melee_str_array[i+2] = 0;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 0;
                    break;
                case "Amulet of torture":
                    stab_atk_array[i+2] = 15;
                    slash_atk_array[i+2] = 15;
                    crush_atk_array[i+2] = 15;
                    magic_atk_array[i+2] = 0;
                    range_atk_array[i+2] = 0;
                    stab_def_array[i + 2] = 0;
                    slash_def_array[i + 2] = 0;
                    crush_def_array[i + 2] = 0;
                    magic_def_array[i + 2] = 0;
                    range_def_array[i + 2] = 0;
                    melee_str_array[i+2] = 10;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 2;
                    break;
                case "Amulet of fury":
                    stab_atk_array[i+2] = 10;
                    slash_atk_array[i+2] = 10;
                    crush_atk_array[i+2] = 10;
                    magic_atk_array[i+2] = 10;
                    range_atk_array[i+2] = 10;
                    stab_def_array[i + 2] = 15;
                    slash_def_array[i + 2] = 15;
                    crush_def_array[i + 2] = 15;
                    magic_def_array[i + 2] = 15;
                    range_def_array[i + 2] = 15;
                    melee_str_array[i+2] = 8;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 5;
                    break;
                case "Amulet of glory":
                    stab_atk_array[i+2] = 10;
                    slash_atk_array[i+2] = 10;
                    crush_atk_array[i+2] = 10;
                    magic_atk_array[i+2] = 10;
                    range_atk_array[i+2] = 10;
                    stab_def_array[i + 2] = 3;
                    slash_def_array[i + 2] = 3;
                    crush_def_array[i + 2] = 3;
                    magic_def_array[i + 2] = 3;
                    range_def_array[i + 2] = 3;
                    melee_str_array[i+2] = 6;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 3;
                    break;
                case "Amulet of strength":
                    stab_atk_array[i+2] = 0;
                    slash_atk_array[i+2] = 0;
                    crush_atk_array[i+2] = 0;
                    magic_atk_array[i+2] = 0;
                    range_atk_array[i+2] = 0;
                    stab_def_array[i + 2] = 0;
                    slash_def_array[i + 2] = 0;
                    crush_def_array[i + 2] = 0;
                    magic_def_array[i + 2] = 0;
                    range_def_array[i + 2] = 0;
                    melee_str_array[i+2] = 10;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 0;
                    break;
                case "Occult necklace":
                    stab_atk_array[i+2] = 0;
                    slash_atk_array[i+2] = 0;
                    crush_atk_array[i+2] = 0;
                    magic_atk_array[i+2] = 12;
                    range_atk_array[i+2] = 0;
                    stab_def_array[i + 2] = 0;
                    slash_def_array[i + 2] = 0;
                    crush_def_array[i + 2] = 0;
                    magic_def_array[i + 2] = 0;
                    range_def_array[i + 2] = 0;
                    melee_str_array[i+2] = 0;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 10;
                    prayer_bonus_array[i + 2] = 2;
                    break;
                case "Necklace of anguish":
                    stab_atk_array[i+2] = 0;
                    slash_atk_array[i+2] = 0;
                    crush_atk_array[i+2] = 0;
                    magic_atk_array[i+2] = 0;
                    range_atk_array[i+2] = 15;
                    stab_def_array[i + 2] = 0;
                    slash_def_array[i + 2] = 0;
                    crush_def_array[i + 2] = 0;
                    magic_def_array[i + 2] = 0;
                    range_def_array[i + 2] = 0;
                    melee_str_array[i+2] = 0;
                    range_str_array[i+2] = 5;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 2;
                    break;
                case "Salve amulet (ei)":
                    stab_atk_array[i+2] = 0;
                    slash_atk_array[i+2] = 0;
                    crush_atk_array[i+2] = 0;
                    magic_atk_array[i+2] = 0;
                    range_atk_array[i+2] = 0;
                    stab_def_array[i + 2] = 3;
                    slash_def_array[i + 2] = 3;
                    crush_def_array[i + 2] = 3;
                    magic_def_array[i + 2] = 0;
                    range_def_array[i + 2] = 0;
                    melee_str_array[i+2] = 0;
                    range_str_array[i+2] = 0;
                    magic_dmg_array[i+2] = 0;
                    prayer_bonus_array[i + 2] = 3;
                    break;
            }

            gear_set_2 = false;
        }
        private void necklace_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(necklace_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                amulet_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(amulet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void necklace_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(necklace_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                amulet_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(amulet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_amulet(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(necklace_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                amulet_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(amulet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_amulet(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(necklace_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                amulet_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(amulet_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------AMMO----------------
        private void ammo_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            stab_atk_array[i + 3] = 0;
            slash_atk_array[i + 3] = 0;
            crush_atk_array[i + 3] = 0;
            magic_atk_array[i + 3] = 0;
            stab_def_array[i + 3] = 0;
            slash_def_array[i + 3] = 0;
            crush_def_array[i + 3] = 0;
            magic_def_array[i + 3] = 0;
            range_def_array[i + 3] = 0;
            melee_str_array[i + 3] = 0;
            magic_dmg_array[i + 3] = 0;
            prayer_bonus_array[i + 3] = 0;

            switch (ammo_name_array[j])
            {
                default:
                    MessageBox.Show("Ammo not found", "Gear name error");
                    break;
                case "None":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 0;
                    break;
                    // arrows
                case "Dragon arrows":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 60;
                    break;
                case "Amethyst arrows":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 55;
                    break;
                case "Rune arrows":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 49;
                    break;
                case "Adamant arrows":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 31;
                    break;
                case "Broad arrows":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 28;
                    break;
                case "Mithril arrows":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 22;
                    break;
                case "Steel arrows":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 16;
                    break;
                case "Iron arrows":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 10;
                    break;
                case "Bronze arrows":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 7;
                    break;
                // darts
                case "Dragon darts":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 35;
                    break;
                case "Amethyst darts":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 28;
                    break;
                case "Rune darts":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 26;
                    break;
                case "Adamant darts":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 17;
                    break;
                case "Mithril darts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 9;
                    break;
                case "Black darts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 6;
                    break;
                case "Steel darts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 3;
                    break;
                case "Iron darts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 2;
                    break;
                case "Bronze darts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 1;
                    break;
                // javelins
                case "Dragon javelins":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 150;
                    break;
                case "Amethyst javelins":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 135;
                    break;
                case "Rune javelins":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 124;
                    break;
                case "Adamant javelins":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 107;
                    break;
                case "Mithril javelins":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 85;
                    break;
                case "Steel javelins":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 64;
                    break;
                case "Iron javelins":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 42;
                    break;
                case "Bronze javelins":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 25;
                    break;
                // bolts
                case "Dragon bolts":
                case "Ruby dragon bolts (e)":
                case "Diamond dragon bolts (e)":
                case "Dragonstone dragon bolts (e)":
                case "Onyx dragon bolts (e)":
                case "Opal dragon bolts (e)":
                case "Pearl dragon bolts (e)":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 122;
                    break;
                case "Dragonstone bolts (e)":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 117;
                    break;
                case "Onyx bolts (e)":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 120;
                    break;
                case "Ruby bolts (e)":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 103;
                    break;
                case "Diamond bolts (e)":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 105;
                    break;
                case "Pearl bolts (e)":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 48;
                    break;
                case "Opal bolts (e)":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 14;
                    break;
                case "Amethyst broad bolts":
                case "Runite bolts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 115;
                    break;
                case "Broad bolts":
                case "Adamant bolts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 100;
                    break;
                case "Mithril bolts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 82;
                    break;
                case "Steel bolts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 64;
                    break;
                case "Iron bolts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 46;
                    break;
                case "Silver bolts":
                    range_atk_array[i + 3] = 0;
                    range_str_array[i + 3] = 36;
                    break;
                case "Bronze bolts":
                    range_atk_array[i+3] = 0;
                    range_str_array[i+3] = 10;
                    break;

            }

            gear_set_2 = false;
        }
        private void ammo_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(ammo_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                ammo_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ammo_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void ammo_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(ammo_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                ammo_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ammo_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_ammo(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(ammo_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                ammo_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ammo_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_ammo(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(ammo_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                ammo_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ammo_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------WEAPON----------------
        private void weapon_gear()
        {
            int i = 0;
            int j = 0;
            int k = 0;

            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
                k = 4;
            }

            switch (weapon_name_array[j])
            {
                default:
                    MessageBox.Show("Weapon not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Scythe of vitur":
                    stab_atk_array[i+4] = 70;
                    slash_atk_array[i+4] = 110;
                    crush_atk_array[i+4] = 30;
                    magic_atk_array[i+4] = -6;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = -2;
                    slash_def_array[i + 4] = 8;
                    crush_def_array[i + 4] = 10;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 75;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Soulreaper axe":
                    stab_atk_array[i+4] = 28;
                    slash_atk_array[i+4] = 134;
                    crush_atk_array[i+4] =66;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 121;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Osmumten's fang":
                    stab_atk_array[i+4] = 105;
                    slash_atk_array[i+4] = 75;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 103;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Inquisitor's mace":
                    stab_atk_array[i+4] = 52;
                    slash_atk_array[i+4] = -4;
                    crush_atk_array[i+4] = 95;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 89;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "crush";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Ghrazi rapier":
                    stab_atk_array[i+4] = 94;
                    slash_atk_array[i+4] = 55;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 89;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Blade of saeldor":
                    stab_atk_array[i+4] = 55;
                    slash_atk_array[i+4] = 94;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 89;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Abyssal tentacle":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 90;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 86;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Abyssal whip":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 82;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 82;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Dragon hunter lance":
                    stab_atk_array[i+4] = 85;
                    slash_atk_array[i+4] = 65;
                    crush_atk_array[i+4] = 65;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 70;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Zamorakian hasta":
                    stab_atk_array[i+4] = 85;
                    slash_atk_array[i+4] = 65;
                    crush_atk_array[i+4] = 65;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 13;
                    slash_def_array[i + 4] = 13;
                    crush_def_array[i + 4] = 12;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 13;
                    melee_str_array[i+4] = 75;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Dragon hasta":
                    stab_atk_array[i+4] = 55;
                    slash_atk_array[i+4] = 55;
                    crush_atk_array[i+4] = 55;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = -15;
                    slash_def_array[i + 4] = -15;
                    crush_def_array[i + 4] = -12;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = -15;
                    melee_str_array[i+4] = 60;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Zamorakian spear":
                    stab_atk_array[i+4] = 85;
                    slash_atk_array[i+4] = 65;
                    crush_atk_array[i+4] = 65;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 13;
                    slash_def_array[i + 4] = 13;
                    crush_def_array[i + 4] = 12;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 13;
                    melee_str_array[i+4] = 75;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Dragon spear":
                    stab_atk_array[i+4] = 55;
                    slash_atk_array[i+4] = 55;
                    crush_atk_array[i+4] = 55;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 5;
                    slash_def_array[i + 4] = 5;
                    crush_def_array[i + 4] = 5;
                    magic_def_array[i + 4] = 5;
                    range_def_array[i + 4] = 5;
                    melee_str_array[i+4] = 60;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "controlled";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Dragon halberd":
                    stab_atk_array[i+4] = 70;
                    slash_atk_array[i+4] = 95;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = -4;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = -1;
                    slash_def_array[i + 4] = 4;
                    crush_def_array[i + 4] = 5;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 89;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 7;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Crystal halberd":
                    stab_atk_array[i+4] = 85;
                    slash_atk_array[i+4] = 110;
                    crush_atk_array[i+4] = 5;
                    magic_atk_array[i+4] = -4;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = -1;
                    slash_def_array[i + 4] = 4;
                    crush_def_array[i + 4] = 5;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 118;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 7;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "controlled";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Ursine chainmace":
                    stab_atk_array[i+4] = 53;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 71;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 74;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "crush";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Viggora's chainmace":
                    stab_atk_array[i+4] = 53;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 67;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 1;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 66;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "crush";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Armadyl godsword":
                case "Ancient godsword":
                case "Bandos godsword":
                case "Saradomin godsword":
                case "Zamorak godsword":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 132;
                    crush_atk_array[i+4] = 80;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 132;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 8;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Abyssal dagger":
                    stab_atk_array[i+4] = 75;
                    slash_atk_array[i+4] = 40;
                    crush_atk_array[i+4] = -4;
                    magic_atk_array[i+4] = 1;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 1;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 75;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Dragon dagger":
                    stab_atk_array[i+4] = 40;
                    slash_atk_array[i+4] = 25;
                    crush_atk_array[i+4] = -4;
                    magic_atk_array[i+4] = 1;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 1;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 40;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Dragon claws":
                    stab_atk_array[i+4] = 41;
                    slash_atk_array[i+4] = 57;
                    crush_atk_array[i+4] = -4;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 13;
                    slash_def_array[i + 4] = 26;
                    crush_def_array[i + 4] = 7;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 56;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Voidwaker":
                    stab_atk_array[i+4] = 70;
                    slash_atk_array[i+4] = 80;
                    crush_atk_array[i+4] = -2;
                    magic_atk_array[i+4] = 5;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 1;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 2;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 80;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Arclight":
                    stab_atk_array[i+4] = 10;
                    slash_atk_array[i+4] = 38;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 3;
                    crush_def_array[i + 4] = 2;
                    magic_def_array[i + 4] = 2;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 8;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "stab";
                    weapon_stance_array[k+2] = "controlled";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Dragon warhammer":
                    stab_atk_array[i+4] = -4;
                    slash_atk_array[i+4] = -4;
                    crush_atk_array[i+4] = 95;
                    magic_atk_array[i+4] = -4;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 85;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Granite hammer":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 57;
                    magic_atk_array[i+4] = -3;
                    range_atk_array[i+4] = -1;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 56;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Granite maul":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 81;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 79;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 7;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Abyssal bludgeon":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 102;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 85;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "aggressive";
                    weapon_type_array[k+1] = "none";
                    weapon_stance_array[k+1] = "none";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Keris partisan of corruption":
                    stab_atk_array[i+4] = 58;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 57;
                    magic_atk_array[i+4] = 2;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 45;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 3;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Keris partisan of the sun":
                case "Keris partisan of breaching":
                case "Keris partisan":
                    stab_atk_array[i+4] = 58;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 57;
                    magic_atk_array[i+4] = 2;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 45;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 3;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Saradomin's blessed sword":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 100;
                    crush_atk_array[i+4] = 60;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 88;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Saradomin sword":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 82;
                    crush_atk_array[i+4] = 60;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 82;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 2;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "slash";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "slash";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "slash";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Swift blade":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "slash";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Ham joint":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 0;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "crush";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "crush";
                    weapon_stance_array[k + 1] = "aggressive";
                    weapon_type_array[k + 2] = "crush";
                    weapon_stance_array[k + 2] = "defensive";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                // mage gear
                case "Tumeken's shadow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 35;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 20;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 1;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Sanguinesti staff":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 25;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 2;
                    slash_def_array[i + 4] = 3;
                    crush_def_array[i + 4] = 1;
                    magic_def_array[i + 4] = 15;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Trident of the swamp":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 25;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 2;
                    slash_def_array[i + 4] = 3;
                    crush_def_array[i + 4] = 1;
                    magic_def_array[i + 4] = 15;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Trident of the seas":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 15;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 2;
                    slash_def_array[i + 4] = 3;
                    crush_def_array[i + 4] = 1;
                    magic_def_array[i + 4] = 15;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Accursed sceptre":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 22;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 20;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Thammaron's sceptre":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 15;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 20;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Dawnbringer":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 25;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 2;
                    slash_def_array[i + 4] = 3;
                    crush_def_array[i + 4] = 1;
                    magic_def_array[i + 4] = 15;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "magic";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "magic";
                    weapon_stance_array[k+1] = "longrange";
                    weapon_type_array[k+2] = "none";
                    weapon_stance_array[k+2] = "none";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Ancient sceptre":
                case "Ice ancient sceptre":
                    stab_atk_array[i+4] = 20;
                    slash_atk_array[i+4] = -1;
                    crush_atk_array[i+4] = 50;
                    magic_atk_array[i+4] = 20;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 2;
                    slash_def_array[i + 4] = 3;
                    crush_def_array[i + 4] = 1;
                    magic_def_array[i + 4] = 15;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 5;
                    prayer_bonus_array[i + 4] = -1;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Harmonised nightmare staff":
                case "Nightmare staff":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 16;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 14;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 15;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Volatile nightmare staff":
                case "Eldritch nightmare staff":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 16;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 14;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 15;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "crush";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "crush";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "defensive";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;


                // range
                case "Twisted bow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 70;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 20;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Bow of faerdhinen":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 128;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 106;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Toxic blowpipe":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 30;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 20;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Venator bow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 90;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 25;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // other lesser bows
                case "Dark bow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 95;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 9;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Magic shortbow (i)":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 75;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Magic shortbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 69;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Magic longbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 69;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Webweaver bow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 85;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 65;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Craw's bow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 75;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 60;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // crossbows
                case "Rune crossbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 90;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Dragon crossbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 94;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Dragon hunter crossbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 95;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Armadyl crossbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 100;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 1;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Zaryte crossbow":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 110;
                    stab_def_array[i + 4] = 14;
                    slash_def_array[i + 4] = 14;
                    crush_def_array[i + 4] = 12;
                    magic_def_array[i + 4] = 15;
                    range_def_array[i + 4] = 16;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 1;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 6;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // knives
                case "Dragon knife":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 28;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 30;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // thrownaxes
                case "Dragon thrownaxe":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 36;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 47;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // darts
                case "Dragon darts":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 35;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Amethyst darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 28;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Rune darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 26;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Adamant darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 17;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Mithril darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 9;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Black darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 6;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Steel darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 3;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Iron darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 2;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                case "Bronze darts":
                    stab_atk_array[i + 4] = 0;
                    slash_atk_array[i + 4] = 0;
                    crush_atk_array[i + 4] = 0;
                    magic_atk_array[i + 4] = 0;
                    range_atk_array[i + 4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i + 4] = 0;
                    range_str_array[i + 4] = 1;
                    magic_dmg_array[i + 4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 3;
                    weapon_type_array[k + 0] = "ranged";
                    weapon_stance_array[k + 0] = "accurate";
                    weapon_type_array[k + 1] = "ranged";
                    weapon_stance_array[k + 1] = "rapid";
                    weapon_type_array[k + 2] = "ranged";
                    weapon_stance_array[k + 2] = "longrange";
                    weapon_type_array[k + 3] = "none";
                    weapon_stance_array[k + 3] = "none";
                    break;
                // chins
                case "Black chinchompa":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 80;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 30;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "short fuse";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "medium fuse";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "long fuse";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Red chinchompa":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 70;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 15;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "short fuse";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "medium fuse";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "long fuse";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Grey chinchompa":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 45;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "short fuse";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "medium fuse";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "long fuse";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // ballistas
                case "Heavy ballista":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 125;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 15;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 7;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                case "Light ballista":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 110;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = true;
                    is_weapon_2h_array[j] = true;
                    weapon_atk_speed_array[j] = 7;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;
                // obby ring
                case "Toktz-xil-ul":
                    stab_atk_array[i+4] = 0;
                    slash_atk_array[i+4] = 0;
                    crush_atk_array[i+4] = 0;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 69;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 0;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 0;
                    range_str_array[i+4] = 49;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 4;
                    weapon_type_array[k+0] = "ranged";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "ranged";
                    weapon_stance_array[k+1] = "rapid";
                    weapon_type_array[k+2] = "ranged";
                    weapon_stance_array[k+2] = "longrange";
                    weapon_type_array[k+3] = "none";
                    weapon_stance_array[k+3] = "none";
                    break;


                // other
                case "Dragon Pickaxe":
                    stab_atk_array[i+4] = 38;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 32;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 1;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 42;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    mining_lvl_req_array[j] = 61; // guardians dmg modifier P cap is 61

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Rune Pickaxe":
                    stab_atk_array[i+4] = 26;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 24;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 1;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 29;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    mining_lvl_req_array[j] = 41;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
                case "Iron Pickaxe":
                    stab_atk_array[i+4] = 5;
                    slash_atk_array[i+4] = -2;
                    crush_atk_array[i+4] = 3;
                    magic_atk_array[i+4] = 0;
                    range_atk_array[i+4] = 0;
                    stab_def_array[i + 4] = 0;
                    slash_def_array[i + 4] = 1;
                    crush_def_array[i + 4] = 0;
                    magic_def_array[i + 4] = 0;
                    range_def_array[i + 4] = 0;
                    melee_str_array[i+4] = 7;
                    range_str_array[i+4] = 0;
                    magic_dmg_array[i+4] = 0;
                    prayer_bonus_array[i + 4] = 0;

                    mining_lvl_req_array[j] = 1;

                    has_special_attack_array[j] = false;
                    is_weapon_2h_array[j] = false;
                    weapon_atk_speed_array[j] = 5;
                    weapon_type_array[k+0] = "stab";
                    weapon_stance_array[k+0] = "accurate";
                    weapon_type_array[k+1] = "stab";
                    weapon_stance_array[k+1] = "aggressive";
                    weapon_type_array[k+2] = "crush";
                    weapon_stance_array[k+2] = "aggressive";
                    weapon_type_array[k+3] = "stab";
                    weapon_stance_array[k+3] = "defensive";
                    break;
            }

            gear_set_2 = false;

        }
        private void weapon_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(weapon_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                weapon_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(weapon_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void weapon_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(weapon_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                weapon_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(weapon_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_weapon(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(weapon_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                weapon_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(weapon_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_weapon(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(weapon_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                weapon_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(weapon_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------BODY----------------
        private void body_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (body_name_array[j])
            {
                default:
                    MessageBox.Show("Body not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = 0;
                    range_atk_array[i+5] = 0;
                    stab_def_array[i + 5] = 0;
                    slash_def_array[i + 5] = 0;
                    crush_def_array[i + 5] = 0;
                    magic_def_array[i + 5] = 0;
                    range_def_array[i + 5] = 0;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Torva platebody":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = -18;
                    range_atk_array[i+5] = -14;
                    stab_def_array[i + 5] = 117;
                    slash_def_array[i + 5] = 111;
                    crush_def_array[i + 5] = 117;
                    magic_def_array[i + 5] = -11;
                    range_def_array[i + 5] = 142;
                    melee_str_array[i+5] = 6;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 1;
                    break;
                case "Bandos chestplate":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = -15;
                    range_atk_array[i+5] = -10;
                    stab_def_array[i + 5] = 98;
                    slash_def_array[i + 5] = 93;
                    crush_def_array[i + 5] = 105;
                    magic_def_array[i + 5] = -6;
                    range_def_array[i + 5] = 133;
                    melee_str_array[i+5] = 4;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 1;
                    break;
                case "Inquisitor's hauberk":
                    stab_atk_array[i+5] = -3;
                    slash_atk_array[i+5] = -3;
                    crush_atk_array[i+5] = 12;
                    magic_atk_array[i+5] = -11;
                    range_atk_array[i+5] = -10;
                    stab_def_array[i + 5] = 67;
                    slash_def_array[i + 5] = 55;
                    crush_def_array[i + 5] = 71;
                    magic_def_array[i + 5] = 0;
                    range_def_array[i + 5] = 35;
                    melee_str_array[i+5] = 4;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 2;
                    break;
                case "Fighter torso":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = -40;
                    range_atk_array[i+5] = 0;
                    stab_def_array[i + 5] = 62;
                    slash_def_array[i + 5] = 85;
                    crush_def_array[i + 5] = 62;
                    magic_def_array[i + 5] = -10;
                    range_def_array[i + 5] = 67;
                    melee_str_array[i+5] = 4;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Justiciar chestguard":
                    stab_atk_array[i + 5] = 0;
                    slash_atk_array[i + 5] = 0;
                    crush_atk_array[i + 5] = 0;
                    magic_atk_array[i + 5] = -40;
                    range_atk_array[i + 5] = -20;
                    stab_def_array[i + 5] = 132;
                    slash_def_array[i + 5] = 130;
                    crush_def_array[i + 5] = 117;
                    magic_def_array[i + 5] = -16;
                    range_def_array[i + 5] = 142;
                    melee_str_array[i + 5] = 0;
                    range_str_array[i + 5] = 0;
                    magic_dmg_array[i + 5] = 0;
                    prayer_bonus_array[i + 5] = 4;
                    break;
                case "Ancestral robe top":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = 35;
                    range_atk_array[i+5] = -8;
                    stab_def_array[i + 5] = 42;
                    slash_def_array[i + 5] = 31;
                    crush_def_array[i + 5] = 51;
                    magic_def_array[i + 5] = 28;
                    range_def_array[i + 5] = 0;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 2;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Virtus robe top":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = 35;
                    range_atk_array[i+5] = -11;
                    stab_def_array[i + 5] = 47;
                    slash_def_array[i + 5] = 38;
                    crush_def_array[i + 5] = 56;
                    magic_def_array[i + 5] = 31;
                    range_def_array[i + 5] = 0;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 1;
                    prayer_bonus_array[i + 5] = 2;
                    break;
                case "Ahrim's robetop":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = 30;
                    range_atk_array[i+5] = -10;
                    stab_def_array[i + 5] = 52;
                    slash_def_array[i + 5] = 37;
                    crush_def_array[i + 5] = 63;
                    magic_def_array[i + 5] = 30;
                    range_def_array[i + 5] = 0;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Masori body (f)":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = -4;
                    range_atk_array[i+5] = 43;
                    stab_def_array[i + 5] = 59;
                    slash_def_array[i + 5] = 52;
                    crush_def_array[i + 5] = 64;
                    magic_def_array[i + 5] = 74;
                    range_def_array[i + 5] = 60;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 4;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 1;
                    break;
                case "Armadyl chestplate":
                    stab_atk_array[i+5] = -7;
                    slash_atk_array[i+5] = -7;
                    crush_atk_array[i+5] = -7;
                    magic_atk_array[i+5] = -15;
                    range_atk_array[i+5] = 33;
                    stab_def_array[i + 5] = 56;
                    slash_def_array[i + 5] = 48;
                    crush_def_array[i + 5] = 61;
                    magic_def_array[i + 5] = 70;
                    range_def_array[i + 5] = 57;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 1;
                    break;
                case "Crystal body":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = -18;
                    range_atk_array[i+5] = 31;
                    stab_def_array[i + 5] = 46;
                    slash_def_array[i + 5] = 38;
                    crush_def_array[i + 5] = 48;
                    magic_def_array[i + 5] = 44;
                    range_def_array[i + 5] = 68;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 3;
                    break;
                case "God d'hide body":
                    stab_atk_array[i + 5] = 0;
                    slash_atk_array[i + 5] = 0;
                    crush_atk_array[i + 5] = 0;
                    magic_atk_array[i + 5] = -15;
                    range_atk_array[i + 5] = 30;
                    stab_def_array[i + 5] = 55;
                    slash_def_array[i + 5] = 47;
                    crush_def_array[i + 5] = 60;
                    magic_def_array[i + 5] = 50;
                    range_def_array[i + 5] = 55;
                    melee_str_array[i + 5] = 0;
                    range_str_array[i + 5] = 0;
                    magic_dmg_array[i + 5] = 0;
                    prayer_bonus_array[i + 5] = 1;
                    break;
                case "Black d'hide body":
                    stab_atk_array[i + 5] = 0;
                    slash_atk_array[i + 5] = 0;
                    crush_atk_array[i + 5] = 0;
                    magic_atk_array[i + 5] = -15;
                    range_atk_array[i + 5] = 30;
                    stab_def_array[i + 5] = 30;
                    slash_def_array[i + 5] = 38;
                    crush_def_array[i + 5] = 45;
                    magic_def_array[i + 5] = 45;
                    range_def_array[i + 5] = 50;
                    melee_str_array[i + 5] = 0;
                    range_str_array[i + 5] = 0;
                    magic_dmg_array[i + 5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Red d'hide body":
                    stab_atk_array[i + 5] = 0;
                    slash_atk_array[i + 5] = 0;
                    crush_atk_array[i + 5] = 0;
                    magic_atk_array[i + 5] = -15;
                    range_atk_array[i + 5] = 25;
                    stab_def_array[i + 5] = 26;
                    slash_def_array[i + 5] = 34;
                    crush_def_array[i + 5] = 36;
                    magic_def_array[i + 5] = 36;
                    range_def_array[i + 5] = 45;
                    melee_str_array[i + 5] = 0;
                    range_str_array[i + 5] = 0;
                    magic_dmg_array[i + 5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Blue d'hide body":
                    stab_atk_array[i + 5] = 0;
                    slash_atk_array[i + 5] = 0;
                    crush_atk_array[i + 5] = 0;
                    magic_atk_array[i + 5] = -15;
                    range_atk_array[i + 5] = 20;
                    stab_def_array[i + 5] = 23;
                    slash_def_array[i + 5] = 30;
                    crush_def_array[i + 5] = 30;
                    magic_def_array[i + 5] = 26;
                    range_def_array[i + 5] = 40;
                    melee_str_array[i + 5] = 0;
                    range_str_array[i + 5] = 0;
                    magic_dmg_array[i + 5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Green d'hide body":
                    stab_atk_array[i + 5] = 0;
                    slash_atk_array[i + 5] = 0;
                    crush_atk_array[i + 5] = 0;
                    magic_atk_array[i + 5] = -15;
                    range_atk_array[i + 5] = 15;
                    stab_def_array[i + 5] = 18;
                    slash_def_array[i + 5] = 27;
                    crush_def_array[i + 5] = 24;
                    magic_def_array[i + 5] = 20;
                    range_def_array[i + 5] = 35;
                    melee_str_array[i + 5] = 0;
                    range_str_array[i + 5] = 0;
                    magic_dmg_array[i + 5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
                case "Elite void top":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = 0;
                    range_atk_array[i+5] = 0;
                    stab_def_array[i + 5] = 45;
                    slash_def_array[i + 5] = 45;
                    crush_def_array[i + 5] = 45;
                    magic_def_array[i + 5] = 45;
                    range_def_array[i + 5] = 45;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 3;
                    break;
                case "Void top":
                    stab_atk_array[i+5] = 0;
                    slash_atk_array[i+5] = 0;
                    crush_atk_array[i+5] = 0;
                    magic_atk_array[i+5] = 0;
                    range_atk_array[i+5] = 0;
                    stab_def_array[i + 5] = 45;
                    slash_def_array[i + 5] = 45;
                    crush_def_array[i + 5] = 45;
                    magic_def_array[i + 5] = 45;
                    range_def_array[i + 5] = 45;
                    melee_str_array[i+5] = 0;
                    range_str_array[i+5] = 0;
                    magic_dmg_array[i+5] = 0;
                    prayer_bonus_array[i + 5] = 0;
                    break;
            }

            gear_set_2 = false;
        }
        private void body_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(body_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                body_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(body_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void body_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(body_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                body_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(body_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_body(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(body_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                body_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(body_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_body(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(body_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                body_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(body_gear);
                Dispatcher.Invoke(Stats);
            }
        }

        //----------------OFF HAND----------------
        private void off_hand_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (off_hand_name_array[j])
            {
                default:
                    MessageBox.Show("Off hand not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+6] = 0;
                    slash_atk_array[i+6] = 0;
                    crush_atk_array[i+6] = 0;
                    magic_atk_array[i+6] = 0;
                    range_atk_array[i+6] = 0;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i+6] = 0;
                    range_str_array[i+6] = 0;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Avernic defender":
                    stab_atk_array[i+6] = 30;
                    slash_atk_array[i+6] = 29;
                    crush_atk_array[i+6] = 28;
                    magic_atk_array[i+6] = -5;
                    range_atk_array[i+6] = -4;
                    stab_def_array[i + 6] = 30;
                    slash_def_array[i + 6] = 29;
                    crush_def_array[i + 6] = 28;
                    magic_def_array[i + 6] = -5;
                    range_def_array[i + 6] = -4;
                    melee_str_array[i+6] = 8;
                    range_str_array[i+6] = 0;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Dragon defender":
                    stab_atk_array[i+6] = 25;
                    slash_atk_array[i+6] = 24;
                    crush_atk_array[i+6] = 23;
                    magic_atk_array[i+6] = -3;
                    range_atk_array[i+6] = -2;
                    stab_def_array[i + 6] = 25;
                    slash_def_array[i + 6] = 24;
                    crush_def_array[i + 6] = 23;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i+6] = 6;
                    range_str_array[i+6] = 0;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Dragonfire shield":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = -5;
                    stab_def_array[i + 6] = 70;
                    slash_def_array[i + 6] = 75;
                    crush_def_array[i + 6] = 72;
                    magic_def_array[i + 6] = 10;
                    range_def_array[i + 6] = 72;
                    melee_str_array[i + 6] = 7;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Rune defender":
                    stab_atk_array[i + 6] = 20;
                    slash_atk_array[i + 6] = 19;
                    crush_atk_array[i + 6] = 18;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 20;
                    slash_def_array[i + 6] = 19;
                    crush_def_array[i + 6] = 18;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 5;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Toktz-ket-xil":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = -12;
                    range_atk_array[i + 6] = -8;
                    stab_def_array[i + 6] = 40;
                    slash_def_array[i + 6] = 42;
                    crush_def_array[i + 6] = 38;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 65;
                    melee_str_array[i + 6] = 5;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Adamant defender":
                    stab_atk_array[i + 6] = 13;
                    slash_atk_array[i + 6] = 12;
                    crush_atk_array[i + 6] = 11;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 13;
                    slash_def_array[i + 6] = 12;
                    crush_def_array[i + 6] = 11;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 4;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Mithril defender":
                    stab_atk_array[i + 6] = 10;
                    slash_atk_array[i + 6] = 9;
                    crush_atk_array[i + 6] = 8;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 10;
                    slash_def_array[i + 6] = 9;
                    crush_def_array[i + 6] = 8;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 3;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Black defender":
                    stab_atk_array[i + 6] = 9;
                    slash_atk_array[i + 6] = 8;
                    crush_atk_array[i + 6] = 7;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 9;
                    slash_def_array[i + 6] = 8;
                    crush_def_array[i + 6] = 7;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 2;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Book of war":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = 0;
                    range_atk_array[i + 6] = 0;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 2;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 5;
                    break;
                case "Steel defender":
                    stab_atk_array[i + 6] = 7;
                    slash_atk_array[i + 6] = 6;
                    crush_atk_array[i + 6] = 5;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 7;
                    slash_def_array[i + 6] = 6;
                    crush_def_array[i + 6] = 5;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 1;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Iron defender":
                    stab_atk_array[i + 6] = 5;
                    slash_atk_array[i + 6] = 4;
                    crush_atk_array[i + 6] = 3;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 5;
                    slash_def_array[i + 6] = 4;
                    crush_def_array[i + 6] = 3;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Bronze defender":
                    stab_atk_array[i + 6] = 3;
                    slash_atk_array[i + 6] = 2;
                    crush_atk_array[i + 6] = 1;
                    magic_atk_array[i + 6] = -3;
                    range_atk_array[i + 6] = -2;
                    stab_def_array[i + 6] = 3;
                    slash_def_array[i + 6] = 2;
                    crush_def_array[i + 6] = 1;
                    magic_def_array[i + 6] = -3;
                    range_def_array[i + 6] = -2;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Elidinis' ward (f)":
                    stab_atk_array[i+6] = 0;
                    slash_atk_array[i+6] = 0;
                    crush_atk_array[i+6] = 0;
                    magic_atk_array[i+6] = 25;
                    range_atk_array[i+6] = 0;
                    stab_def_array[i + 6] = 53;
                    slash_def_array[i + 6] = 55;
                    crush_def_array[i + 6] = 73;
                    magic_def_array[i + 6] = 2;
                    range_def_array[i + 6] = 52;
                    melee_str_array[i+6] = 0;
                    range_str_array[i+6] = 0;
                    magic_dmg_array[i+6] = 5;
                    prayer_bonus_array[i + 6] = 4;
                    break;
                case "Elidinis' ward":
                    stab_atk_array[i+6] = 0;
                    slash_atk_array[i+6] = 0;
                    crush_atk_array[i+6] = 0;
                    magic_atk_array[i+6] = 5;
                    range_atk_array[i+6] = 0;
                    stab_def_array[i + 6] = 5;
                    slash_def_array[i + 6] = 3;
                    crush_def_array[i + 6] = 9;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 6;
                    melee_str_array[i+6] = 0;
                    range_str_array[i+6] = 0;
                    magic_dmg_array[i+6] = 3;
                    prayer_bonus_array[i + 6] = 1;
                    break;
                case "Arcane spirit shield":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = 20;
                    range_atk_array[i + 6] = 0;
                    stab_def_array[i + 6] = 53;
                    slash_def_array[i + 6] = 55;
                    crush_def_array[i + 6] = 73;
                    magic_def_array[i + 6] = 2;
                    range_def_array[i + 6] = 52;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 3;
                    break;
                case "Mage's book":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = 15;
                    range_atk_array[i + 6] = 0;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 15;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Ancient wyvern shield":
                    stab_atk_array[i + 6] = -10;
                    slash_atk_array[i + 6] = -10;
                    crush_atk_array[i + 6] = -10;
                    magic_atk_array[i + 6] = 15;
                    range_atk_array[i + 6] = -10;
                    stab_def_array[i + 6] = 72;
                    slash_def_array[i + 6] = 80;
                    crush_def_array[i + 6] = 75;
                    magic_def_array[i + 6] = 15;
                    range_def_array[i + 6] = -5;
                    melee_str_array[i + 6] = -2;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Malediction ward":
                    stab_atk_array[i + 6] = -8;
                    slash_atk_array[i + 6] = -8;
                    crush_atk_array[i + 6] = -8;
                    magic_atk_array[i + 6] = 12;
                    range_atk_array[i + 6] = -12;
                    stab_def_array[i + 6] = 50;
                    slash_def_array[i + 6] = 52;
                    crush_def_array[i + 6] = 48;
                    magic_def_array[i + 6] = 15;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Book of darkness":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = 10;
                    range_atk_array[i + 6] = 0;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 5;
                    break;
                case "Tome of water":
                case "Tome of fire":
                    stab_atk_array[i+6] = 0;
                    slash_atk_array[i+6] = 0;
                    crush_atk_array[i+6] = 0;
                    magic_atk_array[i+6] = 8;
                    range_atk_array[i+6] = 0;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 8;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i+6] = 0;
                    range_str_array[i+6] = 0;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Book of the dead":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = 6;
                    range_atk_array[i + 6] = 0;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 3;
                    break;
                case "Twisted buckler":
                    stab_atk_array[i+6] = -7;
                    slash_atk_array[i+6] = -8;
                    crush_atk_array[i+6] = -9;
                    magic_atk_array[i+6] = -10;
                    range_atk_array[i+6] = 18;
                    stab_def_array[i + 6] = 22;
                    slash_def_array[i + 6] = 24;
                    crush_def_array[i + 6] = 22;
                    magic_def_array[i + 6] = 26;
                    range_def_array[i + 6] = 58;
                    melee_str_array[i+6] = 0;
                    range_str_array[i+6] = 10;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Dragonfire ward":
                    stab_atk_array[i+6] = -10;
                    slash_atk_array[i+6] = -10;
                    crush_atk_array[i+6] = -10;
                    magic_atk_array[i+6] = -10;
                    range_atk_array[i+6] = 15;
                    stab_def_array[i + 6] = 25;
                    slash_def_array[i + 6] = 30;
                    crush_def_array[i + 6] = 28;
                    magic_def_array[i + 6] = 28;
                    range_def_array[i + 6] = 68;
                    melee_str_array[i+6] = -2;
                    range_str_array[i+6] = 8;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Odium ward":
                    stab_atk_array[i+6] = -12;
                    slash_atk_array[i+6] = -12;
                    crush_atk_array[i+6] = -12;
                    magic_atk_array[i+6] = -8;
                    range_atk_array[i+6] = 12;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 24;
                    range_def_array[i + 6] = 52;
                    melee_str_array[i+6] = 0;
                    range_str_array[i+6] = 4;
                    magic_dmg_array[i+6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Book of law":
                    stab_atk_array[i + 6] = 0;
                    slash_atk_array[i + 6] = 0;
                    crush_atk_array[i + 6] = 0;
                    magic_atk_array[i + 6] = 0;
                    range_atk_array[i + 6] = 10;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 5;
                    break;
                case "Unholy book":
                    stab_atk_array[i + 6] = 8;
                    slash_atk_array[i + 6] = 8;
                    crush_atk_array[i + 6] = 8;
                    magic_atk_array[i + 6] = 8;
                    range_atk_array[i + 6] = 8;
                    stab_def_array[i + 6] = 0;
                    slash_def_array[i + 6] = 0;
                    crush_def_array[i + 6] = 0;
                    magic_def_array[i + 6] = 0;
                    range_def_array[i + 6] = 0;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 5;
                    break;
                case "God d'hide shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 7;
                    stab_def_array[i + 6] = 21;
                    slash_def_array[i + 6] = 18;
                    crush_def_array[i + 6] = 16;
                    magic_def_array[i + 6] = 15;
                    range_def_array[i + 6] = 14;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 1;
                    break;
                case "Black d'hide shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 7;
                    stab_def_array[i + 6] = 21;
                    slash_def_array[i + 6] = 18;
                    crush_def_array[i + 6] = 16;
                    magic_def_array[i + 6] = 15;
                    range_def_array[i + 6] = 14;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Red d'hide shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 6;
                    stab_def_array[i + 6] = 18;
                    slash_def_array[i + 6] = 16;
                    crush_def_array[i + 6] = 14;
                    magic_def_array[i + 6] = 13;
                    range_def_array[i + 6] = 13;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Blue d'hide shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 5;
                    stab_def_array[i + 6] = 16;
                    slash_def_array[i + 6] = 14;
                    crush_def_array[i + 6] = 12;
                    magic_def_array[i + 6] = 12;
                    range_def_array[i + 6] = 12;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Book of balance":
                    stab_atk_array[i + 6] = 4;
                    slash_atk_array[i + 6] = 4;
                    crush_atk_array[i + 6] = 4;
                    magic_atk_array[i + 6] = 4;
                    range_atk_array[i + 6] = 4;
                    stab_def_array[i + 6] = 4;
                    slash_def_array[i + 6] = 4;
                    crush_def_array[i + 6] = 4;
                    magic_def_array[i + 6] = 4;
                    range_def_array[i + 6] = 4;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 5;
                    break;
                case "Green d'hide shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 4;
                    stab_def_array[i + 6] = 14;
                    slash_def_array[i + 6] = 12;
                    crush_def_array[i + 6] = 11;
                    magic_def_array[i + 6] = 9;
                    range_def_array[i + 6] = 11;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Snakeskin shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 3;
                    stab_def_array[i + 6] = 10;
                    slash_def_array[i + 6] = 9;
                    crush_def_array[i + 6] = 8;
                    magic_def_array[i + 6] = 7;
                    range_def_array[i + 6] = 10;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
                case "Hard leather shield":
                    stab_atk_array[i + 6] = -15;
                    slash_atk_array[i + 6] = -15;
                    crush_atk_array[i + 6] = -11;
                    magic_atk_array[i + 6] = -10;
                    range_atk_array[i + 6] = 2;
                    stab_def_array[i + 6] = 8;
                    slash_def_array[i + 6] = 7;
                    crush_def_array[i + 6] = 7;
                    magic_def_array[i + 6] = 5;
                    range_def_array[i + 6] = 9;
                    melee_str_array[i + 6] = 0;
                    range_str_array[i + 6] = 0;
                    magic_dmg_array[i + 6] = 0;
                    prayer_bonus_array[i + 6] = 0;
                    break;
            }

            gear_set_2 = false;
        }
        private void off_hand_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(off_hand_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                off_hand_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(off_hand_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void off_hand_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(off_hand_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                off_hand_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(off_hand_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_off_hand(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(off_hand_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                off_hand_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(off_hand_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_off_hand(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(off_hand_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                off_hand_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(off_hand_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------LEGS----------------
        private void legs_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (legs_name_array[j])
            {
                default:
                    MessageBox.Show("Legs not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = 0;
                    range_atk_array[i+7] = 0;
                    stab_def_array[i + 7] = 0;
                    slash_def_array[i + 7] = 0;
                    crush_def_array[i + 7] = 0;
                    magic_def_array[i + 7] = 0;
                    range_def_array[i + 7] = 0;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Torva platelegs":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = -24;
                    range_atk_array[i+7] = -11;
                    stab_def_array[i + 7] = 87;
                    slash_def_array[i + 7] = 78;
                    crush_def_array[i + 7] = 79;
                    magic_def_array[i + 7] = -9;
                    range_def_array[i + 7] = 102;
                    melee_str_array[i+7] = 4;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 1;
                    break;
                case "Bandos tassets":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = -21;
                    range_atk_array[i+7] = -7;
                    stab_def_array[i + 7] = 71;
                    slash_def_array[i + 7] = 63;
                    crush_def_array[i + 7] = 66;
                    magic_def_array[i + 7] = -4;
                    range_def_array[i + 7] = 93;
                    melee_str_array[i+7] = 2;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 1;
                    break;
                case "Inquisitor's plateskirt":
                    stab_atk_array[i+7] = -3;
                    slash_atk_array[i+7] = -2;
                    crush_atk_array[i+7] = 12;
                    magic_atk_array[i+7] = -9;
                    range_atk_array[i+7] = -5;
                    stab_def_array[i + 7] = 42;
                    slash_def_array[i + 7] = 30;
                    crush_def_array[i + 7] = 49;
                    magic_def_array[i + 7] = 0;
                    range_def_array[i + 7] = 22;
                    melee_str_array[i+7] = 2;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 2;
                    break;
                case "Justiciar legguards":
                    stab_atk_array[i + 7] = 0;
                    slash_atk_array[i + 7] = 0;
                    crush_atk_array[i + 7] = 0;
                    magic_atk_array[i + 7] = -31;
                    range_atk_array[i + 7] = -17;
                    stab_def_array[i + 7] = 95;
                    slash_def_array[i + 7] = 92;
                    crush_def_array[i + 7] = 93;
                    magic_def_array[i + 7] = -14;
                    range_def_array[i + 7] = 102;
                    melee_str_array[i + 7] = 0;
                    range_str_array[i + 7] = 0;
                    magic_dmg_array[i + 7] = 0;
                    prayer_bonus_array[i + 7] = 4;
                    break;
                case "Ancestral robe bottom":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = 26;
                    range_atk_array[i+7] = -7;
                    stab_def_array[i + 7] = 27;
                    slash_def_array[i + 7] = 24;
                    crush_def_array[i + 7] = 30;
                    magic_def_array[i + 7] = 20;
                    range_def_array[i + 7] = 0;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 2;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Virtus robe bottom":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = 26;
                    range_atk_array[i+7] = -9;
                    stab_def_array[i + 7] = 31;
                    slash_def_array[i + 7] = 28;
                    crush_def_array[i + 7] = 34;
                    magic_def_array[i + 7] = 22;
                    range_def_array[i + 7] = 0;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 1;
                    prayer_bonus_array[i + 7] = 1;
                    break;
                case "Ahrim's robeskirt":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = 22;
                    range_atk_array[i+7] = -7;
                    stab_def_array[i + 7] = 33;
                    slash_def_array[i + 7] = 30;
                    crush_def_array[i + 7] = 36;
                    magic_def_array[i + 7] = 22;
                    range_def_array[i + 7] = 0;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Masori chaps (f)":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = -2;
                    range_atk_array[i+7] = 27;
                    stab_def_array[i + 7] = 35;
                    slash_def_array[i + 7] = 30;
                    crush_def_array[i + 7] = 39;
                    magic_def_array[i + 7] = 46;
                    range_def_array[i + 7] = 37;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 2;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 1;
                    break;
                case "Armadyl chainskirt":
                    stab_atk_array[i+7] = -6;
                    slash_atk_array[i+7] = -6;
                    crush_atk_array[i+7] = -6;
                    magic_atk_array[i+7] = -10;
                    range_atk_array[i+7] = 20;
                    stab_def_array[i + 7] = 32;
                    slash_def_array[i + 7] = 26;
                    crush_def_array[i + 7] = 34;
                    magic_def_array[i + 7] = 40;
                    range_def_array[i + 7] = 33;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 1;
                    break;
                case "Crystal legs":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = -12;
                    range_atk_array[i+7] = 18;
                    stab_def_array[i + 7] = 26;
                    slash_def_array[i + 7] = 21;
                    crush_def_array[i + 7] = 30;
                    magic_def_array[i + 7] = 34;
                    range_def_array[i + 7] = 38;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 2;
                    break;
                case "God d'hide chaps":
                    stab_atk_array[i + 7] = 0;
                    slash_atk_array[i + 7] = 0;
                    crush_atk_array[i + 7] = 0;
                    magic_atk_array[i + 7] = -10;
                    range_atk_array[i + 7] = 17;
                    stab_def_array[i + 7] = 31;
                    slash_def_array[i + 7] = 25;
                    crush_def_array[i + 7] = 33;
                    magic_def_array[i + 7] = 28;
                    range_def_array[i + 7] = 31;
                    melee_str_array[i + 7] = 0;
                    range_str_array[i + 7] = 0;
                    magic_dmg_array[i + 7] = 0;
                    prayer_bonus_array[i + 7] = 1;
                    break;
                case "Black d'hide chaps":
                    stab_atk_array[i + 7] = 0;
                    slash_atk_array[i + 7] = 0;
                    crush_atk_array[i + 7] = 0;
                    magic_atk_array[i + 7] = -10;
                    range_atk_array[i + 7] = 17;
                    stab_def_array[i + 7] = 18;
                    slash_def_array[i + 7] = 20;
                    crush_def_array[i + 7] = 26;
                    magic_def_array[i + 7] = 23;
                    range_def_array[i + 7] = 26;
                    melee_str_array[i + 7] = 0;
                    range_str_array[i + 7] = 0;
                    magic_dmg_array[i + 7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Red d'hide chaps":
                    stab_atk_array[i + 7] = 0;
                    slash_atk_array[i + 7] = 0;
                    crush_atk_array[i + 7] = 0;
                    magic_atk_array[i + 7] = -10;
                    range_atk_array[i + 7] = 14;
                    stab_def_array[i + 7] = 15;
                    slash_def_array[i + 7] = 18;
                    crush_def_array[i + 7] = 22;
                    magic_def_array[i + 7] = 18;
                    range_def_array[i + 7] = 20;
                    melee_str_array[i + 7] = 0;
                    range_str_array[i + 7] = 0;
                    magic_dmg_array[i + 7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Blue d'hide chaps":
                    stab_atk_array[i + 7] = 0;
                    slash_atk_array[i + 7] = 0;
                    crush_atk_array[i + 7] = 0;
                    magic_atk_array[i + 7] = -10;
                    range_atk_array[i + 7] = 11;
                    stab_def_array[i + 7] = 13;
                    slash_def_array[i + 7] = 16;
                    crush_def_array[i + 7] = 20;
                    magic_def_array[i + 7] = 14;
                    range_def_array[i + 7] = 20;
                    melee_str_array[i + 7] = 0;
                    range_str_array[i + 7] = 0;
                    magic_dmg_array[i + 7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Green d'hide chaps":
                    stab_atk_array[i + 7] = 0;
                    slash_atk_array[i + 7] = 0;
                    crush_atk_array[i + 7] = 0;
                    magic_atk_array[i + 7] = -10;
                    range_atk_array[i + 7] = 8;
                    stab_def_array[i + 7] = 12;
                    slash_def_array[i + 7] = 15;
                    crush_def_array[i + 7] = 18;
                    magic_def_array[i + 7] = 8;
                    range_def_array[i + 7] = 17;
                    melee_str_array[i + 7] = 0;
                    range_str_array[i + 7] = 0;
                    magic_dmg_array[i + 7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
                case "Elite void robe":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = 0;
                    range_atk_array[i+7] = 0;
                    stab_def_array[i + 7] = 30;
                    slash_def_array[i + 7] = 30;
                    crush_def_array[i + 7] = 30;
                    magic_def_array[i + 7] = 30;
                    range_def_array[i + 7] = 30;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 3;
                    break;
                case "Void robe":
                    stab_atk_array[i+7] = 0;
                    slash_atk_array[i+7] = 0;
                    crush_atk_array[i+7] = 0;
                    magic_atk_array[i+7] = 0;
                    range_atk_array[i+7] = 0;
                    stab_def_array[i + 7] = 30;
                    slash_def_array[i + 7] = 30;
                    crush_def_array[i + 7] = 30;
                    magic_def_array[i + 7] = 30;
                    range_def_array[i + 7] = 30;
                    melee_str_array[i+7] = 0;
                    range_str_array[i+7] = 0;
                    magic_dmg_array[i+7] = 0;
                    prayer_bonus_array[i + 7] = 0;
                    break;
            }

            gear_set_2 = false;
        }
        private void legs_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(legs_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                legs_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(legs_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void legs_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(legs_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                legs_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(legs_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_legs(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(legs_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                legs_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(legs_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_legs(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(legs_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                legs_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(legs_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------GLOVES----------------
        private void gloves_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (gloves_name_array[j])
            {
                default:
                    MessageBox.Show("Gloves not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+8] = 0;
                    slash_atk_array[i+8] = 0;
                    crush_atk_array[i+8] = 0;
                    magic_atk_array[i+8] = 0;
                    range_atk_array[i+8] = 0;
                    stab_def_array[i + 8] = 0;
                    slash_def_array[i + 8] = 0;
                    crush_def_array[i + 8] = 0;
                    magic_def_array[i + 8] = 0;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i+8] = 0;
                    range_str_array[i+8] = 0;
                    magic_dmg_array[i+8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Ferocious gloves":
                    stab_atk_array[i+8] = 16;
                    slash_atk_array[i+8] = 16;
                    crush_atk_array[i+8] = 16;
                    magic_atk_array[i+8] = -16;
                    range_atk_array[i+8] = -16;
                    stab_def_array[i + 8] = 0;
                    slash_def_array[i + 8] = 0;
                    crush_def_array[i + 8] = 0;
                    magic_def_array[i + 8] = 0;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i+8] = 14;
                    range_str_array[i+8] = 0;
                    magic_dmg_array[i+8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Barrows gloves":
                    stab_atk_array[i + 8] = 12;
                    slash_atk_array[i + 8] = 12;
                    crush_atk_array[i + 8] = 12;
                    magic_atk_array[i + 8] = 6;
                    range_atk_array[i + 8] = 12;
                    stab_def_array[i + 8] = 12;
                    slash_def_array[i + 8] = 12;
                    crush_def_array[i + 8] = 12;
                    magic_def_array[i + 8] = 6;
                    range_def_array[i + 8] = 12;
                    melee_str_array[i + 8] = 12;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Dragon gloves":
                    stab_atk_array[i + 8] = 9;
                    slash_atk_array[i + 8] = 9;
                    crush_atk_array[i + 8] = 9;
                    magic_atk_array[i + 8] = 5;
                    range_atk_array[i + 8] = 9;
                    stab_def_array[i + 8] = 9;
                    slash_def_array[i + 8] = 9;
                    crush_def_array[i + 8] = 9;
                    magic_def_array[i + 8] = 5;
                    range_def_array[i + 8] = 9;
                    melee_str_array[i + 8] = 9;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Rune gloves":
                    stab_atk_array[i + 8] = 8;
                    slash_atk_array[i + 8] = 8;
                    crush_atk_array[i + 8] = 8;
                    magic_atk_array[i + 8] = 4;
                    range_atk_array[i + 8] = 8;
                    stab_def_array[i + 8] = 8;
                    slash_def_array[i + 8] = 8;
                    crush_def_array[i + 8] = 8;
                    magic_def_array[i + 8] = 4;
                    range_def_array[i + 8] = 8;
                    melee_str_array[i + 8] = 8;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Regen bracelet":
                    stab_atk_array[i + 8] = 8;
                    slash_atk_array[i + 8] = 8;
                    crush_atk_array[i + 8] = 8;
                    magic_atk_array[i + 8] = 3;
                    range_atk_array[i + 8] = 7;
                    stab_def_array[i + 8] = 6;
                    slash_def_array[i + 8] = 6;
                    crush_def_array[i + 8] = 6;
                    magic_def_array[i + 8] = 3;
                    range_def_array[i + 8] = 6;
                    melee_str_array[i + 8] = 7;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Adamant gloves":
                    stab_atk_array[i + 8] = 7;
                    slash_atk_array[i + 8] = 7;
                    crush_atk_array[i + 8] = 7;
                    magic_atk_array[i + 8] = 4;
                    range_atk_array[i + 8] = 7;
                    stab_def_array[i + 8] = 7;
                    slash_def_array[i + 8] = 7;
                    crush_def_array[i + 8] = 7;
                    magic_def_array[i + 8] = 4;
                    range_def_array[i + 8] = 7;
                    melee_str_array[i + 8] = 7;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Granite gloves":
                    stab_atk_array[i + 8] = 5;
                    slash_atk_array[i + 8] = 5;
                    crush_atk_array[i + 8] = 9;
                    magic_atk_array[i + 8] = -3;
                    range_atk_array[i + 8] = -1;
                    stab_def_array[i + 8] = 8;
                    slash_def_array[i + 8] = 8;
                    crush_def_array[i + 8] = 8;
                    magic_def_array[i + 8] = -3;
                    range_def_array[i + 8] = 5;
                    melee_str_array[i + 8] = 7;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Combat bracelet":
                    stab_atk_array[i + 8] = 7;
                    slash_atk_array[i + 8] = 7;
                    crush_atk_array[i + 8] = 7;
                    magic_atk_array[i + 8] = 3;
                    range_atk_array[i + 8] = 7;
                    stab_def_array[i + 8] = 5;
                    slash_def_array[i + 8] = 5;
                    crush_def_array[i + 8] = 5;
                    magic_def_array[i + 8] = 3;
                    range_def_array[i + 8] = 5;
                    melee_str_array[i + 8] = 6;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Mithril gloves":
                    stab_atk_array[i + 8] = 6;
                    slash_atk_array[i + 8] = 6;
                    crush_atk_array[i + 8] = 6;
                    magic_atk_array[i + 8] = 3;
                    range_atk_array[i + 8] = 6;
                    stab_def_array[i + 8] = 6;
                    slash_def_array[i + 8] = 6;
                    crush_def_array[i + 8] = 6;
                    magic_def_array[i + 8] = 3;
                    range_def_array[i + 8] = 6;
                    melee_str_array[i + 8] = 6;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Black gloves":
                    stab_atk_array[i + 8] = 5;
                    slash_atk_array[i + 8] = 5;
                    crush_atk_array[i + 8] = 5;
                    magic_atk_array[i + 8] = 3;
                    range_atk_array[i + 8] = 5;
                    stab_def_array[i + 8] = 5;
                    slash_def_array[i + 8] = 5;
                    crush_def_array[i + 8] = 5;
                    magic_def_array[i + 8] = 3;
                    range_def_array[i + 8] = 5;
                    melee_str_array[i + 8] = 5;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Dragonstone gauntlets":
                    stab_atk_array[i + 8] = 8;
                    slash_atk_array[i + 8] = 8;
                    crush_atk_array[i + 8] = 8;
                    magic_atk_array[i + 8] = -4;
                    range_atk_array[i + 8] = -3;
                    stab_def_array[i + 8] = 8;
                    slash_def_array[i + 8] = 8;
                    crush_def_array[i + 8] = 8;
                    magic_def_array[i + 8] = -4;
                    range_def_array[i + 8] = 4;
                    melee_str_array[i + 8] = 4;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Steel gloves":
                    stab_atk_array[i + 8] = 4;
                    slash_atk_array[i + 8] = 4;
                    crush_atk_array[i + 8] = 4;
                    magic_atk_array[i + 8] = 2;
                    range_atk_array[i + 8] = 4;
                    stab_def_array[i + 8] = 4;
                    slash_def_array[i + 8] = 4;
                    crush_def_array[i + 8] = 4;
                    magic_def_array[i + 8] = 2;
                    range_def_array[i + 8] = 4;
                    melee_str_array[i + 8] = 4;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Iron gloves":
                    stab_atk_array[i + 8] = 3;
                    slash_atk_array[i + 8] = 3;
                    crush_atk_array[i + 8] = 3;
                    magic_atk_array[i + 8] = 2;
                    range_atk_array[i + 8] = 3;
                    stab_def_array[i + 8] = 3;
                    slash_def_array[i + 8] = 3;
                    crush_def_array[i + 8] = 3;
                    magic_def_array[i + 8] = 2;
                    range_def_array[i + 8] = 3;
                    melee_str_array[i + 8] = 3;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Bronze gloves":
                    stab_atk_array[i + 8] = 2;
                    slash_atk_array[i + 8] = 2;
                    crush_atk_array[i + 8] = 2;
                    magic_atk_array[i + 8] = 1;
                    range_atk_array[i + 8] = 2;
                    stab_def_array[i + 8] = 2;
                    slash_def_array[i + 8] = 2;
                    crush_def_array[i + 8] = 2;
                    magic_def_array[i + 8] = 1;
                    range_def_array[i + 8] = 2;
                    melee_str_array[i + 8] = 2;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Tormented bracelet":
                    stab_atk_array[i + 8] = 0;
                    slash_atk_array[i + 8] = 0;
                    crush_atk_array[i + 8] = 0;
                    magic_atk_array[i + 8] = 10;
                    range_atk_array[i + 8] = 0;
                    stab_def_array[i + 8] = 0;
                    slash_def_array[i + 8] = 0;
                    crush_def_array[i + 8] = 0;
                    magic_def_array[i + 8] = 0;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i + 8] = 0;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 5;
                    prayer_bonus_array[i + 8] = 2;
                    break;
                case "Zaryte vambraces":
                    stab_atk_array[i+8] = -8;
                    slash_atk_array[i+8] = -8;
                    crush_atk_array[i+8] = -8;
                    magic_atk_array[i+8] = 0;
                    range_atk_array[i+8] = 18;
                    stab_def_array[i + 8] = 8;
                    slash_def_array[i + 8] = 8;
                    crush_def_array[i + 8] = 8;
                    magic_def_array[i + 8] = 5;
                    range_def_array[i + 8] = 8;
                    melee_str_array[i+8] = 0;
                    range_str_array[i+8] = 2;
                    magic_dmg_array[i+8] = 0;
                    prayer_bonus_array[i + 8] = 1;
                    break;
                case "God d'hide bracers":
                    stab_atk_array[i + 8] = 0;
                    slash_atk_array[i + 8] = 0;
                    crush_atk_array[i + 8] = 0;
                    magic_atk_array[i + 8] = -10;
                    range_atk_array[i + 8] = 11;
                    stab_def_array[i + 8] = 6;
                    slash_def_array[i + 8] = 5;
                    crush_def_array[i + 8] = 7;
                    magic_def_array[i + 8] = 8;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i + 8] = 0;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 1;
                    break;
                case "Black d'hide vambraces":
                    stab_atk_array[i + 8] = 0;
                    slash_atk_array[i + 8] = 0;
                    crush_atk_array[i + 8] = 0;
                    magic_atk_array[i + 8] = -10;
                    range_atk_array[i + 8] = 11;
                    stab_def_array[i + 8] = 4;
                    slash_def_array[i + 8] = 5;
                    crush_def_array[i + 8] = 5;
                    magic_def_array[i + 8] = 8;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i + 8] = 0;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Red d'hide vambraces":
                    stab_atk_array[i + 8] = 0;
                    slash_atk_array[i + 8] = 0;
                    crush_atk_array[i + 8] = 0;
                    magic_atk_array[i + 8] = -10;
                    range_atk_array[i + 8] = 10;
                    stab_def_array[i + 8] = 3;
                    slash_def_array[i + 8] = 4;
                    crush_def_array[i + 8] = 4;
                    magic_def_array[i + 8] = 6;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i + 8] = 0;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Blue d'hide vambraces":
                    stab_atk_array[i + 8] = 0;
                    slash_atk_array[i + 8] = 0;
                    crush_atk_array[i + 8] = 0;
                    magic_atk_array[i + 8] = -10;
                    range_atk_array[i + 8] = 9;
                    stab_def_array[i + 8] = 2;
                    slash_def_array[i + 8] = 3;
                    crush_def_array[i + 8] = 3;
                    magic_def_array[i + 8] = 4;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i + 8] = 0;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Green d'hide vambraces":
                    stab_atk_array[i + 8] = 0;
                    slash_atk_array[i + 8] = 0;
                    crush_atk_array[i + 8] = 0;
                    magic_atk_array[i + 8] = -10;
                    range_atk_array[i + 8] = 8;
                    stab_def_array[i + 8] = 1;
                    slash_def_array[i + 8] = 2;
                    crush_def_array[i + 8] = 2;
                    magic_def_array[i + 8] = 2;
                    range_def_array[i + 8] = 0;
                    melee_str_array[i + 8] = 0;
                    range_str_array[i + 8] = 0;
                    magic_dmg_array[i + 8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
                case "Void gloves":
                    stab_atk_array[i+8] = 0;
                    slash_atk_array[i+8] = 0;
                    crush_atk_array[i+8] = 0;
                    magic_atk_array[i+8] = 0;
                    range_atk_array[i+8] = 0;
                    stab_def_array[i + 8] = 6;
                    slash_def_array[i + 8] = 6;
                    crush_def_array[i + 8] = 6;
                    magic_def_array[i + 8] = 4;
                    range_def_array[i + 8] = 6;
                    melee_str_array[i+8] = 0;
                    range_str_array[i+8] = 0;
                    magic_dmg_array[i+8] = 0;
                    prayer_bonus_array[i + 8] = 0;
                    break;
            }

            gear_set_2 = false;
        }
        private void gloves_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(gloves_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                gloves_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gloves_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void gloves_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(gloves_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                gloves_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gloves_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_gloves(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(gloves_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                gloves_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gloves_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_gloves(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(gloves_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                gloves_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gloves_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------BOOTS----------------
        private void boots_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (boots_name_array[j])
            {
                default:
                    MessageBox.Show("Boots not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = 0;
                    range_atk_array[i+9] = 0;
                    stab_def_array[i + 9] = 0;
                    slash_def_array[i + 9] = 0;
                    crush_def_array[i + 9] = 0;
                    magic_def_array[i + 9] = 0;
                    range_def_array[i + 9] = 0;
                    melee_str_array[i+9] = 0;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Primordial boots":
                    stab_atk_array[i+9] = 2;
                    slash_atk_array[i+9] = 2;
                    crush_atk_array[i+9] = 2;
                    magic_atk_array[i+9] = -4;
                    range_atk_array[i+9] = -1;
                    stab_def_array[i + 9] = 22;
                    slash_def_array[i + 9] = 22;
                    crush_def_array[i + 9] = 22;
                    magic_def_array[i + 9] = 0;
                    range_def_array[i + 9] = 0;
                    melee_str_array[i+9] = 5;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Dragon boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = -3;
                    range_atk_array[i+9] = -1;
                    stab_def_array[i + 9] = 16;
                    slash_def_array[i + 9] = 17;
                    crush_def_array[i + 9] = 18;
                    magic_def_array[i + 9] = 0;
                    range_def_array[i + 9] = 0;
                    melee_str_array[i+9] = 4;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Guardian boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = -3;
                    range_atk_array[i+9] = -1;
                    stab_def_array[i + 9] = 32;
                    slash_def_array[i + 9] = 32;
                    crush_def_array[i + 9] = 32;
                    magic_def_array[i + 9] = -3;
                    range_def_array[i + 9] = 24;
                    melee_str_array[i+9] = 3;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 2;
                    break;
                case "Climbing boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = 0;
                    range_atk_array[i+9] = 0;
                    stab_def_array[i + 9] = 0;
                    slash_def_array[i + 9] = 2;
                    crush_def_array[i + 9] = 2;
                    magic_def_array[i + 9] = 0;
                    range_def_array[i + 9] = 0;
                    melee_str_array[i+9] = 2;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Eternal boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = 8;
                    range_atk_array[i+9] = 0;
                    stab_def_array[i + 9] = 5;
                    slash_def_array[i + 9] = 5;
                    crush_def_array[i + 9] = 5;
                    magic_def_array[i + 9] = 8;
                    range_def_array[i + 9] = 5;
                    melee_str_array[i+9] = 0;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Infinity boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = 5;
                    range_atk_array[i+9] = 0;
                    stab_def_array[i + 9] = 0;
                    slash_def_array[i + 9] = 0;
                    crush_def_array[i + 9] = 0;
                    magic_def_array[i + 9] = 5;
                    range_def_array[i + 9] = 0;
                    melee_str_array[i+9] = 0;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Pegasian boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = -12;
                    range_atk_array[i+9] = 12;
                    stab_def_array[i + 9] = 5;
                    slash_def_array[i + 9] = 5;
                    crush_def_array[i + 9] = 5;
                    magic_def_array[i + 9] = 5;
                    range_def_array[i + 9] = 5;
                    melee_str_array[i+9] = 0;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "Ranger boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = -10;
                    range_atk_array[i+9] = 8;
                    stab_def_array[i + 9] = 2;
                    slash_def_array[i + 9] = 3;
                    crush_def_array[i + 9] = 4;
                    magic_def_array[i + 9] = 2;
                    range_def_array[i + 9] = 0;
                    melee_str_array[i+9] = 0;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 0;
                    break;
                case "God d'hide boots":
                    stab_atk_array[i+9] = 0;
                    slash_atk_array[i+9] = 0;
                    crush_atk_array[i+9] = 0;
                    magic_atk_array[i+9] = -10;
                    range_atk_array[i+9] = 7;
                    stab_def_array[i + 9] = 4;
                    slash_def_array[i + 9] = 4;
                    crush_def_array[i + 9] = 4;
                    magic_def_array[i + 9] = 4;
                    range_def_array[i + 9] = 4;
                    melee_str_array[i+9] = 0;
                    range_str_array[i+9] = 0;
                    magic_dmg_array[i+9] = 0;
                    prayer_bonus_array[i + 9] = 1;
                    break;
            }

            gear_set_2 = false;
        }
        private void boots_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(boots_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                boots_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(boots_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void boots_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(boots_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                boots_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(boots_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_boots(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(boots_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                boots_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(boots_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_boots(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(boots_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                boots_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(boots_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------RINGS----------------
        private void ring_gear()
        {
            int i = 0;
            int j = 0;
            if (gear_set_2 == true)
            {
                i = 11;
                j = 1;
            }

            switch (ring_name_array[j])
            {
                default:
                    MessageBox.Show("Ring not found", "Gear name error");
                    break;
                case "None":
                    stab_atk_array[i+10] = 0;
                    slash_atk_array[i+10] = 0;
                    crush_atk_array[i+10] = 0;
                    magic_atk_array[i+10] = 0;
                    range_atk_array[i+10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i+10] = 0;
                    range_str_array[i+10] = 0;
                    magic_dmg_array[i+10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Ultor ring":
                    stab_atk_array[i + 10] = 0;
                    slash_atk_array[i + 10] = 0;
                    crush_atk_array[i + 10] = 0;
                    magic_atk_array[i + 10] = 0;
                    range_atk_array[i + 10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 12;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Bellator ring":
                    stab_atk_array[i + 10] = 0;
                    slash_atk_array[i + 10] = 20;
                    crush_atk_array[i + 10] = 0;
                    magic_atk_array[i + 10] = 0;
                    range_atk_array[i + 10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 6;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Berserker ring (i)":
                    stab_atk_array[i+10] = 0;
                    slash_atk_array[i+10] = 0;
                    crush_atk_array[i+10] = 0;
                    magic_atk_array[i+10] = 0;
                    range_atk_array[i+10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 8;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i+10] = 8;
                    range_str_array[i+10] = 0;
                    magic_dmg_array[i+10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Treasonous ring (i)":
                    stab_atk_array[i + 10] = 8;
                    slash_atk_array[i + 10] = 0;
                    crush_atk_array[i + 10] = 0;
                    magic_atk_array[i + 10] = 0;
                    range_atk_array[i + 10] = 0;
                    stab_def_array[i + 10] = 8;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 0;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Tyrannical ring (i)":
                    stab_atk_array[i + 10] = 0;
                    slash_atk_array[i + 10] = 0;
                    crush_atk_array[i + 10] = 8;
                    magic_atk_array[i + 10] = 0;
                    range_atk_array[i + 10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 8;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 0;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Warrior ring (i)":
                    stab_atk_array[i + 10] = 0;
                    slash_atk_array[i + 10] = 8;
                    crush_atk_array[i + 10] = 0;
                    magic_atk_array[i + 10] = 0;
                    range_atk_array[i + 10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 8;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 0;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Brimstone ring":
                    stab_atk_array[i+10] = 4;
                    slash_atk_array[i+10] = 4;
                    crush_atk_array[i+10] = 4;
                    magic_atk_array[i+10] = 6;
                    range_atk_array[i+10] = 4;
                    stab_def_array[i + 10] = 4;
                    slash_def_array[i + 10] = 4;
                    crush_def_array[i + 10] = 4;
                    magic_def_array[i + 10] = 6;
                    range_def_array[i + 10] = 4;
                    melee_str_array[i+10] = 4;
                    range_str_array[i+10] = 0;
                    magic_dmg_array[i+10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Ring of shadows":
                    stab_atk_array[i + 10] = 4;
                    slash_atk_array[i + 10] = 4;
                    crush_atk_array[i + 10] = 4;
                    magic_atk_array[i + 10] = 5;
                    range_atk_array[i + 10] = 4;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 5;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 2;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 2;
                    break;
                case "Magus ring":
                    stab_atk_array[i + 10] = 0;
                    slash_atk_array[i + 10] = 0;
                    crush_atk_array[i + 10] = 0;
                    magic_atk_array[i + 10] = 15;
                    range_atk_array[i + 10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i + 10] = 0;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 2;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Seers ring (i)":
                    stab_atk_array[i+10] = 0;
                    slash_atk_array[i+10] = 0;
                    crush_atk_array[i+10] = 0;
                    magic_atk_array[i+10] = 12;
                    range_atk_array[i+10] = 0;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 12;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i+10] = 0;
                    range_str_array[i+10] = 0;
                    magic_dmg_array[i+10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Venator ring":
                    stab_atk_array[i+10] = 0;
                    slash_atk_array[i+10] = 0;
                    crush_atk_array[i+10] = 0;
                    magic_atk_array[i+10] = 0;
                    range_atk_array[i+10] = 10;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 0;
                    melee_str_array[i+10] = 0;
                    range_str_array[i+10] = 2;
                    magic_dmg_array[i+10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;
                case "Archer ring (i)":
                    stab_atk_array[i + 10] = 0;
                    slash_atk_array[i + 10] = 0;
                    crush_atk_array[i + 10] = 0;
                    magic_atk_array[i + 10] = 0;
                    range_atk_array[i + 10] = 8;
                    stab_def_array[i + 10] = 0;
                    slash_def_array[i + 10] = 0;
                    crush_def_array[i + 10] = 0;
                    magic_def_array[i + 10] = 0;
                    range_def_array[i + 10] = 8;
                    melee_str_array[i + 10] = 0;
                    range_str_array[i + 10] = 0;
                    magic_dmg_array[i + 10] = 0;
                    prayer_bonus_array[i + 10] = 0;
                    break;

            }

            gear_set_2 = false;
        }
        private void ring_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(ring_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                ring_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ring_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void ring_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(ring_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                ring_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ring_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_ring(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(ring_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                ring_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ring_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_ring(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(ring_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                ring_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(ring_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------SPELLS----------------      
        private void spell_gear()
        {
            int j = 0;
            if (gear_set_2 == true)
            {
                j = 1;
            }
            switch (spell_name_array[j])
            {
                default:
                    MessageBox.Show("Spell not found", "Gear name error");
                    break;
                case "None":
                    spell_book_array[j] = "None";
                    break;
                case "Fire Surge":
                case "Earth Surge":
                case "Water Surge":
                case "Wind Surge":
                case "Fire Wave":
                case "Earth Wave":
                case "Water Wave":
                case "Wind Wave":
                case "Fire Blast":
                case "Earth Blast":
                case "Water Blast":
                case "Wind Blast":
                case "Fire Bolt":
                case "Earth Bolt":
                case "Water Bolt":
                case "Wind Bolt":
                case "Fire Strike":
                case "Earth Strike":
                case "Water Strike":
                case "Wind Strike":
                case "Crumble Undead":
                case "God Spell":
                case "God Spell (charged)":
                case "Iban Blast":
                case "Magic Dart":
                    spell_book_array[j] = "Standard";
                    break;
                case "Vulnerability":
                case "Enfeeble":
                case "Stun":
                case "Curse":
                case "Weaken":
                case "Confuse":
                case "Entangle":
                case "Snare":
                case "Bind":
                case "Tele Block":
                    spell_book_array[j] = "Curse";
                    break;
                case "Ice Barrage":
                case "Blood Barrage":
                case "Shadow Barrage":
                case "Smoke Barrage":
                case "Ice Blitz":
                case "Blood Blitz":
                case "Shadow Blitz":
                case "Smoke Blitz":
                case "Ice Burst":
                case "Blood Burst":
                case "Shadow Burst":
                case "Smoke Burst":
                case "Ice Rush":
                case "Blood Rush":
                case "Shadow Rush":
                case "Smoke Rush":
                    spell_book_array[j] = "Ancient";
                    break;
                case "Dark Demonbane":
                case "Superior Demonbane":
                case "Inferior Demonbane":
                case "Undead Grasp":
                case "Skeletal Grasp":
                case "Ghostly Grasp":
                    spell_book_array[j] = "Arceus";
                    break;

            }

            gear_set_2 = false;
        }
        private void spell_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(spell_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                spell_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(spell_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void spell_set_2_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(spell_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                spell_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(spell_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_1_to_2_spell(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(spell_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = true;
                spell_name_array[1] = Convert.ToString(temp_string);
                Dispatcher.Invoke(spell_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        private void copy_2_to_1_spell(object sender, RoutedEventArgs e)
        {
            string temp_string = Convert.ToString(spell_set_2_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                spell_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(spell_gear);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------THRALLS----------------
        private void thralls()
        {
            switch (thrall_name)
            {
                default:
                    MessageBox.Show("Thrall not found", "Thrall name error");
                    break;
                case "None":
                    thrall_max_hit = 0;
                    thrall_avg_dmg = 0;
                    thrall_damage_per_second = 0;
                    thrall_type = "None";
                    break;
                case "Greater Zombie":
                    thrall_max_hit = 3;
                    thrall_type = "crush";  // doesnt matter as long as melee type
                    break;
                case "Greater Ghost":
                    thrall_max_hit = 3;
                    thrall_type = "magic";
                    break;
                case "Greater Skeleton":
                    thrall_max_hit = 3;
                    thrall_type = "ranged";
                    break;
                case "Superior Zombie":
                    thrall_max_hit = 2;
                    thrall_type = "crush";  // doesnt matter as long as melee type
                    break;
                case "Superior Ghost":
                    thrall_max_hit = 2;
                    thrall_type = "magic";
                    break;
                case "Superior Skeleton":
                    thrall_max_hit = 2;
                    thrall_type = "ranged";
                    break;
                case "Lesser Zombie":
                    thrall_max_hit = 1;
                    thrall_type = "crush";  // doesnt matter as long as melee type
                    break;
                case "Lesser Ghost":
                    thrall_max_hit = 1;
                    thrall_type = "magic";
                    break;
                case "Lesser Skeleton":
                    thrall_max_hit = 1;
                    thrall_type = "ranged";
                    break;

            }
        }
        private void thralls_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(thralls_combobox.SelectedItem);
            if (temp_string != "")
            {
                thrall_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(thralls);
                Dispatcher.Invoke(Stats);
            }
        }
        //----------------BOOST EFFECTS----------------
        //----------------POTIONS----------------
        private void potions()
        {
            Dispatcher.Invoke(attack_potions);
            Dispatcher.Invoke(strength_potions);
            Dispatcher.Invoke(defence_potions);
            Dispatcher.Invoke(magic_potions);
            Dispatcher.Invoke(range_potions);

            if (from_load == false)
            {
                Dispatcher.Invoke(Stats);
            }
        }
        private void attack_potions_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(attack_potions_combobox.SelectedItem);
            if (temp_string != "")
            {
                atk_pot_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(attack_potions);
                Dispatcher.Invoke(Stats);
            }
        }
        private void attack_potions()
        {
            switch (atk_pot_name)
            {
                default:
                    MessageBox.Show("Attack potion not found", "Potion name error");
                    break;
                case "None":
                    attack_pot = 0;
                    break;
                case "Smelling salts":
                    attack_pot = attack_lvl * 0.16 + 11;
                    attack_pot = Math.Floor(attack_pot);
                    break;
                case "Overload":
                    attack_pot = attack_lvl * 0.16 + 6;
                    attack_pot = Math.Floor(attack_pot);
                    break;
                case "Super attack":
                    attack_pot = attack_lvl * 0.15 + 5;
                    attack_pot = Math.Floor(attack_pot);
                    break;
                case "Zamorak brew":
                    attack_pot = attack_lvl * 0.2 + 2;
                    attack_pot = Math.Floor(attack_pot);
                    break;
                case "Attack":
                    attack_pot = attack_lvl * 0.1 + 3;
                    attack_pot = Math.Floor(attack_pot);
                    break;
            }
        }
        private void strength_potions_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(strength_potions_combobox.SelectedItem);
            if (temp_string != "")
            {
                str_pot_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(strength_potions);
                Dispatcher.Invoke(Stats);
            }
        }
        private void strength_potions()
        {
            switch (str_pot_name)
            {
                default:
                    MessageBox.Show("Strength potion not found", "Potion name error");
                    break;
                case "None":
                    strength_pot = 0;
                    break;
                case "Smelling salts":
                    strength_pot = strength_lvl * 0.16 + 11;
                    strength_pot = Math.Floor(strength_pot);
                    break;
                case "Overload":
                    strength_pot = strength_lvl * 0.16 + 6;
                    strength_pot = Math.Floor(strength_pot);
                    break;
                case "Super strength":
                    strength_pot = strength_lvl * 0.15 + 5;
                    strength_pot = Math.Floor(strength_pot);
                    break;
                case "Strength":
                    strength_pot = strength_lvl * 0.1 + 3;
                    strength_pot = Math.Floor(strength_pot);
                    break;
            }
        }
        private void defence_potions_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(defence_potions_combobox.SelectedItem);
            if (temp_string != "")
            {
                def_pot_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(defence_potions);
                Dispatcher.Invoke(Stats);
            }
        }
        private void defence_potions()
        {
            switch (def_pot_name)
            {
                default:
                    MessageBox.Show("Defence potion not found", "Potion name error");
                    break;
                case "None":
                    defence_pot = 0;
                    break;
                case "Smelling salts":
                    defence_pot = defence_lvl * 0.16 + 11;
                    defence_pot = Math.Floor(defence_pot);
                    break;
                case "Overload":
                    defence_pot = defence_lvl * 0.16 + 6;
                    defence_pot = Math.Floor(defence_pot);
                    break;
                case "Super defence":
                    defence_pot = defence_lvl * 0.15 + 5;
                    defence_pot = Math.Floor(defence_pot);
                    break;
                case "Defence":
                    defence_pot = defence_lvl * 0.1 + 3;
                    defence_pot = Math.Floor(defence_pot);
                    break;
                case "Saradomin brew":
                    defence_pot = defence_lvl * 0.2 + 2;
                    defence_pot = Math.Floor(defence_pot);
                    break;

            }
        }
        private void magic_potions_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(magic_potions_combobox.SelectedItem);
            if (temp_string != "")
            {
                magic_pot_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(magic_potions);
                Dispatcher.Invoke(Stats);
            }
        }
        private void magic_potions()
        {
            switch (magic_pot_name)
            {
                default:
                    MessageBox.Show("Magic potion not found", "Potion name error");
                    break;
                case "None":
                    magic_pot = 0;
                    break;
                case "Smelling salts":
                    magic_pot = magic_lvl * 0.16 + 11;
                    magic_pot = Math.Floor(magic_pot);
                    break;
                case "Overload":
                    magic_pot = magic_lvl * 0.16 + 6;
                    magic_pot = Math.Floor(magic_pot);
                    break;
                case "Saturated heart":
                    magic_pot = magic_lvl * 0.1 + 4;
                    magic_pot = Math.Floor(magic_pot);
                    break;
                case "Imbued heart":
                    magic_pot = magic_lvl * 0.1 + 1;
                    magic_pot = Math.Floor(magic_pot);
                    break;
                case "Forgotten brew":
                    magic_pot = magic_lvl * 0.08 + 3;
                    magic_pot = Math.Floor(magic_pot);
                    break;
                case "Ancient brew":
                    magic_pot = magic_lvl * 0.05 + 2;
                    magic_pot = Math.Floor(magic_pot);
                    break;
                case "Magic":
                    magic_pot = 4;
                    break;
            }
        }
        private void range_potions_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(range_potions_combobox.SelectedItem);
            if (temp_string != "")
            {
                range_pot_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(range_potions);
                Dispatcher.Invoke(Stats);
            }
        }
        private void range_potions()
        {
            switch (range_pot_name)
            {
                default:
                    MessageBox.Show("Range potion not found", "Potion name error");
                    break;
                case "None":
                    range_pot = 0;
                    break;
                case "Smelling salts":
                    range_pot = range_lvl * 0.16 + 11;
                    range_pot = Math.Floor(range_pot);
                    break;
                case "Overload":
                    range_pot = range_lvl * 0.16 + 6;
                    range_pot = Math.Floor(range_pot);
                    break;
                case "Ranging":
                    range_pot = range_lvl * 0.1 + 4;
                    range_pot = Math.Floor(range_pot);
                    break;
            }
        }

        //----------------BOOST EFFECTS----------------
        //----------------PRAYERS----------------
        private void prayers()
        {
            Dispatcher.Invoke(attack_prayers);
            Dispatcher.Invoke(strength_prayers);
            Dispatcher.Invoke(defence_prayers);
            Dispatcher.Invoke(magic_prayers);
            Dispatcher.Invoke(range_prayers);

            if (from_load == false)
            {
                Dispatcher.Invoke(Stats);
            }
        }
        private void attack_prayers_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(attack_prayer_combobox.SelectedItem);
            if (temp_string != "")
            {
                atk_prayer_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(attack_prayers);
                Dispatcher.Invoke(Stats);
            }
        }
        private void attack_prayers()
        {
            switch (atk_prayer_name)
            {
                default:
                    MessageBox.Show("Attack prayer not found", "Prayer name error");
                    break;
                case "None":
                    attack_prayer = 1;
                    break;
                case "Piety":
                    attack_prayer = 1.2;
                    break;
                case "Chivalry":
                    attack_prayer = 1.15;
                    break;
                case "15%":
                    attack_prayer = 1.15;
                    break;
                case "10%":
                    attack_prayer = 1.1;
                    break;
                case "5%":
                    attack_prayer = 1.05;
                    break;
            }
        }
        private void strength_prayers_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(strength_prayer_combobox.SelectedItem);
            if (temp_string != "")
            {
                str_prayer_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(strength_prayers);
                Dispatcher.Invoke(Stats);
            }
        }
        private void strength_prayers()
        {
            switch (str_prayer_name)
            {
                default:
                    MessageBox.Show("Strength prayer not found", "Prayer name error");
                    break;
                case "None":
                    strenght_prayer = 1;
                    break;
                case "Piety":
                    strenght_prayer = 1.23;
                    break;
                case "Chivalry":
                    strenght_prayer = 1.18;
                    break;
                case "15%":
                    strenght_prayer = 1.15;
                    break;
                case "10%":
                    strenght_prayer = 1.1;
                    break;
                case "5%":
                    strenght_prayer = 1.05;
                    break;
            }
        }
        private void defence_prayers_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(defence_prayer_combobox.SelectedItem);
            if (temp_string != "")
            {
                def_prayer_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(defence_prayers);
                Dispatcher.Invoke(Stats);
            }
        }
        private void defence_prayers()
        {
            switch (def_prayer_name)
            {
                default:
                    MessageBox.Show("Defence prayer not found", "Prayer name error");
                    break;
                case "None":
                    defence_prayer = 1;
                    break;
                case "Piety":
                    defence_prayer = 1.25;
                    break;
                case "Chivalry":
                    defence_prayer = 1.20;
                    break;
                case "15%":
                    defence_prayer = 1.15;
                    break;
                case "10%":
                    defence_prayer = 1.1;
                    break;
                case "5%":
                    defence_prayer = 1.05;
                    break;
            }
        }
        private void magic_prayers_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(magic_prayer_combobox.SelectedItem);
            if (temp_string != "")
            {
                magic_prayer_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(magic_prayers);
                Dispatcher.Invoke(Stats);
            }
        }
        private void magic_prayers()
        {
            switch (magic_prayer_name)
            {
                default:
                    MessageBox.Show("Magic prayer not found", "Prayer name error");
                    break;
                case "None":
                    magic_prayer = 1;
                    break;
                case "Augury":
                    magic_prayer = 1.25;
                    break;
                case "15%":
                    magic_prayer = 1.15;
                    break;
                case "10%":
                    magic_prayer = 1.1;
                    break;
                case "5%":
                    magic_prayer = 1.05;
                    break;
            }
        }
        private void range_prayers_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(range_prayer_combobox.SelectedItem);
            if (temp_string != "")
            {
                range_prayer_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(range_prayers);
                Dispatcher.Invoke(Stats);
            }
        }
        private void range_prayers()
        {
            switch (range_prayer_name)
            {
                default:
                    MessageBox.Show("Range prayer not found", "Prayer name error");
                    break;
                case "None":
                    range_prayer = 1;
                    range_str_prayer = 1;
                    break;
                case "Rigour":
                    range_prayer = 1.20;
                    range_str_prayer = 1.23;
                    break;
                case "15%":
                    range_prayer = 1.15;
                    range_str_prayer = 1.15;
                    break;
                case "10%":
                    range_prayer = 1.1;
                    range_str_prayer = 1.1;
                    break;
                case "5%":
                    range_prayer = 1.05;
                    range_str_prayer = 1.05;
                    break;
            }
        }

        // ----------------USER INPUTS----------------
        private void checkbox_click_update(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(Stats);
        }
        private void CheckBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Toggle the CheckBox state
                CheckBox checkBox = (CheckBox)sender;
                checkBox.IsChecked = !checkBox.IsChecked;
                Dispatcher.Invoke(Stats);
            }
        }
        // all textboxes
        private void textbox_doubleclick(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.Text = "";
        }
        // all textboxes - loadout name textbox
        private void textbox_lostfocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string textBoxName = textbox.Name;
            if (textbox.Text == "")
            {
                switch (textBoxName)
                {
                    // switch cases for the odd textboxes, default for well um default text boxes
                    default:
                        string variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                        FieldInfo fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                        fieldInfo.SetValue(this, 0);
                        textbox.Text = "0";
                        break;
                    case "team_size_textbox":
                        team_size = 1;
                        team_size_textbox.Text = "1";
                        break;
                    case "custom_weapon_atk_speed_1_textbox":
                        custom_attack_speed_array[0] = weapon_atk_speed_array[0];
                        custom_weapon_atk_speed_1_textbox.Text = "" + custom_attack_speed_array[0];
                        break;
                    case "custom_weapon_atk_speed_2_textbox":
                        custom_attack_speed_array[1] = weapon_atk_speed_array[1];
                        custom_weapon_atk_speed_2_textbox.Text = "" + custom_attack_speed_array[1];
                        break;
                    case "stab_atk_1_modifier_textbox":
                        stab_atk_modifier_array[0] = 0;
                        stab_atk_1_modifier_textbox.Text = "0";
                        break;
                    case "stab_atk_2_modifier_textbox":
                        stab_atk_modifier_array[1] = 0;
                        stab_atk_2_modifier_textbox.Text = "0";
                        break;
                    case "stab_def_1_modifier_textbox":
                        stab_def_modifier_array[0] = 0;
                        stab_def_1_modifier_textbox.Text = "0";
                        break;
                    case "stab_def_2_modifier_textbox":
                        stab_def_modifier_array[1] = 0;
                        stab_def_2_modifier_textbox.Text = "0";
                        break;
                    case "slash_atk_1_modifier_textbox":
                        slash_atk_modifier_array[0] = 0;
                        slash_atk_1_modifier_textbox.Text = "0";
                        break;
                    case "slash_atk_2_modifier_textbox":
                        slash_atk_modifier_array[1] = 0;
                        slash_atk_2_modifier_textbox.Text = "0";
                        break;
                    case "slash_def_1_modifier_textbox":
                        slash_def_modifier_array[0] = 0;
                        slash_def_1_modifier_textbox.Text = "0";
                        break;
                    case "slash_def_2_modifier_textbox":
                        slash_def_modifier_array[1] = 0;
                        slash_def_2_modifier_textbox.Text = "0";
                        break;
                    case "crush_atk_1_modifier_textbox":
                        crush_atk_modifier_array[0] = 0;
                        crush_atk_1_modifier_textbox.Text = "0";
                        break;
                    case "crush_atk_2_modifier_textbox":
                        crush_atk_modifier_array[1] = 0;
                        crush_atk_2_modifier_textbox.Text = "0";
                        break;
                    case "crush_def_1_modifier_textbox":
                        crush_def_modifier_array[0] = 0;
                        crush_def_1_modifier_textbox.Text = "0";
                        break;
                    case "crush_def_2_modifier_textbox":
                        crush_def_modifier_array[1] = 0;
                        crush_def_2_modifier_textbox.Text = "0";
                        break;
                    case "magic_atk_1_modifier_textbox":
                        magic_atk_modifier_array[0] = 0;
                        magic_atk_1_modifier_textbox.Text = "0";
                        break;
                    case "magic_atk_2_modifier_textbox":
                        magic_atk_modifier_array[1] = 0;
                        magic_atk_2_modifier_textbox.Text = "0";
                        break;
                    case "magic_def_1_modifier_textbox":
                        magic_def_modifier_array[0] = 0;
                        magic_def_1_modifier_textbox.Text = "0";
                        break;
                    case "magic_def_2_modifier_textbox":
                        magic_def_modifier_array[1] = 0;
                        magic_def_2_modifier_textbox.Text = "0";
                        break;
                    case "range_atk_1_modifier_textbox":
                        range_atk_modifier_array[0] = 0;
                        range_atk_1_modifier_textbox.Text = "0";
                        break;
                    case "range_atk_2_modifier_textbox":
                        range_atk_modifier_array[1] = 0;
                        range_atk_2_modifier_textbox.Text = "0";
                        break;
                    case "range_def_1_modifier_textbox":
                        range_def_modifier_array[0] = 0;
                        range_def_1_modifier_textbox.Text = "0";
                        break;
                    case "range_def_2_modifier_textbox":
                        range_def_modifier_array[1] = 0;
                        range_def_2_modifier_textbox.Text = "0";
                        break;
                    case "str_1_modifier_textbox":
                        melee_str_modifier_array[0] = 0;
                        str_1_modifier_textbox.Text = "0";
                        break;
                    case "str_2_modifier_textbox":
                        melee_str_modifier_array[1] = 0;
                        str_2_modifier_textbox.Text = "0";
                        break;
                    case "range_str_1_modifier_textbox":
                        range_str_modifier_array[0] = 0;
                        range_str_1_modifier_textbox.Text = "0";
                        break;
                    case "range_str_2_modifier_textbox":
                        range_str_modifier_array[1] = 0;
                        range_str_2_modifier_textbox.Text = "0";
                        break;
                    case "magic_dmg_1_modifier_textbox":
                        magic_dmg_modifier_array[0] = 0;
                        magic_dmg_1_modifier_textbox.Text = "0";
                        break;
                    case "magic_dmg_2_modifier_textbox":
                        magic_dmg_modifier_array[1] = 0;
                        magic_dmg_2_modifier_textbox.Text = "0";
                        break;


                }

                Dispatcher.Invoke(Stats);
            }
        }
        // all textboxes - loadout name textbox - custom attack speed 1 and 2
        private void textbox_keyup(object sender, KeyEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string textBoxName = textbox.Name;
            int user_input;
            bool parseOK = int.TryParse(textbox.Text, out user_input);
            if (parseOK == true)
            {
                switch (textBoxName)
                {
                    // switch cases for the odd textboxes, default for well um default text boxes
                    default:
                        string variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                        FieldInfo fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                        fieldInfo.SetValue(this, user_input);
                        break;
                    // 0-100 cases
                    case "melee_prayer_effectiviness_textbox":
                    case "mage_prayer_effectiviness_textbox":
                    case "range_prayer_effectiviness_textbox":
                        if (user_input >= 0 && user_input <= 100)
                        {
                            variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                            fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                            fieldInfo.SetValue(this, user_input);
                        }
                        else
                        {
                            MessageBox.Show("Please insert numbers between 0-100");
                            variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                            fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                            textbox.Text = "" + fieldInfo.GetValue(this);
                        }
                        break;
                        // 0-99 cases
                    case "attack_lvl_textbox":
                    case "strength_lvl_textbox":
                    case "defence_lvl_textbox":
                    case "magic_lvl_textbox":
                    case "range_lvl_textbox":
                    case "hp_lvl_textbox":
                    case "prayer_lvl_textbox":
                    case "mining_lvl_textbox":
                        if (user_input >= 0 && user_input <= 99)
                        {
                            variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                            fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                            fieldInfo.SetValue(this, user_input);
                        }
                        else
                        {
                            MessageBox.Show("Please insert numbers between 0-99");
                            variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                            fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                            textbox.Text = "" + fieldInfo.GetValue(this);
                        }
                        break;
                    // positive numbers cases
                    case "hp_remaining_textbox":
                    case "prayer_remaining_textbox":
                    case "arclight_hits_textbox":
                    case "dwh_hits_textbox":
                    case "bgs_dmg_textbox":
                    case "dmg_delt_textbox":
                    case "toa_raid_lvl_textbox":
                    case "toa_path_lvl_textbox":
                    case "distance_to_monster_textbox":
                        if (user_input >= 0)
                        {
                            variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                            fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                            fieldInfo.SetValue(this, user_input);
                        }
                        else
                        {
                            MessageBox.Show("Please insert positive numbers");
                            variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                            fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                            textbox.Text = "" + fieldInfo.GetValue(this);
                        }
                        break;

                        // singular cases and array stuff
                    case "team_size_textbox":
                        if (user_input > 0 && user_input <= 100)
                        {
                            team_size = user_input;
                        }
                        else
                        {
                            MessageBox.Show("Please insert numbers between 1-100");
                            team_size_textbox.Text = "" + team_size;
                        }
                        break;
                    case "soulreaper_axe_stack_textbox":
                        if (user_input >= 0 && user_input <= 5)
                        {
                            team_size = user_input;
                        }
                        else
                        {
                            MessageBox.Show("Please insert numbers between 0-5");
                            soulreaper_axe_stack_textbox.Text = "" + soulreaper_axe_stack;
                        }
                        break;
                    case "stab_atk_1_modifier_textbox":
                        stab_atk_modifier_array[0] = user_input;
                        break;
                    case "stab_atk_2_modifier_textbox":
                        stab_atk_modifier_array[1] = user_input;
                        break;
                    case "stab_def_1_modifier_textbox":
                        stab_def_modifier_array[0] = user_input;
                        break;
                    case "stab_def_2_modifier_textbox":
                        stab_def_modifier_array[1] = user_input;
                        break;
                    case "slash_atk_1_modifier_textbox":
                        slash_atk_modifier_array[0] = user_input;
                        break;
                    case "slash_atk_2_modifier_textbox":
                        slash_atk_modifier_array[1] = user_input;
                        break;
                    case "slash_def_1_modifier_textbox":
                        slash_def_modifier_array[0] = user_input;
                        break;
                    case "slash_def_2_modifier_textbox":
                        slash_def_modifier_array[1] = user_input;
                        break;
                    case "crush_atk_1_modifier_textbox":
                        crush_atk_modifier_array[0] = user_input;
                        break;
                    case "crush_atk_2_modifier_textbox":
                        crush_atk_modifier_array[1] = user_input;
                        break;
                    case "crush_def_1_modifier_textbox":
                        crush_def_modifier_array[0] = user_input;
                        break;
                    case "crush_def_2_modifier_textbox":
                        crush_def_modifier_array[1] = user_input;
                        break;
                    case "magic_atk_1_modifier_textbox":
                        magic_atk_modifier_array[0] = user_input;
                        break;
                    case "magic_atk_2_modifier_textbox":
                        magic_atk_modifier_array[1] = user_input;
                        break;
                    case "magic_def_1_modifier_textbox":
                        magic_def_modifier_array[0] = user_input;
                        break;
                    case "magic_def_2_modifier_textbox":
                        magic_def_modifier_array[1] = user_input;
                        break;
                    case "range_atk_1_modifier_textbox":
                        range_atk_modifier_array[0] = user_input;
                        break;
                    case "range_atk_2_modifier_textbox":
                        range_atk_modifier_array[1] = user_input;
                        break;
                    case "range_def_1_modifier_textbox":
                        range_def_modifier_array[0] = user_input;
                        break;
                    case "range_def_2_modifier_textbox":
                        range_def_modifier_array[1] = user_input;
                        break;
                    case "str_1_modifier_textbox":
                        melee_str_modifier_array[0] = user_input;
                        break;
                    case "str_2_modifier_textbox":
                        melee_str_modifier_array[1] = user_input;
                        break;
                    case "range_str_1_modifier_textbox":
                        range_str_modifier_array[0] = user_input;
                        break;
                    case "range_str_2_modifier_textbox":
                        range_str_modifier_array[1] = user_input;
                        break;
                    case "magic_dmg_1_modifier_textbox":
                        magic_dmg_modifier_array[0] = user_input;
                        break;
                    case "magic_dmg_2_modifier_textbox":
                        magic_dmg_modifier_array[1] = user_input;
                        break;
                }

                Dispatcher.Invoke(Stats);

            }
            else if (textbox.Text != "")
            {
                MessageBox.Show("Value is incorrect");
                switch (textBoxName)
                {
                    default:
                        string variableName = textBoxName.Substring(0, textBoxName.Length - "_textbox".Length);
                        FieldInfo fieldInfo = typeof(MainWindow).GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance);
                        textbox.Text = "" + fieldInfo.GetValue(this);
                        break;
                        // array stuff
                    case "stab_atk_1_modifier_textbox":
                        stab_atk_1_modifier_textbox.Text = "" + stab_atk_modifier_array[0];
                        break;
                    case "stab_atk_2_modifier_textbox":
                        stab_atk_2_modifier_textbox.Text = "" + stab_atk_modifier_array[1];
                        break;
                    case "stab_def_1_modifier_textbox":
                        stab_def_1_modifier_textbox.Text = "" + stab_def_modifier_array[0];
                        break;
                    case "stab_def_2_modifier_textbox":
                        stab_def_2_modifier_textbox.Text = "" + stab_def_modifier_array[1];
                        break;
                    case "slash_atk_1_modifier_textbox":
                        slash_atk_1_modifier_textbox.Text = "" + slash_atk_modifier_array[0];
                        break;
                    case "slash_atk_2_modifier_textbox":
                        slash_atk_2_modifier_textbox.Text = "" + slash_atk_modifier_array[1];
                        break;
                    case "slash_def_1_modifier_textbox":
                        slash_def_1_modifier_textbox.Text = "" + slash_def_modifier_array[0];
                        break;
                    case "slash_def_2_modifier_textbox":
                        slash_def_2_modifier_textbox.Text = "" + slash_def_modifier_array[1];
                        break;
                    case "crush_atk_1_modifier_textbox":
                        crush_atk_1_modifier_textbox.Text = "" + crush_atk_modifier_array[0];
                        break;
                    case "crush_atk_2_modifier_textbox":
                        crush_atk_2_modifier_textbox.Text = "" + crush_atk_modifier_array[1];
                        break;
                    case "crush_def_1_modifier_textbox":
                        crush_def_1_modifier_textbox.Text = "" + crush_def_modifier_array[0];
                        break;
                    case "crush_def_2_modifier_textbox":
                        crush_def_2_modifier_textbox.Text = "" + crush_def_modifier_array[1];
                        break;
                    case "magic_atk_1_modifier_textbox":
                        magic_atk_1_modifier_textbox.Text = "" + magic_atk_modifier_array[0];
                        break;
                    case "magic_atk_2_modifier_textbox":
                        magic_atk_2_modifier_textbox.Text = "" + magic_atk_modifier_array[1];
                        break;
                    case "magic_def_1_modifier_textbox":
                        magic_def_1_modifier_textbox.Text = "" + magic_def_modifier_array[0];
                        break;
                    case "magic_def_2_modifier_textbox":
                        magic_def_2_modifier_textbox.Text = "" + magic_def_modifier_array[1];
                        break;
                    case "range_atk_1_modifier_textbox":
                        range_atk_1_modifier_textbox.Text = "" + range_atk_modifier_array[0];
                        break;
                    case "range_atk_2_modifier_textbox":
                        range_atk_2_modifier_textbox.Text = "" + range_atk_modifier_array[1];
                        break;
                    case "range_def_1_modifier_textbox":
                        range_def_1_modifier_textbox.Text = "" + range_def_modifier_array[0];
                        break;
                    case "range_def_2_modifier_textbox":
                        range_def_2_modifier_textbox.Text = "" + range_def_modifier_array[1];
                        break;
                    case "str_1_modifier_textbox":
                        str_1_modifier_textbox.Text = "" + melee_str_modifier_array[0];
                        break;
                    case "str_2_modifier_textbox":
                        str_2_modifier_textbox.Text = "" + melee_str_modifier_array[1];
                        break;
                    case "range_str_1_modifier_textbox":
                        range_str_1_modifier_textbox.Text = "" + range_str_modifier_array[0];
                        break;
                    case "range_str_2_modifier_textbox":
                        range_str_2_modifier_textbox.Text = "" + range_str_modifier_array[1];
                        break;
                    case "magic_dmg_1_modifier_textbox":
                        magic_dmg_1_modifier_textbox.Text = "" + magic_dmg_modifier_array[0];
                        break;
                    case "magic_dmg_2_modifier_textbox":
                        magic_dmg_2_modifier_textbox.Text = "" + magic_dmg_modifier_array[1];
                        break;
                }

                Dispatcher.Invoke(Stats);

            }

        }
        private void custom_weapon_atk_speed_key_up(object sender, KeyEventArgs e)
        {
            string temp_string = custom_weapon_atk_speed_1_textbox.Text;
            bool endsWithComma = temp_string.EndsWith(",");
            if (endsWithComma)
            {
                //do nothing
            }
            else
            {
                double user_input;
                bool parseOK = double.TryParse(custom_weapon_atk_speed_1_textbox.Text, out user_input);
                if (parseOK == true)
                {
                    custom_attack_speed_array[0] = user_input;


                    Dispatcher.Invoke(Stats);
                }
                else if (custom_weapon_atk_speed_1_textbox.Text != "")
                {
                    MessageBox.Show("Custom attack speed 1 value is incorrect");
                    custom_weapon_atk_speed_1_textbox.Text = "" + weapon_atk_speed_array[0];
                    Dispatcher.Invoke(Stats);
                }
            }

        }
        private void custom_weapon_atk_speed_2_key_up(object sender, KeyEventArgs e)
        {
            string temp_string = custom_weapon_atk_speed_2_textbox.Text;
            bool endsWithComma = temp_string.EndsWith(",");
            if (endsWithComma)
            {
                //do nothing
            }
            else
            {
                double user_input;
                bool parseOK = double.TryParse(custom_weapon_atk_speed_2_textbox.Text, out user_input);
                if (parseOK == true)
                {
                    custom_attack_speed_array[1] = user_input;


                    Dispatcher.Invoke(Stats);
                }
                else if (custom_weapon_atk_speed_2_textbox.Text != "")
                {
                    MessageBox.Show("Custom attack speed 2 value is incorrect");
                    custom_weapon_atk_speed_2_textbox.Text = "" + weapon_atk_speed_array[1];
                    Dispatcher.Invoke(Stats);
                }
            }

        } 
        // monster stat change buttons and change shown set button
        private void arclight_plus_1_button_click(object sender, RoutedEventArgs e)
        {
            int user_input;
            bool parseOK = int.TryParse(arclight_hits_textbox.Text, out user_input);
            if (parseOK == true)
            {
                arclight_hits = user_input + 1;
                arclight_hits_textbox.Text = ("" + arclight_hits);
                Dispatcher.Invoke(Stats);
            }
        }
        private void arclight_minus_1_button_click(object sender, RoutedEventArgs e)
        {
            int user_input;
            bool parseOK = int.TryParse(arclight_hits_textbox.Text, out user_input);
            if (parseOK == true)
            {
                if (user_input > 0)
                {
                    arclight_hits = user_input - 1;
                    arclight_hits_textbox.Text = ("" + arclight_hits);
                    Dispatcher.Invoke(Stats);
                }
            }
        }
        private void dwh_plus_1_button_click(object sender, RoutedEventArgs e)
        {
            int user_input;
            bool parseOK = int.TryParse(dwh_hits_textbox.Text, out user_input);
            if (parseOK == true)
            {
                dwh_hits = user_input + 1;
                dwh_hits_textbox.Text = ("" + dwh_hits);
                Dispatcher.Invoke(Stats);
            }
        }
        private void dwh_minus_1_button_click(object sender, RoutedEventArgs e)
        {
            int user_input;
            bool parseOK = int.TryParse(dwh_hits_textbox.Text, out user_input);
            if (parseOK == true)
            {
                if (user_input > 0)
                {
                    dwh_hits = user_input - 1;
                    dwh_hits_textbox.Text = ("" + dwh_hits);
                    Dispatcher.Invoke(Stats);
                }
            }
        }
        private void o_def_bgs(object sender, RoutedEventArgs e)
        {
            bgs_dmg = monster_boosted_def_lvl - (monster_boosted_def_lvl - monster_reduced_def_lvl);
            bgs_dmg_textbox.Text = ("" + bgs_dmg);
            Dispatcher.Invoke(Stats);
        }
        private void match_bgs_dmg(object sender, RoutedEventArgs e)
        {
            dmg_delt = bgs_dmg;
            dmg_delt_textbox.Text = ("" + dmg_delt);
            Dispatcher.Invoke(Stats);
        }
        private void change_shown_set_button_click(object sender, RoutedEventArgs e)
        {
            if (show_set_2 == true)
            {
                show_set_2 = false;
                change_shown_set_button.Content = "Click to change shown set (Currently showing set 1)";
                change_shown_set_button_Copy.Content = "Click to change shown set (Currently showing set 1)";
            }
            else
            {
                show_set_2 = true;
                change_shown_set_button.Content = "Click to change shown set (Currently showing set 2)";
                change_shown_set_button_Copy.Content = "Click to change shown set (Currently showing set 2)";
            }

            Dispatcher.Invoke(monster_hit_chance_and_avg_dmg);
            Dispatcher.Invoke(UpdateUI);
            Dispatcher.Invoke(coloring_menu);
        }
        private void compare_data_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.Invoke(compare_data);
            Dispatcher.Invoke(monster_hit_chance_and_avg_dmg);
        }
        // multiple calcs
        // addind monsters
        private void multiple_dpsc_calcs_add_monster_button_click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(multiple_monster_names);
            Dispatcher.Invoke(UpdateUI);
        }
        private void multiple_dpsc_calcs_add_cox_monster_button_click(object sender, RoutedEventArgs e)
        {
            string temp_name = monster_name;
            temp_mutiple_monster_names_list.Clear();
            temp_mutiple_monster_names_list.Add("Tekton");
            temp_mutiple_monster_names_list.Add("Tekton (enraged)");
            temp_mutiple_monster_names_list.Add("Ice demon");
            temp_mutiple_monster_names_list.Add("Lizardman shaman (CoX)");
            temp_mutiple_monster_names_list.Add("Vanguard (melee)");
            temp_mutiple_monster_names_list.Add("Vanguard (mage)");
            temp_mutiple_monster_names_list.Add("Vanguard (range)");
            temp_mutiple_monster_names_list.Add("Vespula");
            temp_mutiple_monster_names_list.Add("Abyssal portal");
            temp_mutiple_monster_names_list.Add("Deathly mage");
            temp_mutiple_monster_names_list.Add("Deathly ranger");
            temp_mutiple_monster_names_list.Add("Guardian");
            temp_mutiple_monster_names_list.Add("Vasa Nistirio");
            temp_mutiple_monster_names_list.Add("Glowing crystal");
            temp_mutiple_monster_names_list.Add("Skeletal Mystic");
            temp_mutiple_monster_names_list.Add("Muttadile (small)");
            temp_mutiple_monster_names_list.Add("Muttadile (big)");
            temp_mutiple_monster_names_list.Add("Great olm (mage hand)");
            temp_mutiple_monster_names_list.Add("Great olm (melee hand)");
            temp_mutiple_monster_names_list.Add("Great olm (head)");
            temp_mutiple_monster_names_list.Add("Scavenger");

            foreach (string temp_monster_name in temp_mutiple_monster_names_list)
            {
                monster_name = temp_monster_name;
                Dispatcher.Invoke(multiple_monster_names);
            }

            monster_name = temp_name;
            Dispatcher.Invoke(UpdateUI);

        }
        private void multiple_dpsc_calcs_add_tob_monster_button_click(object sender, RoutedEventArgs e)
        {
            string temp_name = monster_name;
            temp_mutiple_monster_names_list.Clear();
            temp_mutiple_monster_names_list.Add("The Maiden of Sugadinti");
            temp_mutiple_monster_names_list.Add("Pestilent Bloat");
            temp_mutiple_monster_names_list.Add("Pestilent Bloat (moving)");
            temp_mutiple_monster_names_list.Add("Hard mode Pestilent Bloat");
            temp_mutiple_monster_names_list.Add("Hard mode Pestilent Bloat (moving)");
            temp_mutiple_monster_names_list.Add("Nylocas Vasilias (Nylo boss)");
            temp_mutiple_monster_names_list.Add("Sotetseg");
            temp_mutiple_monster_names_list.Add("Hard mode Sotetseg");
            temp_mutiple_monster_names_list.Add("Xarpus");
            temp_mutiple_monster_names_list.Add("Hard mode Xarpus");
            temp_mutiple_monster_names_list.Add("Verzik vitur P1");
            temp_mutiple_monster_names_list.Add("Verzik vitur P2");
            temp_mutiple_monster_names_list.Add("Verzik vitur P3");

            if (add_nylos_checkbox.IsChecked == true)
            {
                temp_mutiple_monster_names_list.Add("Nylocas Ischyros (small melee)");
                temp_mutiple_monster_names_list.Add("Nylocas Ischyros (big melee)");
                temp_mutiple_monster_names_list.Add("Nylocas Hagios (small mage)");
                temp_mutiple_monster_names_list.Add("Nylocas Hagios (big mage)");
                temp_mutiple_monster_names_list.Add("Nylocas Toxobolos (small range)");
                temp_mutiple_monster_names_list.Add("Nylocas Toxobolos (big range)");
                temp_mutiple_monster_names_list.Add("Nylocas Matomenos (maiden)");
                temp_mutiple_monster_names_list.Add("Nylocas Matomenos (verzik)");
                temp_mutiple_monster_names_list.Add("Nylocas Prinkipas (Nylo prince)");
            }

            foreach (string temp_monster_name in temp_mutiple_monster_names_list)
            {
                monster_name = temp_monster_name;
                Dispatcher.Invoke(multiple_monster_names);
            }

            monster_name = temp_name;
            Dispatcher.Invoke(UpdateUI);
        }
        private void multiple_dpsc_calcs_add_toa_monster_button_click(object sender, RoutedEventArgs e)
        {
            string temp_name = monster_name;
            temp_mutiple_monster_names_list.Clear();
            temp_mutiple_monster_names_list.Add("Akkha");
            temp_mutiple_monster_names_list.Add("Akkha's Shadow");
            temp_mutiple_monster_names_list.Add("Ba-Ba");
            temp_mutiple_monster_names_list.Add("Kephri");
            temp_mutiple_monster_names_list.Add("Zebak");
            temp_mutiple_monster_names_list.Add("Obelisk");
            temp_mutiple_monster_names_list.Add("Tumeken's Warden P2 (assumes normal npc)");
            temp_mutiple_monster_names_list.Add("Elidinis' Warden P2 (assumes normal npc)");
            temp_mutiple_monster_names_list.Add("Wardens Core");
            temp_mutiple_monster_names_list.Add("Wardens P3");
            temp_mutiple_monster_names_list.Add("Wardens P4");

            if (add_baboons_and_scarabs_checkbox.IsChecked == true)
            {
                temp_mutiple_monster_names_list.Add("Soldier Scarab");
                temp_mutiple_monster_names_list.Add("Arcane Scarab");
                temp_mutiple_monster_names_list.Add("Spitting Scarab");
                temp_mutiple_monster_names_list.Add("Baboon Brawler (small melee)");
                temp_mutiple_monster_names_list.Add("Baboon Brawler (big melee)");
                temp_mutiple_monster_names_list.Add("Baboon Mage (small mage)");
                temp_mutiple_monster_names_list.Add("Baboon Mage (big mage)");
                temp_mutiple_monster_names_list.Add("Baboon Thrower (small range)");
                temp_mutiple_monster_names_list.Add("Baboon Thrower (big range)");
                temp_mutiple_monster_names_list.Add("Baboon Shaman");
                temp_mutiple_monster_names_list.Add("Baboon Thrall");
                temp_mutiple_monster_names_list.Add("Volatile Baboon");
                temp_mutiple_monster_names_list.Add("Cursed Baboon");
                temp_mutiple_monster_names_list.Add("Baboon (Ba-Ba)");
            }

            foreach (string temp_monster_name in temp_mutiple_monster_names_list)
            {
                monster_name = temp_monster_name;
                Dispatcher.Invoke(multiple_monster_names);
            }

            monster_name = temp_name;
            Dispatcher.Invoke(UpdateUI);
        }
        private void multiple_dpsc_calcs_add_fight_caves_monster_button_click(object sender, RoutedEventArgs e)
        {
            string temp_name = monster_name;
            temp_mutiple_monster_names_list.Clear();
            temp_mutiple_monster_names_list.Add("Tz-Kih (bat)");
            temp_mutiple_monster_names_list.Add("Tz-Kek (mini blob)");
            temp_mutiple_monster_names_list.Add("Tz-Kek (big blob)");
            temp_mutiple_monster_names_list.Add("Tok-Xil (range)");
            temp_mutiple_monster_names_list.Add("Yt-MejKot (melee)");
            temp_mutiple_monster_names_list.Add("Ket-Zek (mage)");
            temp_mutiple_monster_names_list.Add("TzTok-Jad");
            temp_mutiple_monster_names_list.Add("Yt-HurKot (healer)");

            foreach (string temp_monster_name in temp_mutiple_monster_names_list)
            {
                monster_name = temp_monster_name;
                Dispatcher.Invoke(multiple_monster_names);
            }

            monster_name = temp_name;
            Dispatcher.Invoke(UpdateUI);
        }
        private void multiple_dpsc_calcs_add_inferno_monster_button_click(object sender, RoutedEventArgs e)
        {
            string temp_name = monster_name;
            temp_mutiple_monster_names_list.Clear();
            temp_mutiple_monster_names_list.Add("Jal-Nib (nibbler)");
            temp_mutiple_monster_names_list.Add("Jal-MejRah (bat)");
            temp_mutiple_monster_names_list.Add("Jal-AkRek-Ket (melee blob)");
            temp_mutiple_monster_names_list.Add("Jal-AkRek-Mej (mage blob)");
            temp_mutiple_monster_names_list.Add("Jal-AkRek-Xil (range blob)");
            temp_mutiple_monster_names_list.Add("Jal-Ak (blob)");
            temp_mutiple_monster_names_list.Add("Jal-ImKot (melee)");
            temp_mutiple_monster_names_list.Add("Jal-Xil (range)");
            temp_mutiple_monster_names_list.Add("Jal-Zek (mage)");
            temp_mutiple_monster_names_list.Add("JalTok-Jad");
            temp_mutiple_monster_names_list.Add("Yt-HurKot (inferno jad healer)");
            temp_mutiple_monster_names_list.Add("TzKal-Zuk");
            temp_mutiple_monster_names_list.Add("Jal-MejJak (zuk healer)");

            foreach (string temp_monster_name in temp_mutiple_monster_names_list)
            {
                monster_name = temp_monster_name;
                Dispatcher.Invoke(multiple_monster_names);
            }

            monster_name = temp_name;
            Dispatcher.Invoke(UpdateUI);
        }
        // removing monsters
        private void multiple_dpsc_calcs_remove_monster_button_click(object sender, RoutedEventArgs e)
        {
            multiple_monsters_data_list.RemoveAll(item => item.Split(';')[0] == monster_name);

            List<string> itemsToRemove = new List<string>();
            string baseVariantPattern = monster_name + " ";

            foreach (var item in multiple_dps_monster_name_combobox.Items)
            {
                if (item is string itemName && (itemName == monster_name || itemName.StartsWith(baseVariantPattern)))
                {
                    itemsToRemove.Add(itemName);
                }
            }

            foreach (var itemToRemove in itemsToRemove)
            {
                multiple_dps_monster_name_combobox.Items.Remove(itemToRemove);
            }

            Dispatcher.Invoke(UpdateUI);
        }
        private void multiple_dpsc_calcs_clear_monster_button(object sender, RoutedEventArgs e)
        {
            multiple_monsters_data_list.Clear();
            multiple_dps_monster_name_combobox.Items.Clear();
            Dispatcher.Invoke(UpdateUI);
        }
        // other multi calc inputs
        private void set_1_multicalc_checkbox_click(object sender, RoutedEventArgs e)
        {
            if (set_1_multicalc_checkbox.IsChecked == true)
            {
                multiple_dps_loadouts_combobox.Items.Add("Set 1");
            }
            if (set_1_multicalc_checkbox.IsChecked == false)
            {
                multiple_dps_loadouts_combobox.Items.Remove("Set 1");
            }
            Dispatcher.Invoke(UpdateUI);
        }
        private void set_2_multicalc_checkbox_click(object sender, RoutedEventArgs e)
        {
            if (set_2_multicalc_checkbox.IsChecked == true)
            {
                multiple_dps_loadouts_combobox.Items.Add("Set 2");
            }
            if (set_2_multicalc_checkbox.IsChecked == false)
            {
                multiple_dps_loadouts_combobox.Items.Remove("Set 2");
            }
            Dispatcher.Invoke(UpdateUI);
        }
        private void set_1_CheckBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Toggle the CheckBox state
                CheckBox checkBox = (CheckBox)sender;
                checkBox.IsChecked = !checkBox.IsChecked;
                if (set_1_multicalc_checkbox.IsChecked == true)
                {
                    multiple_dps_loadouts_combobox.Items.Add("Set 1");
                }
                if (set_1_multicalc_checkbox.IsChecked == false)
                {
                    multiple_dps_loadouts_combobox.Items.Remove("Set 1");
                }
                Dispatcher.Invoke(UpdateUI);
            }
        }
        private void set_2_CheckBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Toggle the CheckBox state
                CheckBox checkBox = (CheckBox)sender;
                checkBox.IsChecked = !checkBox.IsChecked;
                if (set_2_multicalc_checkbox.IsChecked == true)
                {
                    multiple_dps_loadouts_combobox.Items.Add("Set 2");
                }
                if (set_2_multicalc_checkbox.IsChecked == false)
                {
                    multiple_dps_loadouts_combobox.Items.Remove("Set 2");
                }
                Dispatcher.Invoke(UpdateUI);
            }
        }
        private void add_loadout_to_multuple_calc_button_click(object sender, RoutedEventArgs e)
        {
            if (load_loadout_combobox.Text != "")
            {
                bool loadout_exists = false;
                foreach (var item in multiple_dps_loadouts_combobox.Items)
                {
                    if (item.ToString() == load_loadout_combobox.Text)
                    {
                        loadout_exists = true;
                        break;
                    }
                }

                if (loadout_exists == false)
                {
                    multiple_dps_loadouts_combobox.Items.Add(load_loadout_combobox.Text);
                    Dispatcher.Invoke(UpdateUI);
                }
                else
                {
                    MessageBox.Show("Selected loadout is already added");
                }
            }
            else
            {
                MessageBox.Show("Please select loadout to add from the menu on the left side.");
            }
        }
        private void remove_loadout_from_multuple_calc_button_click(object sender, RoutedEventArgs e)
        {
            multiple_dps_loadouts_combobox.Items.Remove(load_loadout_combobox.Text);
            Dispatcher.Invoke(UpdateUI);
        }
        private void clear_loadouts_from_multuple_calc_button_click(object sender, RoutedEventArgs e)
        {
            set_1_multicalc_checkbox.IsChecked = false;
            set_2_multicalc_checkbox.IsChecked = false;
            multiple_dps_loadouts_combobox.Items.Clear();
            Dispatcher.Invoke(UpdateUI);
        }
        private void calculate_results_button_click(object sender, RoutedEventArgs e)
        {
            // set 1 "save" for multicalc
            // player levels and potions + dragon pickaxe spec
            set_1_during_multicalc = attack_lvl + ";" + strength_lvl + ";" + defence_lvl + ";" + magic_lvl + ";" + range_lvl + ";" + hp_lvl + ";" + prayer_lvl + ";" + mining_lvl + ";" + atk_pot_name + ";" + str_pot_name + ";" + def_pot_name + ";" + magic_pot_name + ";" + range_pot_name + ";" + dragon_picaxe_spec_checkbox.IsChecked + ";";
            // player level modifiers and prayers
            set_1_during_multicalc += attack_lvl_and_pot_modifier + ";" + strength_lvl_and_pot_modifier + ";" + defence_lvl_and_pot_modifier + ";" + magic_lvl_and_pot_modifier + ";" + range_lvl_and_pot_modifier + ";" + hp_remaining + ";" + prayer_remaining + ";" + atk_prayer_name + ";" + str_prayer_name + ";" + def_prayer_name + ";" + magic_prayer_name + ";" + range_prayer_name + ";";
            // player gear
            set_1_during_multicalc += weapon_name_array[0] + ";" + spell_name_array[0] + ";" + ammo_name_array[0] + ";" + helmet_name_array[0] + ";" + cape_name_array[0] + ";" + amulet_name_array[0] + ";" + body_name_array[0] + ";" + legs_name_array[0] + ";" + off_hand_name_array[0] + ";" + gloves_name_array[0] + ";" + boots_name_array[0] + ";" + ring_name_array[0] + ";";
            // offencive stats modifiers
            set_1_during_multicalc += stab_atk_modifier_array[0] + ";" + slash_atk_modifier_array[0] + ";" + crush_atk_modifier_array[0] + ";" + melee_str_modifier_array[0] + ";" + magic_atk_modifier_array[0] + ";" + magic_dmg_modifier_array[0] + ";" + range_atk_modifier_array[0] + ";" + range_str_modifier_array[0] + ";" + custom_attack_speed_array[0] + ";" + custom_attack_speed_checkbox.IsChecked + ";";
            // defensive stats modifiers
            set_1_during_multicalc += stab_def_modifier_array[0] + ";" + slash_def_modifier_array[0] + ";" + crush_def_modifier_array[0] + ";" + magic_def_modifier_array[0] + ";" + range_def_modifier_array[0] + ";";
            // venator bow
            set_1_during_multicalc += venator_bow_1st_bounce_def_lvl + ";" + venator_bow_1st_bounce_range_def + ";" + venator_1st_bounce_checkbox.IsChecked + ";" + venator_bow_2nd_bounce_def_lvl + ";" + venator_bow_2nd_bounce_range_def + ";" + venator_2nd_bounce_checkbox.IsChecked + ";";
            // thralls, soulreaper axe stac, chin
            set_1_during_multicalc += thrall_name + ";" + thrall_dps_checkbox.IsChecked + ";" + soulreaper_axe_stack + ";" + distance_to_monster;

            // set 2 "save" for multicalc
            // player levels and potions + dragon pickaxe spec
            set_2_during_multicalc = attack_lvl + ";" + strength_lvl + ";" + defence_lvl + ";" + magic_lvl + ";" + range_lvl + ";" + hp_lvl + ";" + prayer_lvl + ";" + mining_lvl + ";" + atk_pot_name + ";" + str_pot_name + ";" + def_pot_name + ";" + magic_pot_name + ";" + range_pot_name + ";" + dragon_picaxe_spec_checkbox.IsChecked + ";";
            // player level modifiers and prayers
            set_2_during_multicalc += attack_lvl_and_pot_modifier + ";" + strength_lvl_and_pot_modifier + ";" + defence_lvl_and_pot_modifier + ";" + magic_lvl_and_pot_modifier + ";" + range_lvl_and_pot_modifier + ";" + hp_remaining + ";" + prayer_remaining + ";" + atk_prayer_name + ";" + str_prayer_name + ";" + def_prayer_name + ";" + magic_prayer_name + ";" + range_prayer_name + ";";
            // player gear
            set_2_during_multicalc += weapon_name_array[1] + ";" + spell_name_array[1] + ";" + ammo_name_array[1] + ";" + helmet_name_array[1] + ";" + cape_name_array[1] + ";" + amulet_name_array[1] + ";" + body_name_array[1] + ";" + legs_name_array[1] + ";" + off_hand_name_array[1] + ";" + gloves_name_array[1] + ";" + boots_name_array[1] + ";" + ring_name_array[1] + ";";
            // offencive stats modifiers
            set_2_during_multicalc += stab_atk_modifier_array[1] + ";" + slash_atk_modifier_array[1] + ";" + crush_atk_modifier_array[1] + ";" + melee_str_modifier_array[1] + ";" + magic_atk_modifier_array[1] + ";" + magic_dmg_modifier_array[1] + ";" + range_atk_modifier_array[1] + ";" + range_str_modifier_array[1] + ";" + custom_attack_speed_array[1] + ";" + custom_attack_speed_checkbox.IsChecked + ";";
            // defensive stats modifiers
            set_2_during_multicalc += stab_def_modifier_array[1] + ";" + slash_def_modifier_array[1] + ";" + crush_def_modifier_array[1] + ";" + magic_def_modifier_array[1] + ";" + range_def_modifier_array[1] + ";";
            // venator bow
            set_2_during_multicalc += venator_bow_1st_bounce_def_lvl + ";" + venator_bow_1st_bounce_range_def + ";" + venator_1st_bounce_checkbox.IsChecked + ";" + venator_bow_2nd_bounce_def_lvl + ";" + venator_bow_2nd_bounce_range_def + ";" + venator_2nd_bounce_checkbox.IsChecked + ";";
            // thralls, soulreaper axe stac, chin
            set_2_during_multicalc += thrall_name + ";" + thrall_dps_checkbox.IsChecked + ";" + soulreaper_axe_stack + ";" + distance_to_monster;


            Dispatcher.Invoke(multiple_calcs_dps);

            // dps stats reset back to set 1
            loadout_name = "Set 1";
            Dispatcher.Invoke(load_set_1_and_2_data);
        }
        private void show_results_button_click(object sender, RoutedEventArgs e)
        {
            Window1 secondWindow = new Window1(giga_data_list);
            secondWindow.Show();
        }
        // loadouts
        private void save_loadout_button(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(save_loadout_data);
            Dispatcher.Invoke(load_loadout_names_data);
        }
        private void load_loadout_button(object sender, RoutedEventArgs e)
        {
            if (load_loadout_combobox.Text != "")
            {
                loadout_name = load_loadout_combobox.Text;
                custom_loadout_name_textbox.Text = loadout_name;
                Dispatcher.Invoke(load_loadout_data);
            }
            else
            {
                MessageBox.Show("Please select loadout from the menu below.");
            }

        }
        private void delete_loadout_button(object sender, RoutedEventArgs e)
        {
            loadout_was_deleted = false;
            Dispatcher.Invoke(delete_loadout);

            if (loadout_was_deleted == true)
            {
                load_loadout_combobox.Items.Remove(deleted_loadout_name);

                foreach (var item in multiple_dps_loadouts_combobox.Items)
                {
                    if (item.ToString() == deleted_loadout_name)
                    {
                        multiple_dps_loadouts_combobox.Items.Remove(deleted_loadout_name);
                        Dispatcher.Invoke(UpdateUI);
                        break;
                    }
                }
            }

        }
        // ----------------PRESETS----------------
        // ----------------GEAR----------------
        private void gear_presets()
        {
            int i = 0;
            if (gear_set_2 == true)
            {
                i = 1;
            }

            switch (preset_name_array[i])
            {
                default:
                    MessageBox.Show("Preset not found", "Preset name error");
                    break;
                case "None":
                    weapon_name_array[i] = "None";
                    ammo_name_array[i] = "None";
                    helmet_name_array[i] = "None";
                    cape_name_array[i] = "None";
                    amulet_name_array[i] = "None";
                    body_name_array[i] = "None";
                    legs_name_array[i] = "None";
                    off_hand_name_array[i] = "None";
                    gloves_name_array[i] = "None";
                    boots_name_array[i] = "None";
                    ring_name_array[i] = "None";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);                       
                    break;
                case "Max melee Scythe of vitur":
                    weapon_name_array[i] = "Scythe of vitur";
                    ammo_name_array[i] = "None";
                    helmet_name_array[i] = "Torva full helm";
                    cape_name_array[i] = "Infernal cape";
                    amulet_name_array[i] = "Amulet of torture";
                    body_name_array[i] = "Torva platebody";
                    legs_name_array[i] = "Torva platelegs";
                    off_hand_name_array[i] = "None";
                    gloves_name_array[i] = "Ferocious gloves";
                    boots_name_array[i] = "Primordial boots";
                    ring_name_array[i] = "Ultor ring";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);
                    break;
                case "Max melee Osmumten's fang":
                    weapon_name_array[i] = "Osmumten's fang";
                    ammo_name_array[i] = "None";
                    helmet_name_array[i] = "Torva full helm";
                    cape_name_array[i] = "Infernal cape";
                    amulet_name_array[i] = "Amulet of torture";
                    body_name_array[i] = "Torva platebody";
                    legs_name_array[i] = "Torva platelegs";
                    off_hand_name_array[i] = "Avernic defender";
                    gloves_name_array[i] = "Ferocious gloves";
                    boots_name_array[i] = "Primordial boots";
                    ring_name_array[i] = "Ultor ring";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);
                    break;
                case "Max mage Tumeken's shadow":
                    weapon_name_array[i] = "Tumeken's shadow";
                    ammo_name_array[i] = "None";
                    helmet_name_array[i] = "Ancestral hat";
                    cape_name_array[i] = "God cape (i)";
                    amulet_name_array[i] = "Occult necklace";
                    body_name_array[i] = "Ancestral robe top";
                    legs_name_array[i] = "Ancestral robe bottom";
                    off_hand_name_array[i] = "None";
                    gloves_name_array[i] = "Tormented bracelet";
                    boots_name_array[i] = "Eternal boots";
                    ring_name_array[i] = "Magus ring";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);
                    break;
                case "Max mage Sanguinesti staff":
                    weapon_name_array[i] = "Sanguinesti staff";
                    ammo_name_array[i] = "None";
                    helmet_name_array[i] = "Ancestral hat";
                    cape_name_array[i] = "God cape (i)";
                    amulet_name_array[i] = "Occult necklace";
                    body_name_array[i] = "Ancestral robe top";
                    legs_name_array[i] = "Ancestral robe bottom";
                    off_hand_name_array[i] = "Elidinis' ward (f)";
                    gloves_name_array[i] = "Tormented bracelet";
                    boots_name_array[i] = "Eternal boots";
                    ring_name_array[i] = "Magus ring";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);
                    break;
                case "Max range Twisted bow":
                    weapon_name_array[i] = "Twisted bow";
                    ammo_name_array[i] = "Dragon arrows";
                    helmet_name_array[i] = "Masori mask (f)";
                    cape_name_array[i] = "Ava's assembler";
                    amulet_name_array[i] = "Necklace of anguish";
                    body_name_array[i] = "Masori body (f)";
                    legs_name_array[i] = "Masori chaps (f)";
                    off_hand_name_array[i] = "None";
                    gloves_name_array[i] = "Zaryte vambraces";
                    boots_name_array[i] = "Pegasian boots";
                    ring_name_array[i] = "Venator ring";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);
                    break;
                case "Max range Bow of faerdhinen":
                    weapon_name_array[i] = "Bow of faerdhinen";
                    ammo_name_array[i] = "None";
                    helmet_name_array[i] = "Crystal helm";
                    cape_name_array[i] = "Ava's assembler";
                    amulet_name_array[i] = "Necklace of anguish";
                    body_name_array[i] = "Crystal body";
                    legs_name_array[i] = "Crystal legs";
                    off_hand_name_array[i] = "None";
                    gloves_name_array[i] = "Zaryte vambraces";
                    boots_name_array[i] = "Pegasian boots";
                    ring_name_array[i] = "Venator ring";
                    spell_name_array[i] = "None";
                    Dispatcher.Invoke(gear);
                    break;
                case "Elite void":
                    helmet_name_array[i] = "Void helmet";
                    body_name_array[i] = "Elite void top";
                    legs_name_array[i] = "Elite void robe";
                    gloves_name_array[i] = "Void gloves";
                    Dispatcher.Invoke(gear);
                    break;
            }
        }
        private void preset_set_1_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(presets_set_1_combobox.SelectedItem);
            if (temp_string != "")
            {
                gear_set_2 = false;
                preset_name_array[0] = Convert.ToString(temp_string);
                Dispatcher.Invoke(gear_presets);
                presets_set_1_combobox.Text = "Presets";
            }
        }
        // ----------------POTIONS----------------
        private void preset_potions_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(presets_potions_combobox.SelectedItem);
            if (temp_string != "")
            {
                switch (temp_string)
                {
                    default:
                        MessageBox.Show("Preset not found", "Preset name error");
                        break;
                    case "None":
                        atk_pot_name = "None";
                        str_pot_name = "None";
                        def_pot_name = "None";
                        magic_pot_name = "None";
                        range_pot_name = "None";
                        Dispatcher.Invoke(potions);
                        break;
                    case "Smelling salts":
                        atk_pot_name = "Smelling salts";
                        str_pot_name = "Smelling salts";
                        def_pot_name = "Smelling salts";
                        magic_pot_name = "Smelling salts";
                        range_pot_name = "Smelling salts";
                        Dispatcher.Invoke(potions);
                        break;
                    case "Overload":
                        atk_pot_name = "Overload";
                        str_pot_name = "Overload";
                        def_pot_name = "Overload";
                        magic_pot_name = "Overload";
                        range_pot_name = "Overload";
                        Dispatcher.Invoke(potions);
                        break;
                    case "Super set":
                        atk_pot_name = "Super attack";
                        str_pot_name = "Super strength";
                        def_pot_name = "Super defence";
                        magic_pot_name = "Saturated heart";
                        range_pot_name = "Ranging";
                        Dispatcher.Invoke(potions);
                        break;

                }
                presets_potions_combobox.Text = "Presets";
            }
        }
        // ----------------PRAYERS----------------
        private void preset_prayers_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(presets_prayers_combobox.SelectedItem);
            if (temp_string != "")
            {
                switch (temp_string)
                {
                    default:
                        MessageBox.Show("Preset not found", "Preset name error");
                        break;
                    case "None":
                        atk_prayer_name = "None";
                        str_prayer_name = "None";
                        def_prayer_name = "None";
                        magic_prayer_name = "None";
                        range_prayer_name = "None";
                        Dispatcher.Invoke(prayers);
                        break;
                    case "Bis prayers":
                        atk_prayer_name = "Piety";
                        str_prayer_name = "Piety";
                        def_prayer_name = "Piety";
                        magic_prayer_name = "Augury";
                        range_prayer_name = "Rigour";
                        Dispatcher.Invoke(prayers);
                        break;
                    case "15% prayers":
                        atk_prayer_name = "15%";
                        str_prayer_name = "15%";
                        def_prayer_name = "15%";
                        magic_prayer_name = "15%";
                        range_prayer_name = "15%";
                        Dispatcher.Invoke(prayers);
                        break;

                }
                presets_prayers_combobox.Text = "Presets";
            }
        }
        // ----------------MONSTERS----------------
        private void monsters()
        {
            monster_is_in_cox = false;
            monster_is_in_tob = false;
            monster_is_in_toa = false;
            monster_is_in_wilderness = false;

            monster_is_demon = false;
            monster_is_dragon = false;
            monster_is_undead = false;
            monster_is_kaplhite = false;

            immune_to_melee = false;
            immune_to_mage = false;
            immune_to_range = false;

            monster_defence_cap = 0;
            switch (monster_name)
            {
                default:
                    MessageBox.Show("Monster not found", "Monster name error");
                    break;
                case "None":
                    monster_size = 1;
                    monster_combat_hp_lvl = 0;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 0;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    if (from_load == false)
                    {
                        Dispatcher.Invoke(Stats);
                    }
                    break;
                case "Combat dummy":
                    monster_is_in_cox = true;
                    monster_is_in_tob = true;
                    monster_is_in_toa = true;
                    monster_is_in_wilderness = true;

                    monster_is_demon = true;
                    monster_is_dragon = true;
                    monster_is_undead = true;
                    monster_is_kaplhite = true;
                    monster_defence_cap = 0;
                    monster_size = 10;
                    monster_combat_hp_lvl = 9000;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 0;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 500;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = -64;
                    monster_defensive_slash = -64;
                    monster_defensive_crush = -64;
                    monster_defensive_magic = -64;
                    monster_defensive_range = -64;

                    Dispatcher.Invoke(Stats);
                    break;
                // tob monsters
                case "The Maiden of Sugadinti":
                    monster_is_in_tob = true;
                    monster_size = 6;
                    monster_combat_hp_lvl = 3500;
                    monster_combat_atk_lvl = 350;
                    monster_combat_str_lvl = 350;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 350;
                    monster_combat_range_lvl = 350;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 300;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Pestilent Bloat (moving)":
                case "Pestilent Bloat":
                    monster_is_in_tob = true;
                    monster_is_undead = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 2000;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 340;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 180;
                    monster_aggressive_atk = 150;
                    monster_aggressive_str = 82;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 180;
                    monster_aggressive_range_str = 4;
                    monster_defensive_stab = 40;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 40;
                    monster_defensive_magic = 600;
                    monster_defensive_range = 800;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Hard mode Pestilent Bloat (moving)":
                case "Hard mode Pestilent Bloat":
                    monster_is_in_tob = true;
                    monster_is_undead = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 2400;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 340;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 180;
                    monster_aggressive_atk = 150;
                    monster_aggressive_str = 82;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 180;
                    monster_aggressive_range_str = 4;
                    monster_defensive_stab = 40;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 40;
                    monster_defensive_magic = 600;
                    monster_defensive_range = 800;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Vasilias (Nylo boss)":
                    monster_is_in_tob = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 2500;
                    monster_combat_atk_lvl = 400;
                    monster_combat_str_lvl = 350;
                    monster_combat_def_lvl = 50;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 350;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 60;
                    monster_aggressive_magic = 600;
                    monster_aggressive_magic_dmg = 600;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 60;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Sotetseg":
                    monster_is_in_tob = true;
                    monster_defence_cap = 100;
                    monster_size = 5;
                    monster_combat_hp_lvl = 4000;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 250;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 48;
                    monster_aggressive_magic = -10;
                    monster_aggressive_magic_dmg = 60;
                    monster_aggressive_range = -10;
                    monster_aggressive_range_str = 60;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = 30;
                    monster_defensive_range = 150;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Hard mode Sotetseg":
                    monster_is_in_tob = true;
                    monster_defence_cap = 100;
                    monster_size = 5;
                    monster_combat_hp_lvl = 4000;
                    monster_combat_atk_lvl = 350;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 250;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 48;
                    monster_aggressive_magic = -10;
                    monster_aggressive_magic_dmg = 60;
                    monster_aggressive_range = -10;
                    monster_aggressive_range_str = 60;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = 30;
                    monster_defensive_range = 150;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Xarpus":
                    monster_is_in_tob = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 5000;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 250;
                    monster_combat_magic_lvl = 220;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 160;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Hard mode Xarpus":
                    monster_is_in_tob = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 6000;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 220;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 160;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Verzik vitur P1":
                    monster_is_in_tob = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 2000;
                    monster_combat_atk_lvl = 400;
                    monster_combat_str_lvl = 340;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 400;
                    monster_combat_range_lvl = 400;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 80;
                    monster_aggressive_magic_dmg = 150;
                    monster_aggressive_range = 80;
                    monster_aggressive_range_str = 80;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 20;
                    monster_defensive_range = 20;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Verzik vitur P2":
                    monster_is_in_tob = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 3250;
                    monster_combat_atk_lvl = 400;
                    monster_combat_str_lvl = 400;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 400;
                    monster_combat_range_lvl = 400;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 80;
                    monster_aggressive_magic_dmg = 80;
                    monster_aggressive_range = 80;
                    monster_aggressive_range_str = 80;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 60;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 70;
                    monster_defensive_range = 250;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Verzik vitur P3":
                    monster_is_in_tob = true;
                    monster_size = 7;
                    monster_combat_hp_lvl = 3250;
                    monster_combat_atk_lvl = 400;
                    monster_combat_str_lvl = 400;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 300;
                    monster_aggressive_atk = 80;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 80;
                    monster_aggressive_magic_dmg = 5;
                    monster_aggressive_range = 80;
                    monster_aggressive_range_str = 5;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 30;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 230;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Ischyros (small melee)":
                    immune_to_mage = true;
                    immune_to_range = true;
                    monster_is_in_tob = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 11;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 160;
                    monster_combat_def_lvl = 1;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 200;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 1073;
                    monster_aggressive_magic_dmg = 928;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = -15;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Ischyros (big melee)":
                    immune_to_mage = true;
                    immune_to_range = true;
                    monster_is_in_tob = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 22;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 230;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 20;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 500;
                    monster_aggressive_magic_dmg = 500;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Toxobolos (small range)":
                    immune_to_melee = true;
                    immune_to_mage = true;
                    monster_is_in_tob = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 11;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 160;
                    monster_combat_def_lvl = 1;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 200;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 1073;
                    monster_aggressive_magic_dmg = 928;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = -15;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Toxobolos (big range)":
                    immune_to_melee = true;
                    immune_to_mage = true;
                    monster_is_in_tob = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 22;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 230;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 20;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 500;
                    monster_aggressive_magic_dmg = 500;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Hagios (small mage)":
                    immune_to_melee = true;
                    immune_to_range = true;
                    monster_is_in_tob = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 11;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 160;
                    monster_combat_def_lvl = 1;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 200;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 1073;
                    monster_aggressive_magic_dmg = 928;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = -15;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Hagios (big mage)":
                    immune_to_melee = true;
                    immune_to_range = true;
                    monster_is_in_tob = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 22;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 230;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 20;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 500;
                    monster_aggressive_magic_dmg = 500;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Matomenos (maiden)":
                    monster_is_in_tob = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Matomenos (verzik)":
                    monster_is_in_tob = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 200;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nylocas Prinkipas (Nylo prince)":
                    monster_is_in_tob = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 400;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 170;
                    monster_combat_def_lvl = 25;
                    monster_combat_magic_lvl = 25;
                    monster_combat_range_lvl = 175;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 300;
                    monster_aggressive_magic_dmg = 300;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 30;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                // toa monsters
                case "Akkha":
                    monster_is_in_toa = true;
                    monster_defence_cap = 70;
                    monster_size = 3;
                    monster_combat_hp_lvl = 400;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 115;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 115;
                    monster_aggressive_magic_dmg = 40;
                    monster_aggressive_range = 115;
                    monster_aggressive_range_str = 40;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 120;
                    monster_defensive_crush = 120;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Akkha's Shadow":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 3;
                    monster_combat_hp_lvl = 70;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 30;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 115;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 115;
                    monster_aggressive_magic_dmg = 40;
                    monster_aggressive_range = 115;
                    monster_aggressive_range_str = 40;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 120;
                    monster_defensive_crush = 120;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Ba-Ba":
                    monster_is_in_toa = true;
                    monster_defence_cap = 60;
                    monster_size = 5;
                    monster_combat_hp_lvl = 380;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 160;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 26;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 80;
                    monster_defensive_slash = 160;
                    monster_defensive_crush = 240;
                    monster_defensive_magic = 280;
                    monster_defensive_range = 200;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Kephri":
                    monster_is_in_toa = true;
                    monster_is_kaplhite = true;
                    monster_defence_cap = 60;
                    monster_size = 5;
                    monster_combat_hp_lvl = 80;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 125;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 125;
                    monster_aggressive_magic_dmg = 50;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 300;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 200;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Zebak":
                    monster_is_in_toa = true;
                    monster_defence_cap = 50;
                    monster_size = 9;
                    monster_combat_hp_lvl = 580;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 70;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 160;
                    monster_aggressive_str = 100;
                    monster_aggressive_magic = 215;
                    monster_aggressive_magic_dmg = 30;
                    monster_aggressive_range = 220;
                    monster_aggressive_range_str = 16;
                    monster_defensive_stab = 160;
                    monster_defensive_slash = 160;
                    monster_defensive_crush = 260;
                    monster_defensive_magic = 200;
                    monster_defensive_range = 110;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Obelisk":
                    monster_is_in_toa = true;
                    monster_defence_cap = 60;
                    monster_size = 3;
                    monster_combat_hp_lvl = 260;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = 50;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Tumeken's Warden P2 (assumes normal npc)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 80;
                    monster_size = 5;
                    monster_combat_hp_lvl = 140;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 190;
                    monster_combat_range_lvl = 190;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 25;
                    monster_aggressive_magic = 225;
                    monster_aggressive_magic_dmg = 12;
                    monster_aggressive_range = 225;
                    monster_aggressive_range_str = 12;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = -30;
                    monster_defensive_range = 70;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Elidinis' Warden P2 (assumes normal npc)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 80;
                    monster_size = 5;
                    monster_combat_hp_lvl = 140;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 190;
                    monster_combat_range_lvl = 190;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 10;
                    monster_aggressive_magic = 225;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 225;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = -30;
                    monster_defensive_range = 70;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Wardens P3":
                    monster_is_in_toa = true;
                    monster_defence_cap = 120;
                    monster_size = 5;
                    monster_combat_hp_lvl = 880;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 40;
                    monster_aggressive_magic = 230;
                    monster_aggressive_magic_dmg = 40;
                    monster_aggressive_range = 300;
                    monster_aggressive_range_str = 40;
                    monster_defensive_stab = 40;
                    monster_defensive_slash = 40;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 20;
                    monster_defensive_range = 20;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Wardens P4":
                    monster_is_in_toa = true;
                    monster_defence_cap = 120;
                    monster_size = 5;
                    monster_combat_hp_lvl = 220;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 180;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 40;
                    monster_aggressive_magic = 230;
                    monster_aggressive_magic_dmg = 40;
                    monster_aggressive_range = 300;
                    monster_aggressive_range_str = 40;
                    monster_defensive_stab = 40;
                    monster_defensive_slash = 40;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 20;
                    monster_defensive_range = 20;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Wardens Core":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 4500;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 0;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Arcane Scarab":
                    monster_is_in_toa = true;
                    monster_is_kaplhite = true;
                    monster_defence_cap = 0;
                    monster_size = 3;
                    monster_combat_hp_lvl = 40;
                    monster_combat_atk_lvl = 75;
                    monster_combat_str_lvl = 80;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 95;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 55;
                    monster_aggressive_magic = 250;
                    monster_aggressive_magic_dmg = 65;
                    monster_aggressive_range = 350;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 15;
                    monster_defensive_slash = 250;
                    monster_defensive_crush = 30;
                    monster_defensive_magic = 75;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Soldier Scarab":
                    monster_is_in_toa = true;
                    monster_is_kaplhite = true;
                    monster_defence_cap = 0;
                    monster_size = 3;
                    monster_combat_hp_lvl = 40;
                    monster_combat_atk_lvl = 75;
                    monster_combat_str_lvl = 80;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 95;
                    monster_aggressive_atk = 100;
                    monster_aggressive_str = 55;
                    monster_aggressive_magic = 250;
                    monster_aggressive_magic_dmg = 65;
                    monster_aggressive_range = 350;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 15;
                    monster_defensive_slash = 250;
                    monster_defensive_crush = 30;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 250;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Spitting Scarab":
                    monster_is_in_toa = true;
                    monster_is_kaplhite = true;
                    monster_defence_cap = 0;
                    monster_size = 3;
                    monster_combat_hp_lvl = 40;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 80;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 95;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 55;
                    monster_aggressive_magic = 250;
                    monster_aggressive_magic_dmg = 65;
                    monster_aggressive_range = 350;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 15;
                    monster_defensive_slash = 250;
                    monster_defensive_crush = 30;
                    monster_defensive_magic = 250;
                    monster_defensive_range = 125;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Brawler (small melee)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 4;
                    monster_combat_atk_lvl = 40;
                    monster_combat_str_lvl = 40;
                    monster_combat_def_lvl = 12;
                    monster_combat_magic_lvl = 40;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 20;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 20;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = -60;
                    monster_defensive_range = 900;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Brawler (big melee)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 6;
                    monster_combat_atk_lvl = 60;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 25;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = -60;
                    monster_defensive_range = 900;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Thrower (small range)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 4;
                    monster_combat_atk_lvl = 40;
                    monster_combat_str_lvl = 40;
                    monster_combat_def_lvl = 12;
                    monster_combat_magic_lvl = 40;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 20;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 20;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = -50;
                    monster_defensive_slash = -50;
                    monster_defensive_crush = -50;
                    monster_defensive_magic = 900;
                    monster_defensive_range = 900;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Thrower (big range)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 6;
                    monster_combat_atk_lvl = 60;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 25;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = -50;
                    monster_defensive_slash = -50;
                    monster_defensive_crush = -50;
                    monster_defensive_magic = 900;
                    monster_defensive_range = 900;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Mage (small mage)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 4;
                    monster_combat_atk_lvl = 40;
                    monster_combat_str_lvl = 40;
                    monster_combat_def_lvl = 12;
                    monster_combat_magic_lvl = 40;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 20;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 20;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = 900;
                    monster_defensive_range = -50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Mage (big mage)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 6;
                    monster_combat_atk_lvl = 60;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 25;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = 900;
                    monster_defensive_range = -50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Shaman":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 16;
                    monster_combat_atk_lvl = 60;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 25;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = 900;
                    monster_defensive_range = -50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon Thrall":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 2;
                    monster_combat_atk_lvl = 40;
                    monster_combat_str_lvl = 40;
                    monster_combat_def_lvl = 12;
                    monster_combat_magic_lvl = 40;
                    monster_combat_range_lvl = 40;
                    monster_aggressive_atk = 20;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 20;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Volatile Baboon":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 8;
                    monster_combat_atk_lvl = 60;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 25;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = -60;
                    monster_defensive_range = -50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Cursed Baboon":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 10;
                    monster_combat_atk_lvl = 60;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 25;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 900;
                    monster_defensive_slash = 900;
                    monster_defensive_crush = 900;
                    monster_defensive_magic = -60;
                    monster_defensive_range = -50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Baboon (Ba-Ba)":
                    monster_is_in_toa = true;
                    monster_defence_cap = 0;
                    monster_size = 1;
                    monster_combat_hp_lvl = 35;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 50;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 80;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 80;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 10;
                    monster_defensive_slash = 50;
                    monster_defensive_crush = 50;
                    monster_defensive_magic = 50;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                // cox monster
                case "Tekton":
                    immune_to_range = true;
                    monster_is_in_cox = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 300;
                    monster_combat_atk_lvl = 390;
                    monster_combat_str_lvl = 390;
                    monster_combat_def_lvl = 205;
                    monster_combat_magic_lvl = 205;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 64;
                    monster_aggressive_str = 20;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 155;
                    monster_defensive_slash = 165;
                    monster_defensive_crush = 105;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Tekton (enraged)":
                    immune_to_range = true;
                    monster_is_in_cox = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 300;
                    monster_combat_atk_lvl = 390;
                    monster_combat_str_lvl = 390;
                    monster_combat_def_lvl = 205;
                    monster_combat_magic_lvl = 205;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 64;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 280;
                    monster_defensive_slash = 290;
                    monster_defensive_crush = 180;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Ice demon":
                    monster_is_in_cox = true;
                    monster_is_demon = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 140;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 160;
                    monster_combat_magic_lvl = 390;
                    monster_combat_range_lvl = 390;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 110;
                    monster_defensive_magic = 60;
                    monster_defensive_range = 140;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Lizardman shaman (CoX)":
                    monster_is_in_cox = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 190;
                    monster_combat_atk_lvl = 130;
                    monster_combat_str_lvl = 130;
                    monster_combat_def_lvl = 210;
                    monster_combat_magic_lvl = 130;
                    monster_combat_range_lvl = 130;
                    monster_aggressive_atk = 58;
                    monster_aggressive_str = 52;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 56;
                    monster_aggressive_range_str = 49;
                    monster_defensive_stab = 102;
                    monster_defensive_slash = 160;
                    monster_defensive_crush = 150;
                    monster_defensive_magic = 160;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vanguard (mage)":
                    monster_is_in_cox = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 180;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 160;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 40;
                    monster_aggressive_magic_dmg = 25;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 315;
                    monster_defensive_slash = 340;
                    monster_defensive_crush = 400;
                    monster_defensive_magic = 110;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vanguard (melee)":
                    monster_is_in_cox = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 180;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 160;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 20;
                    monster_aggressive_str = 10;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 150;
                    monster_defensive_slash = 150;
                    monster_defensive_crush = 150;
                    monster_defensive_magic = 20;
                    monster_defensive_range = 400;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vanguard (range)":
                    monster_is_in_cox = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 180;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 160;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 40;
                    monster_aggressive_range_str = 25;
                    monster_defensive_stab = 55;
                    monster_defensive_slash = 60;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 400;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vespula":
                    monster_is_in_cox = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 200;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 88;
                    monster_combat_magic_lvl = 88;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 70;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Abyssal portal":
                    monster_is_in_cox = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 250;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 176;
                    monster_combat_magic_lvl = 176;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 60;
                    monster_defensive_range = 140;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Deathly ranger":
                    monster_is_in_cox = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 120;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 155;
                    monster_combat_magic_lvl = 155;
                    monster_combat_range_lvl = 210;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 120;
                    monster_aggressive_range_str = 70;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Deathly mage":
                    monster_is_in_cox = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 120;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 155;
                    monster_combat_magic_lvl = 210;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 120;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Guardian":
                    monster_is_in_cox = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 250;
                    monster_combat_atk_lvl = 140;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 20;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 80;
                    monster_defensive_slash = 180;
                    monster_defensive_crush = -10;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vasa Nistirio":
                    monster_is_in_cox = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 300;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 175;
                    monster_combat_magic_lvl = 230;
                    monster_combat_range_lvl = 230;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 100;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 170;
                    monster_defensive_slash = 190;
                    monster_defensive_crush = 50;
                    monster_defensive_magic = 400;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Glowing crystal":
                    immune_to_range = true;
                    monster_is_in_cox = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 120;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = -5;
                    monster_defensive_slash = 180;
                    monster_defensive_crush = 180;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Skeletal Mystic":
                    monster_is_in_cox = true;
                    monster_is_undead = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 160;
                    monster_combat_atk_lvl = 140;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 187;
                    monster_combat_magic_lvl = 140;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 85;
                    monster_aggressive_str = 50;
                    monster_aggressive_magic = 40;
                    monster_aggressive_magic_dmg = 38;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 155;
                    monster_defensive_slash = 155;
                    monster_defensive_crush = 115;
                    monster_defensive_magic = 140;
                    monster_defensive_range = 115;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Muttadile (small)":
                    monster_is_in_cox = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 250;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 138;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 71;
                    monster_aggressive_str = 64;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 83;
                    monster_aggressive_range_str = 75;
                    monster_defensive_stab = -5;
                    monster_defensive_slash = 72;
                    monster_defensive_crush = 50;
                    monster_defensive_magic = 60;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Muttadile (big)":
                    monster_is_in_cox = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 250;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 220;
                    monster_combat_magic_lvl = 250;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 88;
                    monster_aggressive_str = 74;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 82;
                    monster_aggressive_range_str = 63;
                    monster_defensive_stab = -5;
                    monster_defensive_slash = 82;
                    monster_defensive_crush = 60;
                    monster_defensive_magic = 75;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Great olm (head)":
                    monster_is_in_cox = true;
                    monster_is_dragon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 800;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 250;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 60;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 60;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 200;
                    monster_defensive_slash = 200;
                    monster_defensive_crush = 200;
                    monster_defensive_magic = 200;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Great olm (melee hand)":
                    monster_is_in_cox = true;
                    monster_is_dragon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 600;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 175;
                    monster_combat_magic_lvl = 175;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 60;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 60;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 50;
                    monster_defensive_slash = 50;
                    monster_defensive_crush = 50;
                    monster_defensive_magic = 200;
                    monster_defensive_range = 200;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Great olm (mage hand)":
                    monster_is_in_cox = true;
                    monster_is_dragon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 600;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 175;
                    monster_combat_magic_lvl = 87;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 60;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 60;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 200;
                    monster_defensive_slash = 200;
                    monster_defensive_crush = 200;
                    monster_defensive_magic = 50;
                    monster_defensive_range = 200;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Scavenger":
                    monster_is_in_cox = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 30;
                    monster_combat_atk_lvl = 120;
                    monster_combat_str_lvl = 120;
                    monster_combat_def_lvl = 45;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                // fight caves
                case "Tz-Kih (bat)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 10;
                    monster_combat_atk_lvl = 20;
                    monster_combat_str_lvl = 30;
                    monster_combat_def_lvl = 15;
                    monster_combat_magic_lvl = 15;
                    monster_combat_range_lvl = 30;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Tz-Kek (mini blob)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 10;
                    monster_combat_atk_lvl = 20;
                    monster_combat_str_lvl = 30;
                    monster_combat_def_lvl = 15;
                    monster_combat_magic_lvl = 15;
                    monster_combat_range_lvl = 30;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Tz-Kek (big blob)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 20;
                    monster_combat_atk_lvl = 40;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 30;
                    monster_combat_magic_lvl = 30;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Tok-Xil (range)":
                    monster_size = 3;
                    monster_combat_hp_lvl = 40;
                    monster_combat_atk_lvl = 80;
                    monster_combat_str_lvl = 120;
                    monster_combat_def_lvl = 60;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Yt-MejKot (melee)":
                    monster_size = 4;
                    monster_combat_hp_lvl = 80;
                    monster_combat_atk_lvl = 160;
                    monster_combat_str_lvl = 240;
                    monster_combat_def_lvl = 120;
                    monster_combat_magic_lvl = 120;
                    monster_combat_range_lvl = 240;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Ket-Zek (mage)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 160;
                    monster_combat_atk_lvl = 320;
                    monster_combat_str_lvl = 480;
                    monster_combat_def_lvl = 240;
                    monster_combat_magic_lvl = 240;
                    monster_combat_range_lvl = 480;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 60;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "TzTok-Jad":
                    monster_size = 5;
                    monster_combat_hp_lvl = 250;
                    monster_combat_atk_lvl = 640;
                    monster_combat_str_lvl = 960;
                    monster_combat_def_lvl = 480;
                    monster_combat_magic_lvl = 480;
                    monster_combat_range_lvl = 960;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 60;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Yt-HurKot (healer)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 60;
                    monster_combat_atk_lvl = 140;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 60;
                    monster_combat_magic_lvl = 120;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                // inferno
                case "Jal-Nib (nibbler)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 10;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 15;
                    monster_combat_magic_lvl = 15;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = -20;
                    monster_defensive_slash = -20;
                    monster_defensive_crush = -20;
                    monster_defensive_magic = -20;
                    monster_defensive_range = -20;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-MejRah (bat)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 25;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 55;
                    monster_combat_magic_lvl = 120;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 30;
                    monster_defensive_slash = 30;
                    monster_defensive_crush = 30;
                    monster_defensive_magic = -20;
                    monster_defensive_range = 45;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-AkRek-Ket (melee blob)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 15;
                    monster_combat_atk_lvl = 120;
                    monster_combat_str_lvl = 120;
                    monster_combat_def_lvl = 95;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 25;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 25;
                    monster_defensive_slash = 25;
                    monster_defensive_crush = 25;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-AkRek-Mej (mage blob)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 15;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 95;
                    monster_combat_magic_lvl = 120;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 25;
                    monster_aggressive_magic_dmg = 25;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 25;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-AkRek-Xil (range blob)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 15;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 95;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 25;
                    monster_aggressive_range_str = 25;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 25;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-Ak (blob)":
                    monster_size = 3;
                    monster_combat_hp_lvl = 40;
                    monster_combat_atk_lvl = 160;
                    monster_combat_str_lvl = 160;
                    monster_combat_def_lvl = 95;
                    monster_combat_magic_lvl = 160;
                    monster_combat_range_lvl = 160;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 45;
                    monster_aggressive_magic = 45;
                    monster_aggressive_magic_dmg = 45;
                    monster_aggressive_range = 45;
                    monster_aggressive_range_str = 45;
                    monster_defensive_stab = 25;
                    monster_defensive_slash = 25;
                    monster_defensive_crush = 25;
                    monster_defensive_magic = 25;
                    monster_defensive_range = 25;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-ImKot (melee)":
                    monster_size = 4;
                    monster_combat_hp_lvl = 75;
                    monster_combat_atk_lvl = 210;
                    monster_combat_str_lvl = 290;
                    monster_combat_def_lvl = 120;
                    monster_combat_magic_lvl = 120;
                    monster_combat_range_lvl = 220;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 40;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 65;
                    monster_defensive_slash = 65;
                    monster_defensive_crush = 65;
                    monster_defensive_magic = 30;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-Xil (range)":
                    monster_size = 3;
                    monster_combat_hp_lvl = 125;
                    monster_combat_atk_lvl = 140;
                    monster_combat_str_lvl = 180;
                    monster_combat_def_lvl = 60;
                    monster_combat_magic_lvl = 90;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 40;
                    monster_aggressive_range_str = 50;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-Zek (mage)":
                    monster_size = 4;
                    monster_combat_hp_lvl = 220;
                    monster_combat_atk_lvl = 370;
                    monster_combat_str_lvl = 510;
                    monster_combat_def_lvl = 260;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 510;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 80;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "JalTok-Jad":
                    monster_size = 5;
                    monster_combat_hp_lvl = 350;
                    monster_combat_atk_lvl = 750;
                    monster_combat_str_lvl = 1020;
                    monster_combat_def_lvl = 480;
                    monster_combat_magic_lvl = 510;
                    monster_combat_range_lvl = 1020;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 100;
                    monster_aggressive_magic_dmg = 75;
                    monster_aggressive_range = 80;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Yt-HurKot (inferno jad healer)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 90;
                    monster_combat_atk_lvl = 165;
                    monster_combat_str_lvl = 125;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 100;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 80;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 130;
                    monster_defensive_range = 130;

                    Dispatcher.Invoke(Stats);
                    break;
                case "TzKal-Zuk":
                    monster_size = 7;
                    monster_combat_hp_lvl = 1200;
                    monster_combat_atk_lvl = 350;
                    monster_combat_str_lvl = 600;
                    monster_combat_def_lvl = 260;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 400;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 200;
                    monster_aggressive_magic = 550;
                    monster_aggressive_magic_dmg = 450;
                    monster_aggressive_range = 550;
                    monster_aggressive_range_str = 200;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 350;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Jal-MejJak (zuk healer)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 75;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                // nightmare
                case "Nightmare":
                    monster_defence_cap = 120;
                    monster_size = 5;
                    monster_combat_hp_lvl = 2000;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 140;
                    monster_aggressive_str = 128;
                    monster_aggressive_magic = 140;
                    monster_aggressive_magic_dmg = 64;
                    monster_aggressive_range = 140;
                    monster_aggressive_range_str = 64;
                    monster_defensive_stab = 120;
                    monster_defensive_slash = 180;
                    monster_defensive_crush = 40;
                    monster_defensive_magic = 600;
                    monster_defensive_range = 600;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phosani's Nightmare":
                    monster_defence_cap = 120;
                    monster_size = 5;
                    monster_combat_hp_lvl = 400;
                    monster_combat_atk_lvl = 150;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 220;
                    monster_aggressive_str = 274;
                    monster_aggressive_magic = 220;
                    monster_aggressive_magic_dmg = 162;
                    monster_aggressive_range = 220;
                    monster_aggressive_range_str = 162;
                    monster_defensive_stab = 120;
                    monster_defensive_slash = 180;
                    monster_defensive_crush = 40;
                    monster_defensive_magic = 600;
                    monster_defensive_range = 600;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phosani's Husk (range)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 20;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 80;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 168;
                    monster_aggressive_range_str = 82;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 80;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phosani's Husk (mage)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 20;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 80;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 168;
                    monster_aggressive_magic_dmg = 82;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 80;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Husk":
                    monster_size = 1;
                    monster_combat_hp_lvl = 20;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 20;
                    monster_combat_magic_lvl = 80;
                    monster_combat_range_lvl = 80;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 80;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phosani's Parasite":
                    monster_size = 1;
                    monster_combat_hp_lvl = 80;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 60;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 84;
                    monster_aggressive_magic_dmg = 102;
                    monster_aggressive_range = 85;
                    monster_aggressive_range_str = 102;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 80;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 120;
                    monster_defensive_range = 120;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phosani's Parasite (weakened)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 55;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 40;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 44;
                    monster_aggressive_magic_dmg = 62;
                    monster_aggressive_range = 44;
                    monster_aggressive_range_str = 62;
                    monster_defensive_stab = 50;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Parasite":
                    monster_size = 1;
                    monster_combat_hp_lvl = 80;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 60;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 20;
                    monster_aggressive_magic_dmg = 46;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 46;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 80;
                    monster_defensive_crush = 20;
                    monster_defensive_magic = 120;
                    monster_defensive_range = 120;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Parasite (weakened)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 40;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 40;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 60;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 12;
                    monster_aggressive_magic_dmg = 26;
                    monster_aggressive_range = 12;
                    monster_aggressive_range_str = 26;
                    monster_defensive_stab = 50;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Sleepwalker":
                    monster_size = 1;
                    monster_combat_hp_lvl = 10;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 0;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = -100;
                    monster_defensive_slash = -100;
                    monster_defensive_crush = -100;
                    monster_defensive_magic = -100;
                    monster_defensive_range = -100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phosani's Totem":
                    monster_size = 3;
                    monster_combat_hp_lvl = 200;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 0;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Totem":
                    monster_size = 3;
                    monster_combat_hp_lvl = 300;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 0;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                // gwd bosses
                case "General Graardor":
                    monster_size = 4;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 350;
                    monster_combat_def_lvl = 250;
                    monster_combat_magic_lvl = 80;
                    monster_combat_range_lvl = 350;
                    monster_aggressive_atk = 120;
                    monster_aggressive_str = 43;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 100;
                    monster_aggressive_range_str = 40;
                    monster_defensive_stab = 90;
                    monster_defensive_slash = 90;
                    monster_defensive_crush = 90;
                    monster_defensive_magic = 298;
                    monster_defensive_range = 90;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Kree'arra":
                    monster_size = 5;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 200;
                    monster_combat_def_lvl = 260;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 380;
                    monster_aggressive_atk = 136;
                    monster_aggressive_str = 12;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 120;
                    monster_aggressive_range_str = 50;
                    monster_defensive_stab = 180;
                    monster_defensive_slash = 180;
                    monster_defensive_crush = 180;
                    monster_defensive_magic = 200;
                    monster_defensive_range = 200;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Commander Zilyana":
                    monster_size = 2;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 196;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 195;
                    monster_aggressive_str = 20;
                    monster_aggressive_magic = 200;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "K'ril Tsutsaroth":
                    monster_is_demon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 340;
                    monster_combat_str_lvl = 300;
                    monster_combat_def_lvl = 270;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 160;
                    monster_aggressive_str = 31;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 80;
                    monster_defensive_slash = 80;
                    monster_defensive_crush = 80;
                    monster_defensive_magic = 130;
                    monster_defensive_range = 80;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Nex":
                    monster_size = 3;
                    monster_combat_hp_lvl = 3400;
                    monster_combat_atk_lvl = 315;
                    monster_combat_str_lvl = 200;
                    monster_combat_def_lvl = 260;
                    monster_combat_magic_lvl = 230;
                    monster_combat_range_lvl = 350;
                    monster_aggressive_atk = 200;
                    monster_aggressive_str = 20;
                    monster_aggressive_magic = 100;
                    monster_aggressive_magic_dmg = 22;
                    monster_aggressive_range = 150;
                    monster_aggressive_range_str = 5;
                    monster_defensive_stab = 40;
                    monster_defensive_slash = 140;
                    monster_defensive_crush = 60;
                    monster_defensive_magic = 300;
                    monster_defensive_range = 190;

                    Dispatcher.Invoke(Stats);
                    break;
                // gwd body guards
                case "Sergeant Strongstack (melee)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 128;
                    monster_combat_atk_lvl = 124;
                    monster_combat_str_lvl = 118;
                    monster_combat_def_lvl = 125;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 50;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 14;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Sergeant Steelwill (mage)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 127;
                    monster_combat_atk_lvl = 80;
                    monster_combat_str_lvl = 50;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 6;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Sergeant Grimspike (range)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 146;
                    monster_combat_atk_lvl = 80;
                    monster_combat_str_lvl = 80;
                    monster_combat_def_lvl = 132;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Flight Kilisa (melee)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 133;
                    monster_combat_atk_lvl = 124;
                    monster_combat_str_lvl = 118;
                    monster_combat_def_lvl = 175;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 169;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 14;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Wingman Skree (mage)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 121;
                    monster_combat_atk_lvl = 80;
                    monster_combat_str_lvl = 50;
                    monster_combat_def_lvl = 160;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 45;
                    monster_aggressive_str = 25;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Flockleader Geerin (range)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 132;
                    monster_combat_atk_lvl = 80;
                    monster_combat_str_lvl = 80;
                    monster_combat_def_lvl = 175;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 60;
                    monster_aggressive_range_str = 35;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Starlight (melee)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 160;
                    monster_combat_atk_lvl = 120;
                    monster_combat_str_lvl = 125;
                    monster_combat_def_lvl = 120;
                    monster_combat_magic_lvl = 125;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 60;
                    monster_aggressive_str = 10;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 12;
                    monster_defensive_slash = 14;
                    monster_defensive_crush = 13;
                    monster_defensive_magic = 5;
                    monster_defensive_range = 13;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Growler (mage)":
                    monster_size = 3;
                    monster_combat_hp_lvl = 146;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 101;
                    monster_combat_def_lvl = 120;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 10;
                    monster_aggressive_str = 7;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 12;
                    monster_defensive_slash = 14;
                    monster_defensive_crush = 14;
                    monster_defensive_magic = 18;
                    monster_defensive_range = 5;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Bree (range)":
                    monster_size = 2;
                    monster_combat_hp_lvl = 162;
                    monster_combat_atk_lvl = 110;
                    monster_combat_str_lvl = 80;
                    monster_combat_def_lvl = 130;
                    monster_combat_magic_lvl = 80;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 10;
                    monster_aggressive_str = 7;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 12;
                    monster_defensive_slash = 14;
                    monster_defensive_crush = 14;
                    monster_defensive_magic = 18;
                    monster_defensive_range = 5;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Tstanon Karlak (melee)":
                    monster_is_demon = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 142;
                    monster_combat_atk_lvl = 124;
                    monster_combat_str_lvl = 118;
                    monster_combat_def_lvl = 125;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 50;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 14;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = -5;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Balfrug Kreeyath (mage)":
                    monster_is_demon = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 161;
                    monster_combat_atk_lvl = 115;
                    monster_combat_str_lvl = 60;
                    monster_combat_def_lvl = 153;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Zakl'n Gritch (range)":
                    monster_is_demon = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 150;
                    monster_combat_atk_lvl = 83;
                    monster_combat_str_lvl = 76;
                    monster_combat_def_lvl = 127;
                    monster_combat_magic_lvl = 50;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 20;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = -5;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Fumus (smoke)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 25;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 25;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Umbra (shadow)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 25;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 25;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Cruor (blood)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 25;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 25;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Glacies (ice)":
                    monster_size = 1;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 25;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 25;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Blood Reaver (nex)":
                    monster_is_demon = true;
                    monster_size = 2;
                    monster_combat_hp_lvl = 150;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 190;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 80;
                    monster_defensive_crush = 120;
                    monster_defensive_magic = 300;
                    monster_defensive_range = 55;

                    Dispatcher.Invoke(Stats);
                    break;
                // slayer monsters
                case "Grotesque Guardians (dusk 1st form)":
                    immune_to_mage = true;
                    immune_to_range = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 450;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 140;
                    monster_combat_range_lvl = 140;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Grotesque Guardians (dusk 2nd form)":
                    immune_to_mage = true;
                    immune_to_range = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 450;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 250;
                    monster_combat_range_lvl = 250;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Grotesque Guardians (dawn)":
                    monster_size = 4;
                    monster_combat_hp_lvl = 450;
                    monster_combat_atk_lvl = 140;
                    monster_combat_str_lvl = 140;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 140;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Abyssal Sire P1-P3":
                    monster_is_demon = true;
                    monster_size = 6;
                    monster_combat_hp_lvl = 400;
                    monster_combat_atk_lvl = 180;
                    monster_combat_str_lvl = 136;
                    monster_combat_def_lvl = 250;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 65;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 40;
                    monster_defensive_slash = 60;
                    monster_defensive_crush = 50;
                    monster_defensive_magic = 20;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Abyssal Sire P4":
                    monster_is_demon = true;
                    monster_size = 6;
                    monster_combat_hp_lvl = 400;
                    monster_combat_atk_lvl = 180;
                    monster_combat_str_lvl = 136;
                    monster_combat_def_lvl = 250;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 65;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 30;
                    monster_defensive_crush = 25;
                    monster_defensive_magic = -40;
                    monster_defensive_range = 30;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Respiratory system":
                    monster_size = 2;
                    monster_combat_hp_lvl = 50;
                    monster_combat_atk_lvl = 0;
                    monster_combat_str_lvl = 0;
                    monster_combat_def_lvl = 80;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Kraken":
                    monster_size = 4;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 1;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 50;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 130;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Cerberus":
                    monster_is_demon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 600;
                    monster_combat_atk_lvl = 220;
                    monster_combat_str_lvl = 220;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 220;
                    monster_combat_range_lvl = 220;
                    monster_aggressive_atk = 50;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 50;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 50;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 50;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 25;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Thermonuclear smoke devil":
                    monster_size = 4;
                    monster_combat_hp_lvl = 240;
                    monster_combat_atk_lvl = 230;
                    monster_combat_str_lvl = 220;
                    monster_combat_def_lvl = 360;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 310;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 11;
                    monster_defensive_slash = 4;
                    monster_defensive_crush = 9;
                    monster_defensive_magic = 800;
                    monster_defensive_range = 900;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Alchemical Hydra (not weakened)":
                case "Alchemical Hydra":
                    monster_is_dragon = true;
                    monster_size = 6;
                    monster_combat_hp_lvl = 1100;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 260;
                    monster_combat_range_lvl = 260;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 45;
                    monster_aggressive_magic_dmg = 20;
                    monster_aggressive_range = 45;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 75;
                    monster_defensive_slash = 150;
                    monster_defensive_crush = 150;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 45;

                    Dispatcher.Invoke(Stats);
                    break;
                // wilderness bosses
                case "Callisto":
                    monster_is_in_wilderness = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 1000;
                    monster_combat_atk_lvl = 350;
                    monster_combat_str_lvl = 300;
                    monster_combat_def_lvl = 225;
                    monster_combat_magic_lvl = 140;
                    monster_combat_range_lvl = 200;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 100;
                    monster_aggressive_range_str = 30;
                    monster_defensive_stab = 150;
                    monster_defensive_slash = 130;
                    monster_defensive_crush = 125;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Artio":
                    monster_is_in_wilderness = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 450;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 270;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 90;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 60;
                    monster_aggressive_range_str = 18;
                    monster_defensive_stab = 125;
                    monster_defensive_slash = 110;
                    monster_defensive_crush = 110;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vet'ion":
                    monster_is_in_wilderness = true;
                    monster_is_undead = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 430;
                    monster_combat_str_lvl = 430;
                    monster_combat_def_lvl = 395;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 201;
                    monster_defensive_slash = 200;
                    monster_defensive_crush = -10;
                    monster_defensive_magic = 250;
                    monster_defensive_range = 270;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Calvar'ion":
                    monster_is_in_wilderness = true;
                    monster_is_undead = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 150;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 225;
                    monster_combat_magic_lvl = 178;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 130;
                    monster_defensive_slash = 128;
                    monster_defensive_crush = -10;
                    monster_defensive_magic = 198;
                    monster_defensive_range = 211;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Venenatis":
                    monster_is_in_wilderness = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 850;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 200;
                    monster_combat_def_lvl = 321;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 350;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 300;
                    monster_defensive_range = 150;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Spindel":
                    monster_is_in_wilderness = true;
                    monster_size = 4;
                    monster_combat_hp_lvl = 515;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 130;
                    monster_combat_def_lvl = 225;
                    monster_combat_magic_lvl = 235;
                    monster_combat_range_lvl = 286;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 205;
                    monster_defensive_range = 103;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Chaos Elemental":
                    monster_is_in_wilderness = true;
                    monster_size = 3;
                    monster_combat_hp_lvl = 250;
                    monster_combat_atk_lvl = 270;
                    monster_combat_str_lvl = 270;
                    monster_combat_def_lvl = 270;
                    monster_combat_magic_lvl = 270;
                    monster_combat_range_lvl = 270;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 70;
                    monster_defensive_crush = 70;
                    monster_defensive_magic = 70;
                    monster_defensive_range = 70;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Chaos Fanatic":
                    monster_is_in_wilderness = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 225;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 220;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 75;
                    monster_aggressive_range_str = -20;
                    monster_defensive_stab = 260;
                    monster_defensive_slash = 260;
                    monster_defensive_crush = 250;
                    monster_defensive_magic = 280;
                    monster_defensive_range = 80;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Crazy archaeologist":
                    monster_is_in_wilderness = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 225;
                    monster_combat_atk_lvl = 160;
                    monster_combat_str_lvl = 90;
                    monster_combat_def_lvl = 240;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 180;
                    monster_aggressive_atk = 250;
                    monster_aggressive_str = 25;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 75;
                    monster_aggressive_range_str = -15;
                    monster_defensive_stab = 5;
                    monster_defensive_slash = 5;
                    monster_defensive_crush = 30;
                    monster_defensive_magic = 250;
                    monster_defensive_range = 250;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Scorpia":
                    monster_is_in_wilderness = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 200;
                    monster_combat_atk_lvl = 250;
                    monster_combat_str_lvl = 150;
                    monster_combat_def_lvl = 180;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 60;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 246;
                    monster_defensive_slash = 284;
                    monster_defensive_crush = 284;
                    monster_defensive_magic = 44;
                    monster_defensive_range = 284;

                    Dispatcher.Invoke(Stats);
                    break;
                case "King Black Dragon":
                    monster_is_dragon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 240;
                    monster_combat_atk_lvl = 240;
                    monster_combat_str_lvl = 240;
                    monster_combat_def_lvl = 240;
                    monster_combat_magic_lvl = 240;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 70;
                    monster_defensive_slash = 90;
                    monster_defensive_crush = 90;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 70;

                    Dispatcher.Invoke(Stats);
                    break;
                // dks 
                case "Dagannoth Rex":
                    monster_size = 3;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 255;
                    monster_combat_str_lvl = 255;
                    monster_combat_def_lvl = 225;
                    monster_combat_magic_lvl = 0;
                    monster_combat_range_lvl = 255;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 255;
                    monster_defensive_slash = 255;
                    monster_defensive_crush = 255;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 255;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Dagannoth Prime":
                    monster_size = 3;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 255;
                    monster_combat_str_lvl = 255;
                    monster_combat_def_lvl = 225;
                    monster_combat_magic_lvl = 255;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 255;
                    monster_defensive_slash = 255;
                    monster_defensive_crush = 255;
                    monster_defensive_magic = 255;
                    monster_defensive_range = 10;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Dagannoth Supreme":
                    monster_size = 3;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 255;
                    monster_combat_str_lvl = 255;
                    monster_combat_def_lvl = 128;
                    monster_combat_magic_lvl = 255;
                    monster_combat_range_lvl = 255;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 10;
                    monster_defensive_slash = 10;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 255;
                    monster_defensive_range = 550;

                    Dispatcher.Invoke(Stats);
                    break;
                // barrows
                case "Ahrim the Blighted":
                    monster_size = 1;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 100;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 68;
                    monster_aggressive_magic = 73;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = -19;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 103;
                    monster_defensive_slash = 85;
                    monster_defensive_crush = 117;
                    monster_defensive_magic = 73;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Dharok the Wretched":
                    monster_size = 1;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 105;
                    monster_aggressive_magic = -58;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = -18;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 252;
                    monster_defensive_slash = 250;
                    monster_defensive_crush = 244;
                    monster_defensive_magic = -11;
                    monster_defensive_range = 249;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Guthan the Infested":
                    monster_size = 1;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 75;
                    monster_aggressive_magic = -50;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = -19;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 259;
                    monster_defensive_slash = 257;
                    monster_defensive_crush = 241;
                    monster_defensive_magic = -11;
                    monster_defensive_range = 250;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Karil the Tainted":
                    monster_size = 1;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 100;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = -26;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 134;
                    monster_aggressive_range_str = 55;
                    monster_defensive_stab = 79;
                    monster_defensive_slash = 71;
                    monster_defensive_crush = 90;
                    monster_defensive_magic = 106;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Torag the Corrupted":
                    monster_size = 1;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 72;
                    monster_aggressive_magic = -33;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = -11;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 221;
                    monster_defensive_slash = 235;
                    monster_defensive_crush = 222;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 221;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Verac the Defiled":
                    monster_size = 1;
                    monster_combat_hp_lvl = 100;
                    monster_combat_atk_lvl = 100;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 72;
                    monster_aggressive_magic = -42;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = -14;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 227;
                    monster_defensive_slash = 230;
                    monster_defensive_crush = 221;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 225;

                    Dispatcher.Invoke(Stats);
                    break;
                // mics bosses
                case "Giant Mole":
                    monster_size = 3;
                    monster_combat_hp_lvl = 200;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 200;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 200;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 80;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 60;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Deranged archaeologist":
                    monster_size = 1;
                    monster_combat_hp_lvl = 200;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 160;
                    monster_combat_def_lvl = 280;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 320;
                    monster_aggressive_atk = 280;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 90;
                    monster_aggressive_range_str = -10;
                    monster_defensive_stab = 20;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 50;
                    monster_defensive_magic = 300;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Sarachnis":
                    monster_size = 5;
                    monster_combat_hp_lvl = 400;
                    monster_combat_atk_lvl = 200;
                    monster_combat_str_lvl = 240;
                    monster_combat_def_lvl = 150;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 300;
                    monster_aggressive_atk = 30;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 15;
                    monster_aggressive_range_str = 15;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 40;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Kalphite Queen P1":
                    monster_is_kaplhite = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 300;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 50;
                    monster_defensive_slash = 50;
                    monster_defensive_crush = 10;
                    monster_defensive_magic = 100;
                    monster_defensive_range = 100;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Kalphite Queen P2":
                    monster_is_kaplhite = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 255;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 300;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 100;
                    monster_defensive_slash = 100;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 10;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Corporeal Beast":
                    monster_size = 5;
                    monster_combat_hp_lvl = 2000;
                    monster_combat_atk_lvl = 320;
                    monster_combat_str_lvl = 320;
                    monster_combat_def_lvl = 310;
                    monster_combat_magic_lvl = 350;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 50;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 25;
                    monster_defensive_slash = 200;
                    monster_defensive_crush = 100;
                    monster_defensive_magic = 150;
                    monster_defensive_range = 230;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Obor":
                    monster_size = 2;
                    monster_combat_hp_lvl = 120;
                    monster_combat_atk_lvl = 90;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 60;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 120;
                    monster_aggressive_atk = 100;
                    monster_aggressive_str = 68;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 100;
                    monster_aggressive_range_str = 65;
                    monster_defensive_stab = 35;
                    monster_defensive_slash = 40;
                    monster_defensive_crush = 45;
                    monster_defensive_magic = 20;
                    monster_defensive_range = 20;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Bryophyta":
                    monster_size = 3;
                    monster_combat_hp_lvl = 115;
                    monster_combat_atk_lvl = 130;
                    monster_combat_str_lvl = 100;
                    monster_combat_def_lvl = 100;
                    monster_combat_magic_lvl = 90;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 33;
                    monster_aggressive_str = 31;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "The Mimic":
                    monster_size = 5;
                    monster_combat_hp_lvl = 230;
                    monster_combat_atk_lvl = 185;
                    monster_combat_str_lvl = 120;
                    monster_combat_def_lvl = 120;
                    monster_combat_magic_lvl = 60;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 135;
                    monster_aggressive_str = 48;
                    monster_aggressive_magic = 180;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 160;
                    monster_defensive_slash = 165;
                    monster_defensive_crush = 150;
                    monster_defensive_magic = 30;
                    monster_defensive_range = 145;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Hespori":
                    monster_size = 3;
                    monster_combat_hp_lvl = 300;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 120;
                    monster_combat_magic_lvl = 126;
                    monster_combat_range_lvl = 150;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 150;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 150;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 60;
                    monster_defensive_slash = 20;
                    monster_defensive_crush = 60;
                    monster_defensive_magic = 80;
                    monster_defensive_range = 80;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Skotizo":
                    monster_is_demon = true;
                    monster_size = 5;
                    monster_combat_hp_lvl = 450;
                    monster_combat_atk_lvl = 240;
                    monster_combat_str_lvl = 250;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 280;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 160;
                    monster_aggressive_str = 31;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 80;
                    monster_defensive_slash = 80;
                    monster_defensive_crush = 80;
                    monster_defensive_magic = 130;
                    monster_defensive_range = 130;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vorkath":
                case "Vorkath (Quickfire Barrage)":
                    monster_is_dragon = true;
                    monster_is_undead = true;
                    monster_size = 7;
                    monster_combat_hp_lvl = 750;
                    monster_combat_atk_lvl = 560;
                    monster_combat_str_lvl = 308;
                    monster_combat_def_lvl = 214;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 308;
                    monster_aggressive_atk = 16;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 150;
                    monster_aggressive_magic_dmg = 56;
                    monster_aggressive_range = 78;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 26;
                    monster_defensive_slash = 108;
                    monster_defensive_crush = 108;
                    monster_defensive_magic = 240;
                    monster_defensive_range = 26;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Zombified Spawn":
                    monster_is_undead = true;
                    monster_size = 1;
                    monster_combat_hp_lvl = 38;
                    monster_combat_atk_lvl = 82;
                    monster_combat_str_lvl = 82;
                    monster_combat_def_lvl = 6;
                    monster_combat_magic_lvl = 1;
                    monster_combat_range_lvl = 1;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 3;
                    monster_defensive_slash = 3;
                    monster_defensive_crush = 3;
                    monster_defensive_magic = -100;
                    monster_defensive_range = 3;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Zulrah (Serpentine range)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 300;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 50;
                    monster_aggressive_magic_dmg = 20;
                    monster_aggressive_range = 50;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = -45;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Zulrah (Magma melee)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 300;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 50;
                    monster_aggressive_magic_dmg = 20;
                    monster_aggressive_range = 50;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 0;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Zulrah (Tanzanite mage)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 500;
                    monster_combat_atk_lvl = 1;
                    monster_combat_str_lvl = 1;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 300;
                    monster_combat_range_lvl = 300;
                    monster_aggressive_atk = 0;
                    monster_aggressive_str = 0;
                    monster_aggressive_magic = 50;
                    monster_aggressive_magic_dmg = 20;
                    monster_aggressive_range = 50;
                    monster_aggressive_range_str = 20;
                    monster_defensive_stab = 0;
                    monster_defensive_slash = 0;
                    monster_defensive_crush = 0;
                    monster_defensive_magic = 300;
                    monster_defensive_range = 0;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phantom Muspah (Teleporting)":
                case "Phantom Muspah (Ranged)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 850;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 280;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 280;
                    monster_aggressive_atk = 393;
                    monster_aggressive_str = 11;
                    monster_aggressive_magic = 280;
                    monster_aggressive_magic_dmg = 180;
                    monster_aggressive_range = 64;
                    monster_aggressive_range_str = 6;
                    monster_defensive_stab = 185;
                    monster_defensive_slash = 134;
                    monster_defensive_crush = 120;
                    monster_defensive_magic = 437;
                    monster_defensive_range = 56;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phantom Muspah (Melee)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 850;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 280;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 150;
                    monster_combat_range_lvl = 280;
                    monster_aggressive_atk = 393;
                    monster_aggressive_str = 11;
                    monster_aggressive_magic = 280;
                    monster_aggressive_magic_dmg = 180;
                    monster_aggressive_range = 64;
                    monster_aggressive_range_str = 6;
                    monster_defensive_stab = 185;
                    monster_defensive_slash = 134;
                    monster_defensive_crush = 120;
                    monster_defensive_magic = 40;
                    monster_defensive_range = 261;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Phantom Muspah (Post-shield)":
                    monster_size = 5;
                    monster_combat_hp_lvl = 850;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 280;
                    monster_combat_def_lvl = 200;
                    monster_combat_magic_lvl = 179;
                    monster_combat_range_lvl = 335;
                    monster_aggressive_atk = 393;
                    monster_aggressive_str = 11;
                    monster_aggressive_magic = 280;
                    monster_aggressive_magic_dmg = 180;
                    monster_aggressive_range = 64;
                    monster_aggressive_range_str = 6;
                    monster_defensive_stab = 185;
                    monster_defensive_slash = 134;
                    monster_defensive_crush = 120;
                    monster_defensive_magic = 437;
                    monster_defensive_range = 56;

                    Dispatcher.Invoke(Stats);
                    break;
                // DT 2 bosses
                case "Leviathan (During special)":
                case "Leviathan":
                    monster_size = 7;
                    monster_combat_hp_lvl = 900;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 360;
                    monster_combat_def_lvl = 250;
                    monster_combat_magic_lvl = 160;
                    monster_combat_range_lvl = 160;
                    monster_aggressive_atk = 200;
                    monster_aggressive_str = 22;
                    monster_aggressive_magic = 160;
                    monster_aggressive_magic_dmg = 58;
                    monster_aggressive_range = 300;
                    monster_aggressive_range_str = 26;
                    monster_defensive_stab = 260;
                    monster_defensive_slash = 190;
                    monster_defensive_crush = 230;
                    monster_defensive_magic = 280;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Vardorvis":
                    monster_size = 2;
                    monster_combat_hp_lvl = 700;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 270;
                    monster_combat_def_lvl = 215;
                    monster_combat_magic_lvl = 215;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 190;
                    monster_aggressive_str = 10;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 215;
                    monster_defensive_slash = 65;
                    monster_defensive_crush = 85;
                    monster_defensive_magic = 580;
                    monster_defensive_range = 580;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Duke Sucellus":
                    monster_defence_cap = 150;
                    monster_is_demon = true;
                    monster_size = 7;
                    monster_combat_hp_lvl = 440;
                    monster_combat_atk_lvl = 300;
                    monster_combat_str_lvl = 345;
                    monster_combat_def_lvl = 275;
                    monster_combat_magic_lvl = 310;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 200;
                    monster_aggressive_str = 38;
                    monster_aggressive_magic = 150;
                    monster_aggressive_magic_dmg = 32;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 255;
                    monster_defensive_slash = 65;
                    monster_defensive_crush = 190;
                    monster_defensive_magic = 440;
                    monster_defensive_range = 320;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Whisperer":
                    monster_size = 3;
                    monster_combat_hp_lvl = 900;
                    monster_combat_atk_lvl = 280;
                    monster_combat_str_lvl = 280;
                    monster_combat_def_lvl = 250;
                    monster_combat_magic_lvl = 180;
                    monster_combat_range_lvl = 180;
                    monster_aggressive_atk = 140;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 190;
                    monster_aggressive_magic_dmg = 58;
                    monster_aggressive_range = 160;
                    monster_aggressive_range_str = 70;
                    monster_defensive_stab = 180;
                    monster_defensive_slash = 300;
                    monster_defensive_crush = 220;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Awakened Leviathan (During special)":
                case "Awakened Leviathan":
                    monster_size = 7;
                    monster_combat_hp_lvl = 2700;
                    monster_combat_atk_lvl = 525;
                    monster_combat_str_lvl = 630;
                    monster_combat_def_lvl = 287;
                    monster_combat_magic_lvl = 280;
                    monster_combat_range_lvl = 280;
                    monster_aggressive_atk = 200;
                    monster_aggressive_str = 22;
                    monster_aggressive_magic = 160;
                    monster_aggressive_magic_dmg = 58;
                    monster_aggressive_range = 300;
                    monster_aggressive_range_str = 26;
                    monster_defensive_stab = 260;
                    monster_defensive_slash = 190;
                    monster_defensive_crush = 230;
                    monster_defensive_magic = 280;
                    monster_defensive_range = 50;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Awakened Vardorvis":
                    monster_size = 2;
                    monster_combat_hp_lvl = 1400;
                    monster_combat_atk_lvl = 420;
                    monster_combat_str_lvl = 391;
                    monster_combat_def_lvl = 268;
                    monster_combat_magic_lvl = 215;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 190;
                    monster_aggressive_str = 10;
                    monster_aggressive_magic = 0;
                    monster_aggressive_magic_dmg = 0;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 215;
                    monster_defensive_slash = 65;
                    monster_defensive_crush = 85;
                    monster_defensive_magic = 580;
                    monster_defensive_range = 580;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Awakened Duke Sucellus":
                    monster_is_demon = true;
                    monster_size = 7;
                    monster_combat_hp_lvl = 1540;
                    monster_combat_atk_lvl = 435;
                    monster_combat_str_lvl = 500;
                    monster_combat_def_lvl = 316;
                    monster_combat_magic_lvl = 465;
                    monster_combat_range_lvl = 0;
                    monster_aggressive_atk = 200;
                    monster_aggressive_str = 38;
                    monster_aggressive_magic = 150;
                    monster_aggressive_magic_dmg = 32;
                    monster_aggressive_range = 0;
                    monster_aggressive_range_str = 0;
                    monster_defensive_stab = 255;
                    monster_defensive_slash = 65;
                    monster_defensive_crush = 190;
                    monster_defensive_magic = 440;
                    monster_defensive_range = 320;

                    Dispatcher.Invoke(Stats);
                    break;
                case "Awakened Whisperer":
                    monster_size = 3;
                    monster_combat_hp_lvl = 2700;
                    monster_combat_atk_lvl = 378;
                    monster_combat_str_lvl = 378;
                    monster_combat_def_lvl = 300;
                    monster_combat_magic_lvl = 225;
                    monster_combat_range_lvl = 243;
                    monster_aggressive_atk = 140;
                    monster_aggressive_str = 30;
                    monster_aggressive_magic = 190;
                    monster_aggressive_magic_dmg = 58;
                    monster_aggressive_range = 160;
                    monster_aggressive_range_str = 70;
                    monster_defensive_stab = 180;
                    monster_defensive_slash = 300;
                    monster_defensive_crush = 220;
                    monster_defensive_magic = 10;
                    monster_defensive_range = 300;

                    Dispatcher.Invoke(Stats);
                    break;

            }
        }
        private void monsters_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            string temp_string = Convert.ToString(monsters_combobox.SelectedItem);
            if (temp_string != "")
            {
                monster_name = Convert.ToString(temp_string);
                Dispatcher.Invoke(monsters);
            }
        }


    }
}
