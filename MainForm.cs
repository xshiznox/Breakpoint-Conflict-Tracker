using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BreakpointConflictTracker
{
    public partial class MainForm : Form
    {
        private Dictionary<string, List<string>>? categoryItems;
        private TextBox? modNameTextBox;
        private ComboBox? categoryComboBox;
        private ComboBox? vanillaItemComboBox;
        private TextBox? descriptionTextBox;
        private Button? addButton;
        private ListBox? listBox;
        private Button? removeButton;

        public MainForm()
        {
            LoadData();
            SetupUI();
            Text = "Breakpoint Conflict Tracker";
            Size = new Size(600, 400);
        }

        private void LoadData()
        {
            categoryItems = new Dictionary<string, List<string>>
            {
                ["Facial Paint"] = new List<string> { "Black Forhead", "Black Paint A", "Black Paint B", "Black Paint C", "Black Paint D", "Black Paint E", "Black Paint F", "Black Paint G", "Black Paint H", "Black Paint I", "Black Paint J", "Black Paint K", "Black Paint L", "Black Paint M", "Black Paint Woman", "Blackwing", "Camo Fingerpaint 1", "Camo Fingerpaint 2", "Camo Fingerpaint 3", "Camo Fingerpaint 4", "Camo Fingerpaint 5", "Camo Fingerpaint 6", "Camo Fingerpaint 7", "Camo Fingerpaint 8", "Camo Fingerpaint 9", "Camo Fingerpaint 10", "Camo Fingerpaint 11", "Camo Fingerpaint 12", "Camo Fingerpaint 13", "Camo Fingerpaint 14", "Camo Fingerpaint Forrest", "Camo Fingerpaint Snow", "Camo Paint 1", "Camo Paint 2", "Camo Paint 3", "Camo Paint 4", "Festus", "Red Under-eye", "Shredded T-800", "Shark" }.OrderBy(x => x).ToList(),
                ["Head Protection"] = new List<string> { "3E Black Arrow", "5.11 Boonie Hat", "5.11 Flag Bearer Cap", "5.11 Flag Bearer Cap Alt", "6B47 - Covered", "ACH Helmet", "ACH Helmet - Covered", "Ash's Cap", "Aviator Hat", "Ballistic Helmet", "Baseball Cap", "Beanie", "Beret", "Boonie Generic", "Campaign Hat", "Chapka", "Community Leader Headwear", "Crye Airframe Helmet", "Crye Nightcap", "Enhanced Field Cap", "Field Cap", "Flat Cap", "Fourth Echelon Goggles", "Future Soldier Helmet", "Gentex SOHA Helmet", "M1 Helmet - Covered", "Military Beret", "Nightmare Cap", "Nomad Cap", "Ops-Core FAST Helmet", "Ops-Core FAST Helmet - Covered", "Ops-Core FAST Helmet - Visor", "Ops-Core Skullcrusher", "PASGT Helmet", "PASGT Helmet - Covered", "Polar Fleece Beanie", "Rebel Ballistic Helmet", "Rebel Helmet", "Resistance Helmet", "Reversed Baseball Cap", "Riot Helmet", "Russian Paratrooper Beret", "SSh-68", "SWAT Helmet", "Safariland PROTECH Delta X", "Safariland PROTECH Delta X - Covered", "Sentinel Breacher Helmet Mk. III", "Sentinel Mk. II Helmet", "Special Forces Beret", "Stetson", "Survivor Bandana", "Tactical Bandana", "Team Wendy EXFIL Ballistic", "Team Wendy EXFIL Ballistic - Covered", "Team Wendy EXFIL Carbon", "Team Wendy EXFIL Carbon - Covered", "Third Echelon Multi-Vision Goggles", "Third Echelon Sonar Goggles", "Trucker Cap", "Wool Driver Cap" }.OrderBy(x => x).ToList(),
                ["Headset"] = new List<string> { "Earpeice", "Ops-Core AMP Headset", "Peltor", "Revision ComCener2 Headset", "SafNaNakley SI Assault Gloves" }.OrderBy(x => x).ToList(),
                ["Gloves"] = new List<string> { "Paladin Nine Gloves", "Plastic Gloves", "Punk Gloves", "S&S WetWorX Cold Gloves", "S&S WetWorX Warm Gloves", "Scuba Gloves", "Sentinel Gloves", "Silencer Gloves", "Ski Gloves", "Soft Gloves", "Third Echelon Gloves", "VelSyst Trigger Gloves", "Wolf Extreme Cold Weather Mittens", "Wolf Gloves" }.OrderBy(x => x).ToList(),
                ["Facemask"] = new List<string> { "AirSoft Skull Mask", "Balaclava Sniper", "Cross-Nose Balaclava", "Flycatcher Mask", "Gasmask Avon M50", "Half Moon Balaclava", "MASKA-1SCh", "Rosebud Mask", "Shemagh", "Scarf A", "Stealth Balaclava", "Sylverback Mask", "Wolf Mask", "Wolf Mask B", "Wolf Mask C", "Wrapped Shemagh", "Yellowleg Mask", "Commissar Helm", "Fourth Echelon Mask", "Paladin Nine Mask", "Architect Mask", "Flayered Skull (Panther)", "Golem Mask", "Half Mask", "Heavy Duty Gas Mask", "Heli Helmet", "Judge Mask", "Silencer Mask", "Ninja Half Mask", "Rebel Balistic Mask" }.OrderBy(x => x).ToList(),
                ["Pants"] = new List<string> { "Architect Pants", "BLACKHAWK LW Pants", "Cargo Pants A", "Chinos", "Commissar Slacks", "Crye G3 Combatpants", "Crye G3 Kneepads", "Fixit Pants", "Flayered Legs (Panther)", "Fourth Echelon Pants", "Fury Pants", "Ghost Ghili Pants", "Golem Pants", "Heat Regulation Tac Pants", "Helikon-Tex CPU Pants", "Helikon-Text SP Kneepads", "Jeans", "Jeans A Kneepads", "Judge Pants", "Kilt", "Nomad Pants", "Paladin Nine Pants", "Punk Pants", "Rosebud Pants", "Scuba Pants", "Silencer Pants", "Survivor Pants", "TacStryke Kneepads", "Thigh Pad Shorts", "Vasily Pants", "Warrior Ghilli", "Wolf Tactical Pants", "Yellowleg Pants", "Third Echelon Pants", "Sentinel MK2 Heavy Pants" }.OrderBy(x => x).ToList(),
                ["NVG"] = new List<string> { "L3GP", "PS15ATN", "Steiner Vision" }.OrderBy(x => x).ToList(),
                ["Shoes"] = new List<string> { "5.11® Fast-Tac Boots", "Combat Boots", "Fourth Echelon Boots", "Lightweight Boots", "Navy Boots", "Oakley Light Assault Boots", "Oakley LSA", "Paladin Nine Boots", "Punk Boots", "Ranger Boots", "Reinforced Boots", "Self-Fastening Ankle Boots", "Soft Shoes", "Steel-Toed Boots", "Third Echelon Boots", "Traction Boots", "UA Agent Tactical Boots", "UA Infil Boots", "UA Speed Freek Boots", "UA Valstetz RTS Boots" }.OrderBy(x => x).ToList(),
                ["Camo"] = new List<string> { "AOR1", "AOR2", "ATACS ATX", "ATACS AU", "ATACS AUX", "ATACS FG", "ATACS FGX", "ATACS Ghost", "ATACS IX", "ATACS LE", "ATACS LE-X", "Black Solid", "Blue Solid", "Bodark Camo", "British DPM", "Brown", "CADPAT AR", "CADPAT TW", "Chocolate Chip", "Coyote Brown", "DCU Tricolor", "Dead Leaves", "EXTP Arctic", "EXTP Desert", "EXTP Urban", "EXTP Woodland", "Flecktarn", "German 3 Color", "Grey Python", "Grey Solid", "HCP Tiger", "Khaki Netting", "Kryptek Banshee", "Kryptek Highlander", "Kryptek Mandrake", "Kryptek Neptune", "Kryptek Nomad", "Kryptek Raid", "Kryptek Typhon", "Kryptek Yeti", "M05 Woodland", "Multicam", "Multicam Alpine", "Multicam Arid", "Multicam Black", "Multicam Tropic", "Navy Blue", "NWU T1", "Olive Drab", "Pencott LN", "Pencott MP", "Pencott SD", "Pencott SS", "Polish Urban Flecktarn", "Red Solid", "Russian Digital Flora", "Sentinel Arid", "Sentinel Forest", "Sentinel Mountain", "Sentinel Urban", "Tan", "Tigerstripe", "UCP", "UCPD", "Urban ERDL", "US ABU2", "USAF Digital Tiger", "White Solid", "Wolves", "Wolves Arid", "Wolves Forest", "Wolves Mountain", "Wolves Urban", "Woodland" },
                ["Vests"] = new List<string> { "5.11 TacTec Plate Carrier", "5.11 TacLite Plate Carrier", "5.11 VTAC LBE Tactical Vest", "6B3", "6B43", "6B46", "6B5", "A.L.I.C.E. Chest Rig", "Architect Vest | Engineer", "Armored Dual Harness Vest", "Armored Marten Plate Carrier", "Armored Vest", "BLACKHAWK Omega Vest", "BLACKHAWK S.T.R.I.K.E. - Shoulder Pads", "BLACKHAWK S.T.R.I.K.E. Vest", "Bodark Chest Rig", "Bodark Load Bearing Vest", "Commissar Coat | Sharpshooter", "Coyote Chest Rig", "Coyote Plate Carrier", "Cross-draw Vest", "Crye AVS", "Crye AVS - Loaded", "Crye CPC", "Crye JPC", "Drone Operator Light Vest", "Dual Harness Vest", "Eagle Industries Chest Rig", "Flayed Vest | Pathfinder", "Flycatcher Vest", "Fury Vest", "Future Soldier Vest", "Golem Cape | Field Medic", "HSGI MPC - Loaded", "Heavy Gunner Chest Rig", "Hill's Vest", "Judge Plate | Assault", "Light Carrier Harness", "Light Chest Rig", "Low Profile Chest Rig", "M23 Chest Rig", "M69 Flak Vest", "Marten Chest Rig", "Ocelot Chest Rig", "Pioneer Vest | Pathfinder", "Rosebud Vest", "Russian Counter-Terrorism Armor", "Russian Defender 2", "S&S Plate Frame", "SWAT Vest", "Safariland P1 Covert Carrier", "Safariland U1 Overt Carrier", "Safariland V1 Overt Carrier", "Sentinel Mk. II Vest", "Sentinel Sniper Chest Rig", "Silencer Vest | Echelon", "Silverback Vest", "Smersh Molle Chest Rig", "Strap Chest Harness", "Tactical Riot Vest", "Third Echelon Vest", "VelSyst Scarab LT", "Walker Vest", "Wolf Armor", "Wolf Chest Rig", "Yellowleg Vest" }.OrderBy(x => x).ToList()
            };
        }

        private void SetupUI()
        {
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.ColumnCount = 2;
            tableLayout.RowCount = 6;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            Label modNameLabel = new Label();
            modNameLabel.Text = "Mod Name:";
            modNameLabel.Anchor = AnchorStyles.Right;
            tableLayout.Controls.Add(modNameLabel, 0, 0);

            modNameTextBox = new TextBox();
            modNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayout.Controls.Add(modNameTextBox, 1, 0);

            Label categoryLabel = new Label();
            categoryLabel.Text = "Category:";
            categoryLabel.Anchor = AnchorStyles.Right;
            tableLayout.Controls.Add(categoryLabel, 0, 1);

            categoryComboBox = new ComboBox();
            categoryComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            categoryComboBox.Items.AddRange(categoryItems.Keys.ToArray());
            categoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            tableLayout.Controls.Add(categoryComboBox, 1, 1);

            Label vanillaItemLabel = new Label();
            vanillaItemLabel.Text = "Vanilla Item:";
            vanillaItemLabel.Anchor = AnchorStyles.Right;
            tableLayout.Controls.Add(vanillaItemLabel, 0, 2);

            vanillaItemComboBox = new ComboBox();
            vanillaItemComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayout.Controls.Add(vanillaItemComboBox, 1, 2);

            Label descriptionLabel = new Label();
            descriptionLabel.Text = "Description (optional):";
            descriptionLabel.Anchor = AnchorStyles.Right;
            tableLayout.Controls.Add(descriptionLabel, 0, 3);

            descriptionTextBox = new TextBox();
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayout.Controls.Add(descriptionTextBox, 1, 3);

            addButton = new Button();
            addButton.Text = "Add to List";
            addButton.Anchor = AnchorStyles.Left;
            addButton.Click += AddButton_Click;
            tableLayout.Controls.Add(addButton, 1, 4);

            listBox = new ListBox();
            listBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            listBox.ContextMenuStrip = new ContextMenuStrip();
            listBox.ContextMenuStrip.Items.Add("Remove").Click += RemoveMenuItem_Click;
            tableLayout.Controls.Add(listBox, 0, 5);
            tableLayout.SetColumnSpan(listBox, 2);

            removeButton = new Button();
            removeButton.Text = "Remove from List";
            removeButton.Anchor = AnchorStyles.Left;
            removeButton.Click += RemoveButton_Click;
            tableLayout.Controls.Add(removeButton, 1, 4);

            Controls.Add(tableLayout);
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = categoryComboBox.SelectedItem?.ToString();
            if (selectedCategory != null && categoryItems.ContainsKey(selectedCategory))
            {
                vanillaItemComboBox.Items.Clear();
                vanillaItemComboBox.Items.AddRange(categoryItems[selectedCategory].ToArray());
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string modName = modNameTextBox.Text.Trim();
            string category = categoryComboBox.SelectedItem?.ToString();
            string vanillaItem = vanillaItemComboBox.SelectedItem?.ToString();
            string description = descriptionTextBox.Text.Trim();

            if (string.IsNullOrEmpty(modName) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(vanillaItem))
            {
                MessageBox.Show("Mod Name, Category, and Vanilla Item are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string itemText = $"{modName} -> {category}: {vanillaItem}";
            if (!string.IsNullOrEmpty(description))
            {
                itemText += $" ({description})";
            }

            listBox.Items.Add(itemText);

            modNameTextBox.Clear();
            descriptionTextBox.Clear();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }
    }
}
