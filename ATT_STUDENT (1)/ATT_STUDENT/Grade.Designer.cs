namespace ATT_STUDENT
{
    partial class Grade
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
            this.dtgScore = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.txtcontent = new System.Windows.Forms.Label();
            this.txtScorename = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtCourseID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.tbTimKiemTheoMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScoreID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgScore)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgScore
            // 
            this.dtgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgScore.Location = new System.Drawing.Point(408, 159);
            this.dtgScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgScore.Name = "dtgScore";
            this.dtgScore.RowHeadersWidth = 51;
            this.dtgScore.Size = new System.Drawing.Size(1037, 517);
            this.dtgScore.TabIndex = 11;
            this.dtgScore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgScore_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 143);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "Details";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbCourse);
            this.panel2.Controls.Add(this.cmbStudent);
            this.panel2.Controls.Add(this.txtcontent);
            this.panel2.Controls.Add(this.txtScorename);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtP2);
            this.panel2.Controls.Add(this.txtFinal);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtStudentID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtP1);
            this.panel2.Controls.Add(this.txtCourseID);
            this.panel2.Location = new System.Drawing.Point(3, 159);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 516);
            this.panel2.TabIndex = 10;
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(193, 85);
            this.cmbCourse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(169, 24);
            this.cmbCourse.TabIndex = 44;
            // 
            // cmbStudent
            // 
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(193, 33);
            this.cmbStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(169, 24);
            this.cmbStudent.TabIndex = 43;
            // 
            // txtcontent
            // 
            this.txtcontent.AutoSize = true;
            this.txtcontent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontent.Location = new System.Drawing.Point(19, 145);
            this.txtcontent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtcontent.Name = "txtcontent";
            this.txtcontent.Size = new System.Drawing.Size(97, 20);
            this.txtcontent.TabIndex = 41;
            this.txtcontent.Text = "ScoreName";
            // 
            // txtScorename
            // 
            this.txtScorename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScorename.Location = new System.Drawing.Point(193, 142);
            this.txtScorename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtScorename.Name = "txtScorename";
            this.txtScorename.Size = new System.Drawing.Size(169, 26);
            this.txtScorename.TabIndex = 42;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(213, 454);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 46);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(51, 454);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 46);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(213, 389);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(99, 46);
            this.btnUp.TabIndex = 38;
            this.btnUp.Text = "Update";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(51, 389);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 46);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtP2
            // 
            this.txtP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP2.Location = new System.Drawing.Point(193, 242);
            this.txtP2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(169, 26);
            this.txtP2.TabIndex = 36;
            this.txtP2.Text = "0";
            // 
            // txtFinal
            // 
            this.txtFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinal.Location = new System.Drawing.Point(193, 295);
            this.txtFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(169, 26);
            this.txtFinal.TabIndex = 35;
            this.txtFinal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 244);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Part 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 300);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Final Score";
            // 
            // txtStudentID
            // 
            this.txtStudentID.AutoSize = true;
            this.txtStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(19, 33);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(83, 20);
            this.txtStudentID.TabIndex = 12;
            this.txtStudentID.Text = "StudentID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 198);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Part 1";
            // 
            // txtP1
            // 
            this.txtP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP1.Location = new System.Drawing.Point(193, 194);
            this.txtP1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(169, 26);
            this.txtP1.TabIndex = 9;
            this.txtP1.Text = "0";
            // 
            // txtCourseID
            // 
            this.txtCourseID.AutoSize = true;
            this.txtCourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCourseID.Location = new System.Drawing.Point(19, 85);
            this.txtCourseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.Size = new System.Drawing.Size(80, 20);
            this.txtCourseID.TabIndex = 2;
            this.txtCourseID.Text = "CourseID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.tbTimKiemTheoMa);
            this.panel1.Location = new System.Drawing.Point(408, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 71);
            this.panel1.TabIndex = 8;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.DarkCyan;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnTimKiem.Location = new System.Drawing.Point(427, 10);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 43);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Search";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // tbTimKiemTheoMa
            // 
            this.tbTimKiemTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiemTheoMa.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbTimKiemTheoMa.Location = new System.Drawing.Point(37, 25);
            this.tbTimKiemTheoMa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTimKiemTheoMa.Name = "tbTimKiemTheoMa";
            this.tbTimKiemTheoMa.Size = new System.Drawing.Size(304, 26);
            this.tbTimKiemTheoMa.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(540, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Score Management";
            // 
            // txtScoreID
            // 
            this.txtScoreID.AutoSize = true;
            this.txtScoreID.Location = new System.Drawing.Point(1384, 14);
            this.txtScoreID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtScoreID.Name = "txtScoreID";
            this.txtScoreID.Size = new System.Drawing.Size(44, 16);
            this.txtScoreID.TabIndex = 48;
            this.txtScoreID.Text = "label3";
            this.txtScoreID.Visible = false;
            // 
            // Grade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(1447, 681);
            this.Controls.Add(this.txtScoreID);
            this.Controls.Add(this.dtgScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Grade";
            this.Text = "Grade";
            this.Load += new System.EventHandler(this.Grade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgScore)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgScore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtStudentID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.Label txtCourseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox tbTimKiemTheoMa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label txtScoreID;
        private System.Windows.Forms.Label txtcontent;
        private System.Windows.Forms.TextBox txtScorename;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ComboBox cmbCourse;
    }
}