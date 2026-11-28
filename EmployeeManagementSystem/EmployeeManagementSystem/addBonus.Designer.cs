namespace EmployeeManagementSystem
{
    partial class addBonus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.addBonus_Reason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addBonus_Month = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addBonus_Year = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addBonus_Amount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addBonus_clearBtn = new System.Windows.Forms.Button();
            this.addBonus_deleteBtn = new System.Windows.Forms.Button();
            this.addBonus_updateBtn = new System.Windows.Forms.Button();
            this.addBonus_addBtn = new System.Windows.Forms.Button();
            this.addBonus_EmployeeFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addBonus_EmployeeCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.addBonus_BonusCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(27, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 428);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(33, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1197, 297);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bonus\'s Data";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 460);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1258, 348);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.addBonus_BonusCode);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.addBonus_Reason);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.addBonus_Month);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.addBonus_Year);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.addBonus_Amount);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.addBonus_clearBtn);
            this.panel3.Controls.Add(this.addBonus_deleteBtn);
            this.panel3.Controls.Add(this.addBonus_updateBtn);
            this.panel3.Controls.Add(this.addBonus_addBtn);
            this.panel3.Controls.Add(this.addBonus_EmployeeFullName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.addBonus_EmployeeCode);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(27, 497);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1258, 330);
            this.panel3.TabIndex = 2;
            // 
            // addBonus_Reason
            // 
            this.addBonus_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_Reason.Location = new System.Drawing.Point(927, 21);
            this.addBonus_Reason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_Reason.Multiline = true;
            this.addBonus_Reason.Name = "addBonus_Reason";
            this.addBonus_Reason.Size = new System.Drawing.Size(249, 85);
            this.addBonus_Reason.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(822, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 22);
            this.label6.TabIndex = 26;
            this.label6.Text = "Reason:";
            // 
            // addBonus_Month
            // 
            this.addBonus_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_Month.Location = new System.Drawing.Point(561, 89);
            this.addBonus_Month.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_Month.Name = "addBonus_Month";
            this.addBonus_Month.Size = new System.Drawing.Size(199, 28);
            this.addBonus_Month.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(481, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "Month:";
            // 
            // addBonus_Year
            // 
            this.addBonus_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_Year.Location = new System.Drawing.Point(561, 18);
            this.addBonus_Year.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_Year.Name = "addBonus_Year";
            this.addBonus_Year.Size = new System.Drawing.Size(199, 28);
            this.addBonus_Year.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(484, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 22);
            this.label4.TabIndex = 22;
            this.label4.Text = "Year:";
            // 
            // addBonus_Amount
            // 
            this.addBonus_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_Amount.Location = new System.Drawing.Point(576, 153);
            this.addBonus_Amount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_Amount.Name = "addBonus_Amount";
            this.addBonus_Amount.Size = new System.Drawing.Size(199, 28);
            this.addBonus_Amount.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(472, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = "Amount:";
            // 
            // addBonus_clearBtn
            // 
            this.addBonus_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addBonus_clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBonus_clearBtn.FlatAppearance.BorderSize = 0;
            this.addBonus_clearBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBonus_clearBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_clearBtn.ForeColor = System.Drawing.Color.White;
            this.addBonus_clearBtn.Location = new System.Drawing.Point(886, 251);
            this.addBonus_clearBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_clearBtn.Name = "addBonus_clearBtn";
            this.addBonus_clearBtn.Size = new System.Drawing.Size(170, 57);
            this.addBonus_clearBtn.TabIndex = 17;
            this.addBonus_clearBtn.Text = "Clear";
            this.addBonus_clearBtn.UseVisualStyleBackColor = false;
            this.addBonus_clearBtn.Click += new System.EventHandler(this.addBonus_clearBtn_Click);
            // 
            // addBonus_deleteBtn
            // 
            this.addBonus_deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addBonus_deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBonus_deleteBtn.FlatAppearance.BorderSize = 0;
            this.addBonus_deleteBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBonus_deleteBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.addBonus_deleteBtn.Location = new System.Drawing.Point(692, 251);
            this.addBonus_deleteBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_deleteBtn.Name = "addBonus_deleteBtn";
            this.addBonus_deleteBtn.Size = new System.Drawing.Size(170, 57);
            this.addBonus_deleteBtn.TabIndex = 16;
            this.addBonus_deleteBtn.Text = "Delete";
            this.addBonus_deleteBtn.UseVisualStyleBackColor = false;
            this.addBonus_deleteBtn.Click += new System.EventHandler(this.addBonus_deleteBtn_Click);
            // 
            // addBonus_updateBtn
            // 
            this.addBonus_updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addBonus_updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBonus_updateBtn.FlatAppearance.BorderSize = 0;
            this.addBonus_updateBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_updateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_updateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBonus_updateBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_updateBtn.ForeColor = System.Drawing.Color.White;
            this.addBonus_updateBtn.Location = new System.Drawing.Point(468, 251);
            this.addBonus_updateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_updateBtn.Name = "addBonus_updateBtn";
            this.addBonus_updateBtn.Size = new System.Drawing.Size(170, 57);
            this.addBonus_updateBtn.TabIndex = 15;
            this.addBonus_updateBtn.Text = "Update";
            this.addBonus_updateBtn.UseVisualStyleBackColor = false;
            this.addBonus_updateBtn.Click += new System.EventHandler(this.addBonus_updateBtn_Click);
            // 
            // addBonus_addBtn
            // 
            this.addBonus_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addBonus_addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBonus_addBtn.FlatAppearance.BorderSize = 0;
            this.addBonus_addBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBonus_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBonus_addBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_addBtn.ForeColor = System.Drawing.Color.White;
            this.addBonus_addBtn.Location = new System.Drawing.Point(273, 251);
            this.addBonus_addBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_addBtn.Name = "addBonus_addBtn";
            this.addBonus_addBtn.Size = new System.Drawing.Size(170, 57);
            this.addBonus_addBtn.TabIndex = 14;
            this.addBonus_addBtn.Text = "Add";
            this.addBonus_addBtn.UseVisualStyleBackColor = false;
            this.addBonus_addBtn.Click += new System.EventHandler(this.addBonus_addBtn_Click);
            // 
            // addBonus_EmployeeFullName
            // 
            this.addBonus_EmployeeFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_EmployeeFullName.Location = new System.Drawing.Point(168, 159);
            this.addBonus_EmployeeFullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_EmployeeFullName.Name = "addBonus_EmployeeFullName";
            this.addBonus_EmployeeFullName.Size = new System.Drawing.Size(253, 28);
            this.addBonus_EmployeeFullName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Full Name:";
            // 
            // addBonus_EmployeeCode
            // 
            this.addBonus_EmployeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_EmployeeCode.Location = new System.Drawing.Point(168, 95);
            this.addBonus_EmployeeCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_EmployeeCode.Name = "addBonus_EmployeeCode";
            this.addBonus_EmployeeCode.Size = new System.Drawing.Size(199, 28);
            this.addBonus_EmployeeCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee Code:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Location = new System.Drawing.Point(0, 460);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1258, 348);
            this.panel4.TabIndex = 1;
            // 
            // addBonus_BonusCode
            // 
            this.addBonus_BonusCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBonus_BonusCode.Location = new System.Drawing.Point(168, 24);
            this.addBonus_BonusCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBonus_BonusCode.Name = "addBonus_BonusCode";
            this.addBonus_BonusCode.Size = new System.Drawing.Size(199, 28);
            this.addBonus_BonusCode.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 28;
            this.label7.Text = "Bonus Code:";
            // 
            // addBonus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "addBonus";
            this.Size = new System.Drawing.Size(1312, 869);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addBonus_EmployeeFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addBonus_EmployeeCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBonus_clearBtn;
        private System.Windows.Forms.Button addBonus_deleteBtn;
        private System.Windows.Forms.Button addBonus_updateBtn;
        private System.Windows.Forms.Button addBonus_addBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox addBonus_Amount;
        private System.Windows.Forms.TextBox addBonus_Year;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addBonus_Reason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox addBonus_Month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addBonus_BonusCode;
        private System.Windows.Forms.Label label7;
    }
}
