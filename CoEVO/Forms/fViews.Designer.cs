namespace CoEVO.Forms
{
    partial class fViews
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FitnessHistory", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChromosomeID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POPSupplyingID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FitnessPorts");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FitnessShips");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FitnessChromosome");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dQueueService = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ds = new CoEVO.Forms.ds();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dChart = new Infragistics.Win.UltraWinChart.UltraChart();
            this.fitnessHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dPOPSupplying = new System.Windows.Forms.ComboBox();
            this.portsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.queueServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dQueueService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitnessHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queueServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dQueueService);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 545);
            this.splitContainer1.SplitterDistance = 603;
            this.splitContainer1.TabIndex = 0;
            // 
            // dQueueService
            // 
            this.dQueueService.DataSource = this.fitnessHistoryBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dQueueService.DisplayLayout.Appearance = appearance1;
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn10.Header.VisiblePosition = 3;
            ultraGridColumn11.Header.VisiblePosition = 4;
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
            this.dQueueService.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dQueueService.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dQueueService.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dQueueService.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dQueueService.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dQueueService.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dQueueService.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dQueueService.DisplayLayout.MaxColScrollRegions = 1;
            this.dQueueService.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dQueueService.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dQueueService.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dQueueService.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dQueueService.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dQueueService.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dQueueService.DisplayLayout.Override.CellAppearance = appearance8;
            this.dQueueService.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dQueueService.DisplayLayout.Override.CellPadding = 0;
            this.dQueueService.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dQueueService.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dQueueService.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dQueueService.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dQueueService.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dQueueService.DisplayLayout.Override.RowAppearance = appearance11;
            this.dQueueService.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dQueueService.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dQueueService.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dQueueService.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dQueueService.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dQueueService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dQueueService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dQueueService.Location = new System.Drawing.Point(0, 0);
            this.dQueueService.Name = "dQueueService";
            this.dQueueService.Size = new System.Drawing.Size(601, 543);
            this.dQueueService.TabIndex = 2;
            this.dQueueService.Text = "ultraGrid1";
            this.dQueueService.DoubleClick += new System.EventHandler(this.dQueueService_DoubleClick);
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer2.Panel1.Controls.Add(this.dPOPSupplying);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dChart);
            this.splitContainer2.Size = new System.Drawing.Size(543, 545);
            this.splitContainer2.SplitterDistance = 134;
            this.splitContainer2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FitnessPorts",
            "FitnessShips",
            "FitnessChromosome"});
            this.comboBox1.Location = new System.Drawing.Point(173, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.dOptionFitness_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chart Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data:";
            // 
//			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.dChart.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.LineChart;
            // 
            // dChart
            // 
            this.dChart.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.dChart.Axis.PE = paintElement1;
            this.dChart.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.dChart.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.dChart.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.dChart.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.dChart.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.dChart.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.dChart.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.X.Labels.SeriesLabels.Visible = true;
            this.dChart.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.X.Labels.Visible = true;
            this.dChart.Axis.X.LineThickness = 1;
            this.dChart.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.dChart.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.X.MajorGridLines.Visible = true;
            this.dChart.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.dChart.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.X.MinorGridLines.Visible = false;
            this.dChart.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.Shared.Styles.AxisIntervalType.Hours;
            this.dChart.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.dChart.Axis.X.Visible = true;
            this.dChart.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.dChart.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.dChart.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.dChart.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.dChart.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.dChart.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.dChart.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.dChart.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.dChart.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.X2.Labels.SeriesLabels.Visible = true;
            this.dChart.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.X2.Labels.Visible = false;
            this.dChart.Axis.X2.LineThickness = 1;
            this.dChart.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.dChart.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.X2.MajorGridLines.Visible = true;
            this.dChart.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.dChart.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.X2.MinorGridLines.Visible = false;
            this.dChart.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.Shared.Styles.AxisIntervalType.Hours;
            this.dChart.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.dChart.Axis.X2.Visible = false;
            this.dChart.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.dChart.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.dChart.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.dChart.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.dChart.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.dChart.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.dChart.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Y.Labels.SeriesLabels.Visible = true;
            this.dChart.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Y.Labels.Visible = true;
            this.dChart.Axis.Y.LineThickness = 1;
            this.dChart.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.dChart.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Y.MajorGridLines.Visible = true;
            this.dChart.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.dChart.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Y.MinorGridLines.Visible = false;
            this.dChart.Axis.Y.TickmarkInterval = 50D;
            this.dChart.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.dChart.Axis.Y.Visible = true;
            this.dChart.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.dChart.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.dChart.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.dChart.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.dChart.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Y2.Labels.SeriesLabels.Visible = true;
            this.dChart.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Y2.Labels.Visible = false;
            this.dChart.Axis.Y2.LineThickness = 1;
            this.dChart.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.dChart.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Y2.MajorGridLines.Visible = true;
            this.dChart.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.dChart.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Y2.MinorGridLines.Visible = false;
            this.dChart.Axis.Y2.TickmarkInterval = 50D;
            this.dChart.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.dChart.Axis.Y2.Visible = false;
            this.dChart.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.dChart.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.dChart.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.dChart.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Z.Labels.SeriesLabels.Visible = true;
            this.dChart.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Z.Labels.Visible = false;
            this.dChart.Axis.Z.LineThickness = 1;
            this.dChart.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.dChart.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Z.MajorGridLines.Visible = true;
            this.dChart.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.dChart.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Z.MinorGridLines.Visible = false;
            this.dChart.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.dChart.Axis.Z.Visible = false;
            this.dChart.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.dChart.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.dChart.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.dChart.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.dChart.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.dChart.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.dChart.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.dChart.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Z2.Labels.SeriesLabels.Visible = true;
            this.dChart.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.dChart.Axis.Z2.Labels.Visible = false;
            this.dChart.Axis.Z2.LineThickness = 1;
            this.dChart.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.dChart.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Z2.MajorGridLines.Visible = true;
            this.dChart.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.dChart.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.dChart.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.dChart.Axis.Z2.MinorGridLines.Visible = false;
            this.dChart.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.dChart.Axis.Z2.Visible = false;
            this.dChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dChart.ColorModel.AlphaLevel = ((byte)(150));
            this.dChart.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.dChart.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.dChart.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.dChart.Data.SwapRowsAndColumns = true;
            this.dChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dChart.Effects.Effects.Add(gradientEffect1);
            this.dChart.Location = new System.Drawing.Point(0, 0);
            this.dChart.Name = "dChart";
            this.dChart.Size = new System.Drawing.Size(541, 405);
            this.dChart.TabIndex = 0;
            this.dChart.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.dChart.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // fitnessHistoryBindingSource
            // 
            this.fitnessHistoryBindingSource.DataMember = "FitnessHistory";
            this.fitnessHistoryBindingSource.DataSource = this.ds;
            // 
            // dPOPSupplying
            // 
            this.dPOPSupplying.DataSource = this.ds;
            this.dPOPSupplying.DisplayMember = "Ports.Description";
            this.dPOPSupplying.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dPOPSupplying.FormattingEnabled = true;
            this.dPOPSupplying.Location = new System.Drawing.Point(6, 24);
            this.dPOPSupplying.Name = "dPOPSupplying";
            this.dPOPSupplying.Size = new System.Drawing.Size(128, 21);
            this.dPOPSupplying.TabIndex = 1;
            this.dPOPSupplying.ValueMember = "Ports.ID";
            this.dPOPSupplying.SelectedIndexChanged += new System.EventHandler(this.dOptionFitness_SelectedIndexChanged);
            // 
            // portsBindingSource
            // 
            this.portsBindingSource.DataMember = "Ports";
            this.portsBindingSource.DataSource = this.ds;
            // 
            // dsBindingSource
            // 
            this.dsBindingSource.DataSource = this.ds;
            this.dsBindingSource.Position = 0;
            // 
            // queueServiceBindingSource
            // 
            this.queueServiceBindingSource.DataMember = "QueueService";
            this.queueServiceBindingSource.DataSource = this.ds;
            // 
            // scheduleBindingSource
            // 
            this.scheduleBindingSource.DataMember = "Schedule";
            this.scheduleBindingSource.DataSource = this.ds;
            // 
            // fViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 545);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fViews";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fViews";
            this.Load += new System.EventHandler(this.fViews_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dQueueService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitnessHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queueServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.BindingSource queueServiceBindingSource;
        public ds ds;
        public System.Windows.Forms.BindingSource scheduleBindingSource;
        public System.Windows.Forms.BindingSource dsBindingSource;
        public Infragistics.Win.UltraWinGrid.UltraGrid dQueueService;
        private System.Windows.Forms.BindingSource fitnessHistoryBindingSource;
        private Infragistics.Win.UltraWinChart.UltraChart dChart;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox dPOPSupplying;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.BindingSource portsBindingSource;
    }
}