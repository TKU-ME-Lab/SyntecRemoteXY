namespace SyntecRemoteXY
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_buttonStatus = new System.Windows.Forms.Button();
            this.m_textBoxIP = new System.Windows.Forms.TextBox();
            this.m_labelIP = new System.Windows.Forms.Label();
            this.m_buttonConnect = new System.Windows.Forms.Button();
            this.m_groupBoxIP = new System.Windows.Forms.GroupBox();
            this.m_groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.m_labelYVal = new System.Windows.Forms.Label();
            this.m_labelXVal = new System.Windows.Forms.Label();
            this.m_labelYName = new System.Windows.Forms.Label();
            this.m_labelXName = new System.Windows.Forms.Label();
            this.m_listBoxLog = new System.Windows.Forms.ListBox();
            this.m_groupBoxRWbit = new System.Windows.Forms.GroupBox();
            this.m_comboBoxBitMode = new System.Windows.Forms.ComboBox();
            this.m_comboBoxBitType = new System.Windows.Forms.ComboBox();
            this.m_textBoxBitValue = new System.Windows.Forms.TextBox();
            this.m_textBoxBitNo = new System.Windows.Forms.TextBox();
            this.m_labelBitValue = new System.Windows.Forms.Label();
            this.m_labelBitNo = new System.Windows.Forms.Label();
            this.m_labelBitType = new System.Windows.Forms.Label();
            this.m_labelBitMode = new System.Windows.Forms.Label();
            this.m_timerReadPos = new System.Windows.Forms.Timer(this.components);
            this.m_timerstatus = new System.Windows.Forms.Timer(this.components);
            this.m_buttonStop = new System.Windows.Forms.Button();
            this.m_groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.m_labelStatusVal = new System.Windows.Forms.Label();
            this.m_labelModeVal = new System.Windows.Forms.Label();
            this.m_labelModeName = new System.Windows.Forms.Label();
            this.m_labelStatusName = new System.Windows.Forms.Label();
            this.m_groupBoxIP.SuspendLayout();
            this.m_groupBoxPosition.SuspendLayout();
            this.m_groupBoxRWbit.SuspendLayout();
            this.m_groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_buttonStatus
            // 
            this.m_buttonStatus.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_buttonStatus.Location = new System.Drawing.Point(37, 45);
            this.m_buttonStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_buttonStatus.Name = "m_buttonStatus";
            this.m_buttonStatus.Size = new System.Drawing.Size(109, 42);
            this.m_buttonStatus.TabIndex = 0;
            this.m_buttonStatus.Text = "Status";
            this.m_buttonStatus.UseVisualStyleBackColor = true;
            this.m_buttonStatus.Click += new System.EventHandler(this.m_buttonStatus_Click);
            // 
            // m_textBoxIP
            // 
            this.m_textBoxIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBoxIP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_textBoxIP.Location = new System.Drawing.Point(613, 42);
            this.m_textBoxIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_textBoxIP.Name = "m_textBoxIP";
            this.m_textBoxIP.Size = new System.Drawing.Size(139, 30);
            this.m_textBoxIP.TabIndex = 2;
            this.m_textBoxIP.Text = "192.168.0.101";
            // 
            // m_labelIP
            // 
            this.m_labelIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelIP.AutoSize = true;
            this.m_labelIP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelIP.Location = new System.Drawing.Point(9, 21);
            this.m_labelIP.Name = "m_labelIP";
            this.m_labelIP.Size = new System.Drawing.Size(49, 34);
            this.m_labelIP.TabIndex = 3;
            this.m_labelIP.Text = "IP:";
            // 
            // m_buttonConnect
            // 
            this.m_buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_buttonConnect.Location = new System.Drawing.Point(758, 35);
            this.m_buttonConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_buttonConnect.Name = "m_buttonConnect";
            this.m_buttonConnect.Size = new System.Drawing.Size(111, 42);
            this.m_buttonConnect.TabIndex = 4;
            this.m_buttonConnect.Text = "Connect";
            this.m_buttonConnect.UseVisualStyleBackColor = true;
            this.m_buttonConnect.Click += new System.EventHandler(this.m_buttonConnect_Click);
            // 
            // m_groupBoxIP
            // 
            this.m_groupBoxIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_groupBoxIP.Controls.Add(this.m_labelIP);
            this.m_groupBoxIP.Location = new System.Drawing.Point(548, 20);
            this.m_groupBoxIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_groupBoxIP.Name = "m_groupBoxIP";
            this.m_groupBoxIP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_groupBoxIP.Size = new System.Drawing.Size(325, 68);
            this.m_groupBoxIP.TabIndex = 5;
            this.m_groupBoxIP.TabStop = false;
            // 
            // m_groupBoxPosition
            // 
            this.m_groupBoxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_groupBoxPosition.Controls.Add(this.m_labelYVal);
            this.m_groupBoxPosition.Controls.Add(this.m_labelXVal);
            this.m_groupBoxPosition.Controls.Add(this.m_labelYName);
            this.m_groupBoxPosition.Controls.Add(this.m_labelXName);
            this.m_groupBoxPosition.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_groupBoxPosition.Location = new System.Drawing.Point(548, 91);
            this.m_groupBoxPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_groupBoxPosition.Name = "m_groupBoxPosition";
            this.m_groupBoxPosition.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_groupBoxPosition.Size = new System.Drawing.Size(325, 169);
            this.m_groupBoxPosition.TabIndex = 6;
            this.m_groupBoxPosition.TabStop = false;
            this.m_groupBoxPosition.Text = "Position";
            // 
            // m_labelYVal
            // 
            this.m_labelYVal.AutoSize = true;
            this.m_labelYVal.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelYVal.Location = new System.Drawing.Point(158, 103);
            this.m_labelYVal.Name = "m_labelYVal";
            this.m_labelYVal.Size = new System.Drawing.Size(40, 46);
            this.m_labelYVal.TabIndex = 40;
            this.m_labelYVal.Text = "0";
            // 
            // m_labelXVal
            // 
            this.m_labelXVal.AutoSize = true;
            this.m_labelXVal.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelXVal.Location = new System.Drawing.Point(158, 33);
            this.m_labelXVal.Name = "m_labelXVal";
            this.m_labelXVal.Size = new System.Drawing.Size(40, 46);
            this.m_labelXVal.TabIndex = 35;
            this.m_labelXVal.Text = "0";
            // 
            // m_labelYName
            // 
            this.m_labelYName.AutoSize = true;
            this.m_labelYName.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelYName.Location = new System.Drawing.Point(13, 103);
            this.m_labelYName.Name = "m_labelYName";
            this.m_labelYName.Size = new System.Drawing.Size(56, 46);
            this.m_labelYName.TabIndex = 34;
            this.m_labelYName.Text = "Y:";
            // 
            // m_labelXName
            // 
            this.m_labelXName.AutoSize = true;
            this.m_labelXName.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelXName.Location = new System.Drawing.Point(13, 33);
            this.m_labelXName.Name = "m_labelXName";
            this.m_labelXName.Size = new System.Drawing.Size(60, 46);
            this.m_labelXName.TabIndex = 29;
            this.m_labelXName.Text = "X:";
            // 
            // m_listBoxLog
            // 
            this.m_listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listBoxLog.FormattingEnabled = true;
            this.m_listBoxLog.ItemHeight = 15;
            this.m_listBoxLog.Location = new System.Drawing.Point(12, 271);
            this.m_listBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_listBoxLog.Name = "m_listBoxLog";
            this.m_listBoxLog.Size = new System.Drawing.Size(521, 229);
            this.m_listBoxLog.TabIndex = 7;
            // 
            // m_groupBoxRWbit
            // 
            this.m_groupBoxRWbit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_groupBoxRWbit.Controls.Add(this.m_comboBoxBitMode);
            this.m_groupBoxRWbit.Controls.Add(this.m_comboBoxBitType);
            this.m_groupBoxRWbit.Controls.Add(this.m_textBoxBitValue);
            this.m_groupBoxRWbit.Controls.Add(this.m_textBoxBitNo);
            this.m_groupBoxRWbit.Controls.Add(this.m_labelBitValue);
            this.m_groupBoxRWbit.Controls.Add(this.m_labelBitNo);
            this.m_groupBoxRWbit.Controls.Add(this.m_labelBitType);
            this.m_groupBoxRWbit.Controls.Add(this.m_labelBitMode);
            this.m_groupBoxRWbit.Location = new System.Drawing.Point(548, 262);
            this.m_groupBoxRWbit.Name = "m_groupBoxRWbit";
            this.m_groupBoxRWbit.Size = new System.Drawing.Size(325, 239);
            this.m_groupBoxRWbit.TabIndex = 8;
            this.m_groupBoxRWbit.TabStop = false;
            // 
            // m_comboBoxBitMode
            // 
            this.m_comboBoxBitMode.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_comboBoxBitMode.FormattingEnabled = true;
            this.m_comboBoxBitMode.Items.AddRange(new object[] {
            "Read",
            "Write"});
            this.m_comboBoxBitMode.Location = new System.Drawing.Point(205, 14);
            this.m_comboBoxBitMode.Name = "m_comboBoxBitMode";
            this.m_comboBoxBitMode.Size = new System.Drawing.Size(97, 39);
            this.m_comboBoxBitMode.TabIndex = 7;
            this.m_comboBoxBitMode.SelectedIndexChanged += new System.EventHandler(this.m_comboBoxBitMode_SelectedIndexChanged);
            // 
            // m_comboBoxBitType
            // 
            this.m_comboBoxBitType.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_comboBoxBitType.FormattingEnabled = true;
            this.m_comboBoxBitType.Items.AddRange(new object[] {
            "I",
            "R",
            "C"});
            this.m_comboBoxBitType.Location = new System.Drawing.Point(205, 73);
            this.m_comboBoxBitType.Name = "m_comboBoxBitType";
            this.m_comboBoxBitType.Size = new System.Drawing.Size(97, 39);
            this.m_comboBoxBitType.TabIndex = 6;
            this.m_comboBoxBitType.SelectedIndexChanged += new System.EventHandler(this.m_comboBoxBitType_SelectedIndexChanged);
            // 
            // m_textBoxBitValue
            // 
            this.m_textBoxBitValue.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_textBoxBitValue.Location = new System.Drawing.Point(163, 191);
            this.m_textBoxBitValue.Name = "m_textBoxBitValue";
            this.m_textBoxBitValue.Size = new System.Drawing.Size(139, 39);
            this.m_textBoxBitValue.TabIndex = 5;
            this.m_textBoxBitValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_textBoxBitValue_KeyPress);
            // 
            // m_textBoxBitNo
            // 
            this.m_textBoxBitNo.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_textBoxBitNo.Location = new System.Drawing.Point(163, 132);
            this.m_textBoxBitNo.Name = "m_textBoxBitNo";
            this.m_textBoxBitNo.Size = new System.Drawing.Size(139, 39);
            this.m_textBoxBitNo.TabIndex = 4;
            this.m_textBoxBitNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_textBoxBitNo_KeyPress);
            // 
            // m_labelBitValue
            // 
            this.m_labelBitValue.AutoSize = true;
            this.m_labelBitValue.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelBitValue.Location = new System.Drawing.Point(6, 185);
            this.m_labelBitValue.Name = "m_labelBitValue";
            this.m_labelBitValue.Size = new System.Drawing.Size(122, 46);
            this.m_labelBitValue.TabIndex = 3;
            this.m_labelBitValue.Text = "Value:";
            // 
            // m_labelBitNo
            // 
            this.m_labelBitNo.AutoSize = true;
            this.m_labelBitNo.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelBitNo.Location = new System.Drawing.Point(6, 128);
            this.m_labelBitNo.Name = "m_labelBitNo";
            this.m_labelBitNo.Size = new System.Drawing.Size(78, 46);
            this.m_labelBitNo.TabIndex = 2;
            this.m_labelBitNo.Text = "No.";
            // 
            // m_labelBitType
            // 
            this.m_labelBitType.AutoSize = true;
            this.m_labelBitType.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelBitType.Location = new System.Drawing.Point(6, 71);
            this.m_labelBitType.Name = "m_labelBitType";
            this.m_labelBitType.Size = new System.Drawing.Size(106, 46);
            this.m_labelBitType.TabIndex = 1;
            this.m_labelBitType.Text = "Type:";
            // 
            // m_labelBitMode
            // 
            this.m_labelBitMode.AutoSize = true;
            this.m_labelBitMode.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelBitMode.Location = new System.Drawing.Point(6, 14);
            this.m_labelBitMode.Name = "m_labelBitMode";
            this.m_labelBitMode.Size = new System.Drawing.Size(123, 46);
            this.m_labelBitMode.TabIndex = 0;
            this.m_labelBitMode.Text = "Mode:";
            // 
            // m_timerReadPos
            // 
            this.m_timerReadPos.Interval = 5;
            this.m_timerReadPos.Tick += new System.EventHandler(this.m_timerReadPos_Tick);
            // 
            // m_timerstatus
            // 
            this.m_timerstatus.Tick += new System.EventHandler(this.m_timerstatus_Tick);
            // 
            // m_buttonStop
            // 
            this.m_buttonStop.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_buttonStop.Location = new System.Drawing.Point(37, 105);
            this.m_buttonStop.Name = "m_buttonStop";
            this.m_buttonStop.Size = new System.Drawing.Size(109, 44);
            this.m_buttonStop.TabIndex = 9;
            this.m_buttonStop.Text = "Stop";
            this.m_buttonStop.UseVisualStyleBackColor = true;
            this.m_buttonStop.Click += new System.EventHandler(this.m_buttonStop_Click);
            // 
            // m_groupBoxStatus
            // 
            this.m_groupBoxStatus.Controls.Add(this.m_labelStatusVal);
            this.m_groupBoxStatus.Controls.Add(this.m_labelModeVal);
            this.m_groupBoxStatus.Controls.Add(this.m_labelModeName);
            this.m_groupBoxStatus.Controls.Add(this.m_labelStatusName);
            this.m_groupBoxStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_groupBoxStatus.Location = new System.Drawing.Point(292, 20);
            this.m_groupBoxStatus.Name = "m_groupBoxStatus";
            this.m_groupBoxStatus.Size = new System.Drawing.Size(241, 129);
            this.m_groupBoxStatus.TabIndex = 10;
            this.m_groupBoxStatus.TabStop = false;
            this.m_groupBoxStatus.Text = "System Status";
            // 
            // m_labelStatusVal
            // 
            this.m_labelStatusVal.AutoSize = true;
            this.m_labelStatusVal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelStatusVal.Location = new System.Drawing.Point(91, 41);
            this.m_labelStatusVal.Name = "m_labelStatusVal";
            this.m_labelStatusVal.Size = new System.Drawing.Size(142, 27);
            this.m_labelStatusVal.TabIndex = 4;
            this.m_labelStatusVal.Text = "NOTREADY";
            // 
            // m_labelModeVal
            // 
            this.m_labelModeVal.AutoSize = true;
            this.m_labelModeVal.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelModeVal.Location = new System.Drawing.Point(91, 85);
            this.m_labelModeVal.Name = "m_labelModeVal";
            this.m_labelModeVal.Size = new System.Drawing.Size(128, 27);
            this.m_labelModeVal.TabIndex = 2;
            this.m_labelModeVal.Text = "No Connect";
            // 
            // m_labelModeName
            // 
            this.m_labelModeName.AutoSize = true;
            this.m_labelModeName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelModeName.Location = new System.Drawing.Point(7, 85);
            this.m_labelModeName.Name = "m_labelModeName";
            this.m_labelModeName.Size = new System.Drawing.Size(74, 27);
            this.m_labelModeName.TabIndex = 1;
            this.m_labelModeName.Text = "Mode:";
            // 
            // m_labelStatusName
            // 
            this.m_labelStatusName.AutoSize = true;
            this.m_labelStatusName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelStatusName.Location = new System.Drawing.Point(7, 39);
            this.m_labelStatusName.Name = "m_labelStatusName";
            this.m_labelStatusName.Size = new System.Drawing.Size(76, 27);
            this.m_labelStatusName.TabIndex = 0;
            this.m_labelStatusName.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 514);
            this.Controls.Add(this.m_groupBoxStatus);
            this.Controls.Add(this.m_buttonStop);
            this.Controls.Add(this.m_groupBoxRWbit);
            this.Controls.Add(this.m_listBoxLog);
            this.Controls.Add(this.m_buttonConnect);
            this.Controls.Add(this.m_textBoxIP);
            this.Controls.Add(this.m_buttonStatus);
            this.Controls.Add(this.m_groupBoxIP);
            this.Controls.Add(this.m_groupBoxPosition);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.m_groupBoxIP.ResumeLayout(false);
            this.m_groupBoxIP.PerformLayout();
            this.m_groupBoxPosition.ResumeLayout(false);
            this.m_groupBoxPosition.PerformLayout();
            this.m_groupBoxRWbit.ResumeLayout(false);
            this.m_groupBoxRWbit.PerformLayout();
            this.m_groupBoxStatus.ResumeLayout(false);
            this.m_groupBoxStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_buttonStatus;
        private System.Windows.Forms.TextBox m_textBoxIP;
        private System.Windows.Forms.Label m_labelIP;
        private System.Windows.Forms.Button m_buttonConnect;
        private System.Windows.Forms.GroupBox m_groupBoxIP;
        private System.Windows.Forms.GroupBox m_groupBoxPosition;
        private System.Windows.Forms.ListBox m_listBoxLog;
        private System.Windows.Forms.GroupBox m_groupBoxRWbit;
        private System.Windows.Forms.Label m_labelBitValue;
        private System.Windows.Forms.Label m_labelBitNo;
        private System.Windows.Forms.Label m_labelBitType;
        private System.Windows.Forms.Label m_labelBitMode;
        private System.Windows.Forms.TextBox m_textBoxBitNo;
        private System.Windows.Forms.ComboBox m_comboBoxBitMode;
        private System.Windows.Forms.ComboBox m_comboBoxBitType;
        private System.Windows.Forms.Label m_labelYVal;
        private System.Windows.Forms.Label m_labelXVal;
        private System.Windows.Forms.Label m_labelYName;
        private System.Windows.Forms.Label m_labelXName;
        private System.Windows.Forms.Timer m_timerReadPos;
        private System.Windows.Forms.TextBox m_textBoxBitValue;
        private System.Windows.Forms.Timer m_timerstatus;
        private System.Windows.Forms.Button m_buttonStop;
        private System.Windows.Forms.GroupBox m_groupBoxStatus;
        private System.Windows.Forms.Label m_labelStatusName;
        private System.Windows.Forms.Label m_labelModeVal;
        private System.Windows.Forms.Label m_labelModeName;
        private System.Windows.Forms.Label m_labelStatusVal;
    }
}

