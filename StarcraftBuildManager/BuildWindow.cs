﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarcraftBuildManager
{
    public partial class BuildWindow : Form
    {
        //Methods and main variables
        MainVariables mainVariables;
        MainMethods mainMethods;

        //UI Elements
        PictureBox[] building_Pictureboxes;
        PictureBox[] upgrade_Pictureboxes;
        PictureBox[] unit_Pictureboxes;
        
        //Calling used prefabs
        
        //ZERG
        
        //Zerg Buildings
        Prefab hatchery, lair, hive, zerg_Extractor, spawning_Pool, evolution_Chamber, spine_Crawler, spore_Crawler,
        hydralisk_Den, baneling_Nest, roach_Warren, infestation_Pit, spire, greater_Spire, nydus_Network, ultralisk_Cavern, lurker_Den;

        

        Prefab[] building_Array;
        //Zerg Units
        Prefab baneling, brood_Lord, corruptor, drone, hydralisk, infestor, lurker, mutalisk, overlord, overseer, queen,
            ravager, roach, swarm_Host, ultralisk, viper, zergling;

       

        Prefab[] unit_Array;
        //Zerg Upgrades
        Prefab adaptive_Talons, adrenal_Glands, anabolic_Synthesis, burrow, centrifugal_Hooks, chitinious_Plating, flyer_Attacks1, flyer_Attacks2, flyer_Attacks3,
            flyer_Carapace1, flyer_Carapace2, flyer_Carapace3, glial_Reconstitution, grooved_Spines, ground_Carapace1, ground_Carapace2, ground_Carapace3, melee_Attacks1, melee_Attacks2, melee_Attacks3, metabolic_Boost,
            missile_Attacks1, missile_Attacks2, missile_Attacks3, muscular_Augments, neural_Parasite, pathogen_Glands, pneumatized_Carapace, seismic_Spines, tunneling_Claws;


        Prefab[] upgrade_Array;


        public BuildWindow(string race, MainVariables givenMainVariables, MainMethods givenMainMethods)
        {
            //initialzing UI
            InitializeComponent();

            mainVariables = givenMainVariables;
            mainMethods = givenMainMethods;
            mainVariables.Active_Race = race;
            building_Pictureboxes = new PictureBox[] {picbBuilding1, picbBuilding2, picbBuilding3, picbBuilding4, picbBuilding5, picbBuilding6, picbBuilding7, picbBuilding8, picbBuilding9, picbBuilding10, 
            picbBuilding11, picbBuilding12, picbBuilding13, picbBuilding14, picbBuilding15, picbBuilding16, picbBuilding17, picbBuilding18};
            unit_Pictureboxes = new PictureBox[] {picbUnit1, picbUnit2, picbUnit3, picbUnit4, picbUnit5, picbUnit6, picbUnit7, picbUnit8, picbUnit9, picbUnit10, picbUnit11, picbUnit12, picbUnit13, picbUnit14,
            picbUnit15, picbUnit16, picbUnit17, picbUnit18, picbUnit19, picturepicbUnit20, picbUnit21, picbUnit22, picbUnit23, picbUnit24, picbUnit25, picbUnit26, picbUnit27, picbUnit28, picbUnit29, picbUnit30};
            upgrade_Pictureboxes = new PictureBox[] {picbUpgrade1, picbUpgrade2, picbUpgrade3, picbUpgrade4, picbUpgrade5, picbUpgrade6, picbUpgrade7, picbUpgrade8, picbUpgrade9, picbUpgrade10, picbUpgrade11,
            picbUpgrade12, picbUpgrade13, picbUpgrade14, picbUpgrade15, picbUpgrade16, picbUpgrade17, picbUpgrade18, picbUpgrade19, picbUpgrade20, picbUpgrade21, picbUpgrade22, picbUpgrade23, picbUpgrade24, picbUpgrade25,
            picbUpgrade26, picbUpgrade27, picbUpgrade28, picbUpgrade29, picbUpgrade30, picbUpgrade31, picbUpgrade32, picbUpgrade33, picbUpgrade34, picbUpgrade35, picbUpgrade36, picbUpgrade37,
            picbUpgrade38, picbUpgrade39, picbUpgrade40, picbUpgrade41, picbUpgrade42};

            this.BackgroundImage = mainVariables.BuildWindow_BackgroundBM;
            picbTooltipTime.Image = mainVariables.BuildingArea_UiClock;
            picbMinerals.Image = mainVariables.BuildingArea_UiMinerals;
            picbVespin.Image = mainVariables.BuildingArea_UiVespin;
            trackbarTimeline.Location = new Point(39, 46);
            lblTimeEnd.Location = new Point(36, 30);
            lbltimeStart.Location = new Point(36, 625);            
            switch (race)
            {
                case "Zerg":
                    Zerg();
                    break;
                case "Protoss":
                    Protoss();
                    break;
                case "Terran":
                    Terran();
                    break;
            }
            this.Icon = mainVariables.BuildManager_Icon;
        }

        public void Zerg()
        {              

            //Initializing the Buildings and set them on their place in the UI
            hatchery = new Prefab("Hatchery", 300, 0, 100f, mainVariables.HatcheryBM, -3);
            lair = new Prefab("Lair", 150, 100, 80f, mainVariables.LairBM);
            hive = new Prefab("Hive", 200, 150, 100f, mainVariables.HiveBM);
            zerg_Extractor = new Prefab("Extractor", 25, 0, 30f, mainVariables.Zerg_ExtractorBM);
            spawning_Pool = new Prefab("Spawning Pool", 200, 0, 65f, mainVariables.Spawning_PoolBM);
            evolution_Chamber = new Prefab("Evolution Chamber", 75, 0, 35f, mainVariables.Evolution_ChamberBM);
            spine_Crawler = new Prefab("Spine Crawler", 100, 0, 50f, mainVariables.Spine_CrawlerBM);
            spore_Crawler = new Prefab("Spore Crawler", 75, 0, 30f, mainVariables.Spore_CrawlerBM);
            hydralisk_Den = new Prefab("Hydralisk Den", 100, 100, 60f, mainVariables.Hydralisk_DenBM);
            baneling_Nest = new Prefab("Baneling Nest", 100, 50, 60f, mainVariables.Baneling_NestBM);
            roach_Warren = new Prefab("Roach Warren", 150, 0, 55f, mainVariables.Roach_WarrenBM);
            infestation_Pit = new Prefab("Infestation Pit", 100, 100, 50f, mainVariables.Infestation_PitBM);
            spire = new Prefab("Spire", 200, 200, 100f, mainVariables.SpireBM);
            greater_Spire = new Prefab("Greater Spire", 100, 150, 100, mainVariables.Greater_SpireBM);
            nydus_Network = new Prefab("Nydus Network", 150, 200, 50f, mainVariables.Nydus_NetworkBM);
            ultralisk_Cavern = new Prefab("Ultralisk Cavern", 150, 200, 65f, mainVariables.Ultralisk_CavernBM);
            lurker_Den = new Prefab("Lurker Den", 150, 100, 57f, mainVariables.Lurker_DenBM);

            building_Array = new Prefab[] {hatchery, lair, hive, zerg_Extractor, spawning_Pool, evolution_Chamber, spine_Crawler, spore_Crawler,
            hydralisk_Den, baneling_Nest, roach_Warren, infestation_Pit, spire, greater_Spire, nydus_Network, ultralisk_Cavern, lurker_Den};

            mainMethods.Fill_Picturebox_Array(building_Pictureboxes, building_Array);
            //Initialzing units 

            baneling = new Prefab("Baneling", 50, 25, 44f, mainVariables.BanelingBM, 1.5f);
            drone = new Prefab("Drone", 50, 0, 17f, mainVariables.DroneBM, 1);
            overlord = new Prefab("Overlord", 100, 0, 25f, mainVariables.OverlordBM, -8);
            zergling = new Prefab("Zergling", 50, 0, 24f, mainVariables.ZerglingBM, 1);
            roach = new Prefab("Roach", 75, 25, 27f, mainVariables.RoachBM, 2);
            queen = new Prefab("Queen", 150, 0, 50f, mainVariables.QueenBM, 2);
            hydralisk = new Prefab("Hydralisk", 100, 50, 33f, mainVariables.HydraliskBM, 2);
            mutalisk = new Prefab("Mutalisk", 100, 100, 33f, mainVariables.MutaliskBM, 2);
            corruptor = new Prefab("Corrupter", 150, 100, 40f, mainVariables.CorrupterBM, 4);
            infestor = new Prefab("Infestor", 100, 150, 50f, mainVariables.InfestorBM, 2);
            swarm_Host = new Prefab("Swarm Host", 200, 100, 40f, mainVariables.Swarm_HostBM, 3);
            ultralisk = new Prefab("Ultralisk", 300, 200, 55f, mainVariables.UltraliskBM, 6);
            viper = new Prefab("Viper", 100, 200, 40f, mainVariables.ViperBM, 3);
            brood_Lord = new Prefab("Brood Lord", 300, 250, 77f, mainVariables.Boord_LordBM, 4);
            overseer = new Prefab("Overseer", 150, 50, 42f, mainVariables.OverseerBM, -8);
            lurker = new Prefab("Lurker", 150, 100, 42f, mainVariables.LurkerBM, 3);
            ravager = new Prefab("Ravager", 100, 100, 28f, mainVariables.RavagerBM, 3);
            
            unit_Array = new Prefab[] {baneling, brood_Lord, corruptor, drone, hydralisk, infestor, lurker, mutalisk, overlord, overseer, queen,
            ravager, roach, swarm_Host, ultralisk, viper, zergling};
            
            mainMethods.Fill_Picturebox_Array(unit_Pictureboxes, unit_Array);

            //Initialzing upgrades
            melee_Attacks1 = new Prefab("Melee Attacks 1", 100, 100, 114f, mainVariables.Melee_AttacksBM);
            melee_Attacks2 = new Prefab("Melee Attacks 2", 150, 150, 136f, mainVariables.Melee_AttacksBM);
            melee_Attacks3 = new Prefab("Melee Attacks 3", 200, 200, 157f, mainVariables.Melee_AttacksBM);
            ground_Carapace1 = new Prefab("Ground Carapace 1", 150, 150, 114f, mainVariables.Ground_CarapaceBM);
            ground_Carapace2 = new Prefab("Ground Carapace 2", 225, 225, 136f, mainVariables.Ground_CarapaceBM);
            ground_Carapace3 = new Prefab("Ground Carapace 3", 300, 300, 257f, mainVariables.Ground_CarapaceBM);
            missile_Attacks1 = new Prefab("Missile Attacks 1", 100, 100, 114f, mainVariables.Missile_AttacksBM);
            missile_Attacks2 = new Prefab("Missile Attacks 2", 150, 150, 136f, mainVariables.Missile_AttacksBM);
            missile_Attacks3 = new Prefab("Missile Attacks 3", 200, 200, 157f, mainVariables.Missile_AttacksBM);
            flyer_Attacks1 = new Prefab("Flyer Attacks 1", 100, 100, 114f, mainVariables.Zerg_FlyerAttacksBM);
            flyer_Attacks2 = new Prefab("Flyer Attacks 2", 175, 175, 136f, mainVariables.Zerg_FlyerAttacksBM);
            flyer_Attacks3 = new Prefab("Flyer Attacks 3", 250, 250, 157f, mainVariables.Zerg_FlyerAttacksBM);
            flyer_Carapace1 = new Prefab("Flyer Carapace 1", 150, 150, 114f, mainVariables.Flyer_CarapaceBM);
            flyer_Carapace2 = new Prefab("Flyer Carapace 2", 225, 225, 136f, mainVariables.Flyer_CarapaceBM);
            flyer_Carapace3 = new Prefab("Flyer Carapace 3", 300, 300, 157, mainVariables.Flyer_CarapaceBM);
            chitinious_Plating = new Prefab("Chitinious Plating", 150, 150, 79f, mainVariables.Chitinous_PlatingBM);
            adaptive_Talons = new Prefab("Adaptive Talons", 150, 150, 57f, mainVariables.Adaptive_TalonsBM);
            anabolic_Synthesis = new Prefab("Anabolic Synthesis", 150, 150, 43f, mainVariables.Anabolic_SynthesisBM);
            centrifugal_Hooks = new Prefab("Centrifugal Hooks", 150, 150, 79f, mainVariables.Centrifugal_HooksBM);
            glial_Reconstitution = new Prefab("Glial Reconstitution", 100, 100, 79f, mainVariables.Glial_ReconstitutionBM);
            metabolic_Boost = new Prefab("Metabolic Boost", 100, 100, 79f, mainVariables.Metabolic_BoostBM);
            pneumatized_Carapace = new Prefab("Pneumatized Carapace", 100, 100, 43f, mainVariables.Pneumatited_CarapaceBM);
            muscular_Augments = new Prefab("Muscular Augments", 100, 100, 71f, mainVariables.Muscular_AugmentsBM);
            grooved_Spines = new Prefab("Grooved Spines", 100, 100, 71f, mainVariables.Grooved_SpinesBM);
            seismic_Spines = new Prefab("Seismic Spines", 150, 150, 57f, mainVariables.Seismic_SpinesBM);
            burrow = new Prefab("Burrow", 100, 100, 71f, mainVariables.BurrowBM);
            pathogen_Glands = new Prefab("Pathogen Glands", 150, 150, 57f, mainVariables.Pathogen_GlandsBM);
            neural_Parasite = new Prefab("Neural Parasite", 150, 150, 79f, mainVariables.Neural_ParasiteBM);
            adrenal_Glands = new Prefab("Adrenal Glands", 200, 200, 93f, mainVariables.Adrenal_GlandsBM);
            tunneling_Claws = new Prefab("Tunneling Claws", 100, 100, 79f, mainVariables.Tunneling_ClawsBM);

            upgrade_Array = new Prefab[] {adaptive_Talons, adrenal_Glands, anabolic_Synthesis, burrow, centrifugal_Hooks, chitinious_Plating, flyer_Attacks1,
            flyer_Carapace1, glial_Reconstitution, grooved_Spines, ground_Carapace1, melee_Attacks1, metabolic_Boost,
            missile_Attacks1, muscular_Augments, neural_Parasite, pathogen_Glands, pneumatized_Carapace, seismic_Spines, tunneling_Claws};

            mainMethods.Fill_Picturebox_Array(upgrade_Pictureboxes, upgrade_Array);
        }
        public void Protoss()
        {

        }
        public void Terran()
        {

        }
        //Updating the tooltip via clicking on the icon
        #region BuildingOnClick
        private void PicbBuilding8_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[7]);
        }

        private void PicbBuilding9_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[8]);
        }

        private void PicbBuilding10_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[9]);
        }

        private void PicbBuilding11_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[10]);
        }

        private void PicbBuilding12_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[11]);
        }

        private void PicbBuilding13_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[12]);
        }

        private void PicbBuilding14_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[13]);
        }

        private void PicbBuilding15_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[14]);
        }

        private void PicbBuilding16_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[15]);
        }

        private void PicbBuilding17_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[16]);
        }

        private void PicbBuilding18_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[17]);
        }

        private void PicbBuilding7_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[6]);
        }

        private void PicbBuilding6_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[5]);
        }

        private void PicbBuilding5_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[4]);
        }

        private void PicbBuilding4_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[3]);
        }

        private void PicbBuilding3_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[2]);
        }

        private void PicbBuilding2_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[1]);
        }

        private void PicbBuilding1_Click(object sender, EventArgs e)
        {
            Update_Tooltip(building_Array[0]);
        }
        #endregion

        #region UnitOnClick
        private void picbUnit7_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[6]);
        }

        private void picbUnit8_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[7]);
        }

        private void picbUnit9_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[8]);
        }

        private void picbUnit10_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[9]);
        }

        private void picbUnit11_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[10]);
        }

        private void picbUnit12_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[11]);
        }

        private void picbUnit13_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[12]);
        }

        private void picbUnit14_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[13]);
        }

        private void picbUnit15_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[14]);
        }

        private void picbUnit16_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[15]);
        }

        private void picbUnit17_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[16]);
        }

        private void picbUnit18_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[17]);
        }

        private void picbUnit19_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[18]);
        }

        private void picturepicbUnit20_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[19]);
        }

        private void picbUnit21_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[20]);
        }


        private void picbUnit22_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[21]);
        }

        private void picbUnit23_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[22]);
        }

        private void picbUnit24_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[23]);
        }

        private void picbUnit25_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[24]);
        }

        private void picbUnit26_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[25]);
        }

        private void picbUnit27_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[26]);
        }

        private void picbUnit28_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[27]);
        }

        private void picbUnit29_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[28]);
        }

        private void picbUnit30_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[29]);
        }

        private void picbUnit6_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[5]);
        }

        private void picbUnit5_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[4]);
        }

        private void picbUnit4_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[3]);
        }

        private void picbUnit3_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[2]);
        }

        private void picbUnit2_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[1]);
        }

        private void picbUnit1_Click(object sender, EventArgs e)
        {
            Update_Tooltip(unit_Array[0]);
        }
        #endregion

        #region UpgradeOnClick

        private void picbUpgrade8_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[7]);
        }

        private void picbUpgrade9_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[8]);
        }

        private void picbUpgrade10_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[9]);
        }

        private void picbUpgrade11_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[10]);
        }

        private void picbUpgrade12_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[11]);
        }

        private void picbUpgrade13_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[12]);
        }

        private void picbUpgrade14_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[13]);
        }

        private void picbUpgrade15_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[14]);
        }

        private void picbUpgrade16_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[15]);
        }

        private void picbUpgrade17_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[16]);
        }

        private void picbUpgrade18_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[17]);
        }

        private void picbUpgrade19_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[18]);
        }

        private void picbUpgrade20_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[19]);
        }

        private void picbUpgrade21_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[20]);
        }

        private void picbUpgrade22_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[21]);
        }

        private void picbUpgrade23_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[22]);
        }

        private void picbUpgrade24_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[23]);
        }

        private void picbUpgrade25_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[24]);
        }

        private void picbUpgrade26_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[25]);
        }

        private void picbUpgrade27_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[26]);
        }

        private void picbUpgrade28_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[27]);
        }

        private void picbUpgrade29_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[28]);
        }

        private void picbUpgrade30_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[29]);
        }

        private void picbUpgrade31_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[30]);
        }

        private void picbUpgrade32_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[31]);
        }

        private void picbUpgrade33_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[32]);
        }

        private void picbUpgrade34_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[33]);
        }

        private void picbUpgrade35_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[34]);
        }

        private void picbUpgrade36_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[35]);
        }

        private void picbUpgrade37_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[36]);
        }

        private void picbUpgrade38_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[37]);
        }

        private void picbUpgrade39_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[38]);
        }

        private void picbUpgrade40_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[39]);
        }

        private void picbUpgrade41_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[40]);
        }

        private void picbUpgrade42_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[41]);
        }

        private void picbUpgrade7_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[6]);
        }

        private void picbUpgrade6_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[5]);
        }

        private void picbUpgrade5_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[4]);
        }

        private void picbUpgrade4_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[3]);
        }

        private void picbUpgrade3_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[2]);
        }

        private void picbUpgrade2_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[1]);
        }

        private void picbUpgrade1_Click(object sender, EventArgs e)
        {
            Update_Tooltip(upgrade_Array[0]);
        }
        #endregion
        private void Update_Tooltip(Prefab prefab)
        {
            groupTooltip.Text = prefab.Name;
            lblMineralCost.Text = prefab.MineralCost.ToString();
            lblVespinCost.Text = prefab.VespinCost.ToString();
            lblTooltipTime.Text = prefab.BuildTime.ToString();
        }

        //Start of the drop/Drop event, building_Array[0] is a prefab
        private void picbBuilding1_MouseDown(object sender, MouseEventArgs e)
        {
            picbBuilding1.DoDragDrop(building_Array[0], DragDropEffects.Copy |
            DragDropEffects.Move);
        }
        //Entering the target of the drag/drop event (a trackbar), breakpoint doesnt get triggered
        private void trackbarTimeline_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Prefab)))
            { e.Effect = DragDropEffects.Copy; }
            else
            { e.Effect = DragDropEffects.None; }            
        }
        //dropping into the trackbar
        private void trackbarTimeline_DragDrop(object sender, DragEventArgs e)
        {
            Prefab prefabGiven = e.Data as Prefab;
            Update_Tooltip(prefabGiven);
        }


        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            Prefab prefabGiven = e.Data as Prefab;
            Update_Tooltip(prefabGiven);
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Prefab)))
            { e.Effect = DragDropEffects.Copy; }
            else
            { e.Effect = DragDropEffects.None; }
        }
    }
}
