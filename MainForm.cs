using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BreakpointConflictTracker
{
    public partial class MainForm : Form
    {
        private Dictionary<string, List<string>> categoryItems = new Dictionary<string, List<string>>();
        private TextBox modNameTextBox = new TextBox();
        private ComboBox categoryComboBox = new ComboBox();
        private ComboBox vanillaItemComboBox = new ComboBox();
        private TextBox descriptionTextBox = new TextBox();
        private Button addButton = new Button();
        private ListBox listBox = new ListBox();
        private Button removeButton = new Button();
        private MenuStrip menuStrip = new MenuStrip();

        public MainForm()
        {
            LoadData();
            SetupUI();
            Text = "Breakpoint Conflict Tracker";
            Size = new Size(600, 400);
            SetupMenu();
        }

        private void LoadData()
        {
            categoryItems = new Dictionary<string, List<string>>
            {
                ["Facial Paint"] = new List<string> { "Black Forhead", "Black Paint A", "Black Paint B", "Black Paint C", "Black Paint D", "Black Paint E", "Black Paint F", "Black Paint G", "Black Paint H", "Black Paint I", "Black Paint J", "Black Paint K", "Black Paint L", "Black Paint M", "Black Paint Woman", "Blackwing", "Camo Fingerpaint 1", "Camo Fingerpaint 2", "Camo Fingerpaint 3", "Camo Fingerpaint 4", "Camo Fingerpaint 5", "Camo Fingerpaint 6", "Camo Fingerpaint 7", "Camo Fingerpaint 8", "Camo Fingerpaint 9", "Camo Fingerpaint 10", "Camo Fingerpaint 11", "Camo Fingerpaint 12", "Camo Fingerpaint 13", "Camo Fingerpaint 14", "Camo Fingerpaint Forrest", "Camo Fingerpaint Snow", "Camo Paint 1", "Camo Paint 2", "Camo Paint 3", "Camo Paint 4", "Festus", "Red Under-eye", "Shredded T-800", "Shark" }.OrderBy(x => x).ToList(),
                ["Head Protection"] = new List<string> { "3E Black Arrow", "5.11 Boonie Hat", "5.11 Flag Bearer Cap", "5.11 Flag Bearer Cap Alt", "6B47 - Covered", "ACH Helmet", "ACH Helmet - Covered", "Ash's Cap", "Aviator Hat", "Ballistic Helmet", "Baseball Cap", "Beanie", "Beret", "Boonie Generic", "Campaign Hat", "Chapka", "Community Leader Headwear", "Crye Airframe Helmet", "Crye Nightcap", "Enhanced Field Cap", "Field Cap", "Flat Cap", "Fourth Echelon Goggles", "Future Soldier Helmet", "Gentex SOHA Helmet", "M1 Helmet - Covered", "Military Beret", "Nightmare Cap", "Nomad Cap", "Ops-Core FAST Helmet", "Ops-Core FAST Helmet - Covered", "Ops-Core FAST Helmet - Visor", "Ops-Core Skullcrusher", "PASGT Helmet", "PASGT Helmet - Covered", "Polar Fleece Beanie", "Rebel Ballistic Helmet", "Rebel Helmet", "Resistance Helmet", "Reversed Baseball Cap", "Riot Helmet", "Russian Paratrooper Beret", "SSh-68", "SWAT Helmet", "Safariland PROTECH Delta X", "Safariland PROTECH Delta X - Covered", "Sentinel Breacher Helmet Mk. III", "Sentinel Mk. II Helmet", "Special Forces Beret", "Stetson", "Survivor Bandana", "Tactical Bandana", "Team Wendy EXFIL Ballistic", "Team Wendy EXFIL Ballistic - Covered", "Team Wendy EXFIL Carbon", "Team Wendy EXFIL Carbon - Covered", "Third Echelon Multi-Vision Goggles", "Third Echelon Sonar Goggles", "Trucker Cap", "Wool Driver Cap" }.OrderBy(x => x).ToList(),
                ["Headset"] = new List<string> { "Earpiece", "Earpeice", "Ops-Core AMP", "Ops-Core AMP Headset", "Peltor", "Peltor Alert", "Peltor ComTac", "Peltor Lite-Com 3", "Revision ComCenter 2 Headset", "Revision ComCener2 Headset", "Safariland Liberator IV", "Safariland TABC 3", "TCI Liberator II Headset", "TCI Patril II Headset" }.OrderBy(x => x).ToList(),
                ["Gloves"] = new List<string> { "5.11 Tac A2 Gloves", "Architect Gloves | Engineer", "Armored Soft Gloves", "BLACKHAWK ELITE Gloves", "BLACKHAWK FURY Gloves", "BLACKHAWK Patrol", "BLACKHAWK SOLAG Gloves", "Bodark Gloves", "Civilian Work Gloves", "Commissar Gloves | Sharpshooter", "Durable Leather Gloves", "Energy Strike Gloves", "Fingerless Gloves", "FirstSpear Operator Outer Gloves", "Fourth Echelon Gloves", "Golem Gloves | Field Medic", "Hard Padded Gloves", "Hard Shell Gloves", "Hatch Operator Gloves", "Heavy Duty Gloves", "High Density Gloves", "Judge Gloves | Assault", "Leather Gloves", "Mustang Survival Ocean Racing Gloves", "Oakley Lightweight Gloves", "Oakley SI Assault Gloves", "Paladin Nine Gloves", "Pioneer Gloves | Pathfinder", "Plastic Gloves", "Punk Gloves", "S&S WetWorX Cold Gloves", "S&S WetWorx Warm Gloves", "Scuba Gloves", "Sentinel Gloves", "Silencer Gloves", "Silencer Gloves | Echelon", "Ski Gloves", "Soft Gloves", "Third Echelon Gloves", "VelSyst Trigger Gloves", "Wolf Extreme Cold Weather Mittens", "Wolf Gloves" }.OrderBy(x => x).ToList(),
                ["Facemask"] = new List<string> { "3E Eclipse Balaclava Helmet", "AirSoft Skull Mask", "Architect Mask", "Architect Mask | Engineer", "Arcturus Ghost Hood", "Arcturus Warrior Hood", "Avon M50 Gas Mask", "Balaclava Sniper", "Bodark Mask A", "Bodark Mask B", "Bodark Mask C", "Bodark Mask D", "Bodark Mask E", "Bulldog Gas Mask", "Claro Gentile Mask", "Sniper Balaclava", "Commissar Helm", "Commissar Helmet | Field Medic", "Crye Compact Assault Ghillie Hood", "Cross-Nose Balaclava", "Extreme Infiltrator Mask", "F-16 Fighter Helmet", "Flayered Skull (Panther)", "Flayed Skull | Panther", "Flycatcher Mask", "Fourth Echelon Mask", "Future Soldier Headgear", "Future Soldier Mask", "Galvion Ballistic Helmet", "Gasmask Avon M50", "Golem Mask", "Golem Mask | Field Medic", "Half Mask", "Half Moon Balaclava", "Heavy Duty Gas Mask", "Heli Helmet", "Judge Mask", "Kevlar Ballistic Helmet", "MASKA-1SCh", "Mixed Material Ghillie Hood", "Ninja Half Mask", "Paladin Nine Mask", "Panoramic Gas Mask", "Pioneer Helmet | Sharpshooter", "Rebel Balistic Mask", "Rebel Knight Helmet", "Rebel Plate Mask", "Revision SnowHawk Balaclava", "Rosebud Mask", "Scarf A", "Scarf B", "Shemagh", "Silencer Mask", "Silencer Mask | Echelon", "Silverback Mask", "Skull Balaclava", "Skull Ballistic Mask", "Sniper Balaclava", "Snow Woods Ghillie Hood", "Spetznas Balaclava", "Stealth Balaclava", "Steel Skull Ballistic Mask", "Sylverback Mask", "Syriyka Soviet Combat Hat", "Tree Leaves Ghillie Hood", "Wolf Enhanced Helmet A", "Wolf Enhanced Helmet B", "Wolf Mask", "Wolf Mask A", "Wolf Mask B", "Wolf Mask C", "Wrapped Shemagh", "Yellowleg Mask", "UA Heatgear Tactical Balaclava" }.OrderBy(x => x).ToList(),

                ["Pants"] = new List<string> { "5.11 Apex Pants", "5.11 Apex Pants - Kneepads", "5.11 Tactical Stryke Pants", "5.11 Tactical Stryke Pants - Kneepads", "Architect Pants", "Architect Pants | Engineer", "Arcturus Warrior Pants", "Armored Baggy Pants", "Armored Forest Tactical Pants", "Armored Heat Regulating Tactical Pants", "Armored Pants", "BLACKHAWK LW Pants", "BLACKHAWK LW Pants - Kneepads", "BLACKHAWK Tactical Shorts", "Baggy Pants", "Bodark Pants", "Cargo Pants", "Cargo Pants - Kneepads", "Cargo Pants A", "Chinos", "Commissar Slacks", "Commissar Slacks | Sharpshooter", "Crye G3 Combatpants", "Crye G3 Combat Pants", "Crye G3 Kneepads", "Crye G4 Combat Pants", "First Spear Centurion Shorts", "Fixit Pants", "Flayered Legs (Panther)", "Flayed Legs | Panther", "Forest Tactical Pants", "Fourth Echelon Pants", "Fury Pants", "Ghost Ghili Pants", "Ghost Ghillie Pants", "Golem Pants", "Golem Pants | Field Medic", "Gorka Pants", "Heat Regulation Tac Pants", "Helikon-Tex CPU Pants", "Helikon-Text SP Kneepads", "Helikon-Tex CPU Pants - Kneepads", "High-tech Infiltraton Pants", "Hill's Pants", "Jeans", "Jeans A Kneepads", "Judge Pants", "Judge Pants | Assault", "Kilt", "Kyle Pants", "Long Shorts", "M88 'Afghanka Pants", "Mixed Material Ghillie Pants", "Nomad Pants", "Nomad", "Paladin Nine Pants", "Pioneer Pants | Pathfinder", "Punk Pants", "Reinforced Thigh Pads Pants", "Rosebud Pants", "Russian Summer Pants", "Scuba Pants", "Sentinal Combat Pants", "Sentinal Combat Pants - Kneepads", "Sentinal Mk. II Pants", "Sentinel MK2 Heavy Pants", "Silencer Pants", "Silencer Pants | Echelon", "Snow Woods Ghillie Pants", "Strap Shorts", "Survivor Pants", "Tactical Dry Pants", "TacStryke Kneepads", "Thigh Pad Shorts", "Thigh Pads Pants", "Third Echelon Pants", "Tree Leaves Ghillie Pants", "Tropical Combat Trousers", "Utility Work Pants", "Vasily Pants", "VelSyst Range Shorts", "Warrior Ghilli", "Wolf Enhanced Pants", "Wolf Tactical Pants", "Worn Out Punk Pants", "Yellowleg Pants" }.OrderBy(x => x).ToList(),

                ["NVG"] = new List<string> { "Bodark NVG", "L3 Insight NVG", "L3GP", "MATBOCK Tarsier Eclipse", "Model 2740 LPNVM", "PS15ATN", "Steiner Vision", "i-Aware TM-NVG" }.OrderBy(x => x).ToList(),

                ["Shoes"] = new List<string> { "5.11 Fast-Tac 8\" Boot", "5.11 Fast-Tac Boots", "BLACKHAWK Terrain Mid Boots", "BLACKHAWK Trident Boots", "Bodark Boots", "Classic Sneakers", "Combat Boots", "Fourth Echelon Boots", "Jungle Boots DMS", "Kyle Sneakers", "Large Collar Sneakers", "Lightweight Boots", "Navy Boots", "Oakley Light Assault Boots", "Oakley LSA", "Paladin Nine Boots", "Punk Boots", "Ranger Boots", "Reinforced Boots", "Self-Fastening Ankle Boots", "Self-Fastening Tactical Shoes", "Silent Shoes", "Soft Shoes", "Steel-Toed Boots", "Third Echelon Boots", "Traction Boots", "UA Agent Tactical Boots", "UA Infil Boots", "UA Infil Ops Boots", "UA Micro G Pursuit Twist", "UA Speed Freek Boots", "UA Valstetz RTS Boots", "UA Verge Mid GORE-TEX", "Utility Boots", "Worn Out Punk Boots" }.OrderBy(x => x).ToList(),

                ["Camo"] = new List<string> { "AOR1", "AOR2", "ATACS ATX", "ATACS AU", "ATACS AUX", "ATACS FG", "ATACS FGX", "ATACS Ghost", "ATACS IX", "ATACS LE", "ATACS LE-X", "Black Solid", "Blue Solid", "Bodark Camo", "British DPM", "Brown", "CADPAT AR", "CADPAT TW", "Chocolate Chip", "Coyote Brown", "DCU Tricolor", "Dead Leaves", "EXTP Arctic", "EXTP Desert", "EXTP Urban", "EXTP Woodland", "Flecktarn", "German 3 Color", "Grey Python", "Grey Solid", "HCP Tiger", "Khaki Netting", "Kryptek Banshee", "Kryptek Highlander", "Kryptek Mandrake", "Kryptek Neptune", "Kryptek Nomad", "Kryptek Raid", "Kryptek Typhon", "Kryptek Yeti", "M05 Woodland", "Multicam", "Multicam Alpine", "Multicam Arid", "Multicam Black", "Multicam Tropic", "Navy Blue", "NWU T1", "Olive Drab", "Pencott LN", "Pencott MP", "Pencott SD", "Pencott SS", "Polish Urban Flecktarn", "Red Solid", "Russian Digital Flora", "Sentinel Arid", "Sentinel Forest", "Sentinel Mountain", "Sentinel Urban", "Tan", "Tigerstripe", "UCP", "UCPD", "Urban ERDL", "US ABU2", "USAF Digital Tiger", "White Solid", "Wolves", "Wolves Arid", "Wolves Forest", "Wolves Mountain", "Wolves Urban", "Woodland" },
                ["Vests"] = new List<string> { "5.11 TacTec Plate Carrier", "5.11 TacLite Plate Carrier", "5.11 VTAC LBE Tactical Vest", "6B3", "6B43", "6B46", "6B5", "A.L.I.C.E. Chest Rig", "Architect Vest | Engineer", "Armored Dual Harness Vest", "Armored Marten Plate Carrier", "Armored Vest", "BLACKHAWK Omega Vest", "BLACKHAWK S.T.R.I.K.E. - Shoulder Pads", "BLACKHAWK S.T.R.I.K.E. Vest", "Bodark Chest Rig", "Bodark Load Bearing Vest", "Commissar Coat | Sharpshooter", "Coyote Chest Rig", "Coyote Plate Carrier", "Cross-draw Vest", "Crye AVS", "Crye AVS - Loaded", "Crye CPC", "Crye JPC", "Drone Operator Light Vest", "Dual Harness Vest", "Eagle Industries Chest Rig", "Flayed Vest | Pathfinder", "Flycatcher Vest", "Fury Vest", "Future Soldier Vest", "Golem Cape | Field Medic", "HSGI MPC - Loaded", "Heavy Gunner Chest Rig", "Hill's Vest", "Judge Plate | Assault", "Light Carrier Harness", "Light Chest Rig", "Low Profile Chest Rig", "M23 Chest Rig", "M69 Flak Vest", "Marten Chest Rig", "Ocelot Chest Rig", "Pioneer Vest | Pathfinder", "Rosebud Vest", "Russian Counter-Terrorism Armor", "Russian Defender 2", "S&S Plate Frame", "SWAT Vest", "Safariland P1 Covert Carrier", "Safariland U1 Overt Carrier", "Safariland V1 Overt Carrier", "Sentinel Mk. II Vest", "Sentinel Sniper Chest Rig", "Silencer Vest | Echelon", "Silverback Vest", "Smersh Molle Chest Rig", "Strap Chest Harness", "Tactical Riot Vest", "Third Echelon Vest", "VelSyst Scarab LT", "Walker Vest", "Wolf Armor", "Wolf Chest Rig", "Yellowleg Vest" }.OrderBy(x => x).ToList(),
                ["Tops"] = new List<string> { "5.11 Expedition Shirt", "AMD T-shirt", "Aged Tee", "Architect Top | Engineer", "Arcturus Ghost Top", "Arcturus Warrior Top", "Armored Large Rainstorm Coat", "Armored Rainstorm Coat", "Armored Sport Zipped Sweater", "Army Jacket", "Assault T-shirt", "Bodark Coat", "Bodark Shirt", "Combat T-shirt", "Commissar Shirt | Sharpshooter", "Crye Compact Assault Ghillie", "Crye G3 Combat Shirt", "Crye G4 Combat Shirt", "Delta Company", "Fixit Shirt", "Flayered Chest | Panther", "Fourth Echelon Top", "Future Soldier Top", "GR Skull T-Shirt", "Golem Armour | Field Medic", "Gorka 3 Jacket", "Gorka 4 Jacket", "Helikon-Tex GridFleece", "Helikon CPU Shirt", "Helikon-Tex MK2 Shirt", "Hoodie", "Indie Jones Shirt", "Judge Top | Assault", "Kyle T-shirt", "Lara Croft's Tank Top", "Large Rainstorm Coat", "Leather Jacket", "Lieutenant Top", "Lumberjack Shirt", "M88 'Afghanka' Coat", "Mixed Materials Ghillie Top", "Nomad Emblem T-shirt", "Nomad T-shirt 1", "Paladin Nine Top", "Panther T-Shirt", "Pioneer Top | Pathfinder", "Pocket Tee", "Punk Jacket", "Punk T-Shirt", "Rainstorm Coat", "Resistence Vest", "Rolled-up Sleeves Shirt", "Rosebud Top", "Russian Summer Jacket", "SWAT Top", "Samsung T-shirt", "Scott Mitchell's Top", "Scuba Diver Top", "Sentinel Armored Shirt", "Sentinel Corp. T-shirt", "Sentintel Jacket", "Sharpshooter T-Shirt", "Silencer Top | Echelon", "Skell Tech T-shirt", "Sleeveless Jacket", "Sleeveless Telnyashka", "Snow Woods Ghillie Top", "Soflete T-Shirt", "Soft Shell", "Spandex Shirt", "Sport Zipped Sweater", "Sports Jacket", "Sunrock T-Shirt", "T-Shirt", "Tactical Dry Top", "Tank Top", "Telnyashka", "Terminator Jacket", "Terminator T-shirt", "Third Echelon Top", "Tree Leaves Ghillie Top", "Tropical Combat Jacket", "Turtleneck", "Ubisoft Experience T-shirt", "Urban Hero Jacket", "Vasily's Sniper Shirt", "Walker T-shirt", "Waterproof Top", "Wolves T-shirt", "Worn T-shirt", "Yellowleg Top", "Zipped Hoodie", "Zipped Sweater" }.OrderBy(x => x).ToList(),
                ["Backpack"] = new List<string> { "3 Day Assault Pack", "5.11 All Hazard Backpack", "5.11 AMP 24 Backpack", "5.11 RUSH24 Backpack", "Airtight Pack", "Armored Pack", "BLACKHAWK Cyclone Pack", "BLACKHAWK Cyane With Tarp", "Blackhawk Cyane Pack", "Camelbak Ambush", "Camelbak Ambush - Open", "Crye AVS1000 Pack", "DA Dragon Egg MKII Pack", "Fixit's Pack", "Flycatcher Backpack", "Fury Crye AVS", "Hill's Backpack", "Maritime Operations Pack", "Nomad's AMP24", "Tac Tailor Hydration Pack", "Tac Tailor Operator Pack", "US Govornment Molle II Rucksack", "Versatile Pack", "Veshmeshok" }.OrderBy(x => x).ToList(),
                ["Sunglasses"] = new List<string> { "5.11 Burner Sunglasses", "ACH Goggles", "Aviator Goggles", "Aviators", "Azure Glasses", "BCG", "Ballistic Goggles", "Downcurve Sunglasses", "ESS Crossbow Eyeshield", "Eye Patch", "Goggles ACH - Cross-Com", "High-Protection Shades", "John Kozak's Glasses", "Lara Croft's Sunglasses", "Oakley jawbreaker", "Oakley jawbreaker - Cross-Com", "Oakley SI Ballistic Halo Goggles", "Oakley Oakley SI Ballistic M-Frame 2.0", "Oakley Oakley SI Ballistic M-Frame Alpha", "Ops-Core Mk1 Glasses", "Pulse's Glasses", "Red Eye Terminator Sunglasses", "Revision BulletAnt Goggles", "Reision Exoshield Goggles", "Revision Hellfly", "Revision SnowHawk Ballistic Goggles", "Round Glasses", "Sarah Connor Sunglasses", "Scuba Mask", "Sentinel Goggles", "Skell Glasses", "Soviet Military Goggles", "Terminator Sunglasses" }.OrderBy(x => x).ToList()
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
            vanillaItemComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            vanillaItemComboBox.DrawItem += VanillaItemComboBox_DrawItem;
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

        private void SetupMenu()
        {
            // Create File menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            
            // Create Export option
            ToolStripMenuItem exportMenuItem = new ToolStripMenuItem("Export Conflict List");
            exportMenuItem.Click += ExportMenuItem_Click;
            fileMenu.DropDownItems.Add(exportMenuItem);
            
            // Create Import option
            ToolStripMenuItem importMenuItem = new ToolStripMenuItem("Import Conflict List");
            importMenuItem.Click += ImportMenuItem_Click;
            fileMenu.DropDownItems.Add(importMenuItem);
            
            // Add File menu to menu strip
            menuStrip.Items.Add(fileMenu);
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }

        private void ExportMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Export Conflict List";
            saveFileDialog.DefaultExt = "txt";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var item in listBox.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("Conflict list exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting conflict list: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportMenuItem_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Import Conflict List";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    listBox.Items.Clear();
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            listBox.Items.Add(line);
                        }
                    }
                    MessageBox.Show("Conflict list imported successfully!", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error importing conflict list: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string? selectedCategory = categoryComboBox.SelectedItem?.ToString();
            if (selectedCategory != null && categoryItems.ContainsKey(selectedCategory))
            {
                vanillaItemComboBox.Items.Clear();
                vanillaItemComboBox.Items.AddRange(categoryItems[selectedCategory].ToArray());
            }
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            string modName = modNameTextBox.Text.Trim();
            string? category = categoryComboBox.SelectedItem?.ToString();
            string? vanillaItem = vanillaItemComboBox.SelectedItem?.ToString();
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

        private void RemoveButton_Click(object? sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }

        private void RemoveMenuItem_Click(object? sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }

        private void VanillaItemComboBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string? itemText = vanillaItemComboBox.Items[e.Index]?.ToString();
            if (string.IsNullOrEmpty(itemText)) return;

            // Check if this item has been added to the list
            bool isAdded = IsItemAlreadyAdded(itemText);

            // Set the background color
            e.DrawBackground();

            // Set the text color based on whether it's been added
            Brush textBrush = isAdded ? Brushes.Red : Brushes.Black;

            // Draw the text
            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);

            // Draw focus rectangle if needed
            e.DrawFocusRectangle();
        }

        private bool IsItemAlreadyAdded(string vanillaItem)
        {
            // Check if the vanilla item exists in the list box
            foreach (var item in listBox.Items)
            {
                string? itemText = item?.ToString();
                if (!string.IsNullOrEmpty(itemText) && itemText.Contains($": {vanillaItem}"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
