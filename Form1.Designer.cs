namespace _1500_Schach
{
    partial class Form1
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
            this.ChessBoard = new System.Windows.Forms.TableLayoutPanel();
            this.pawnChangeToQueen = new System.Windows.Forms.PictureBox();
            this.pawnChangeToRook = new System.Windows.Forms.PictureBox();
            this.pawnChangeToBishop = new System.Windows.Forms.PictureBox();
            this.pawnChangeToKnight = new System.Windows.Forms.PictureBox();
            this.changePawnTo_Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToKnight)).BeginInit();
            this.SuspendLayout();
            // 
            // ChessBoard
            // 
            this.ChessBoard.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ChessBoard.ColumnCount = 8;
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.Location = new System.Drawing.Point(20, 20);
            this.ChessBoard.Name = "ChessBoard";
            this.ChessBoard.RowCount = 8;
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ChessBoard.Size = new System.Drawing.Size(700, 700);
            this.ChessBoard.TabIndex = 0;
            this.ChessBoard.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.ChessBoard_CellPaint);
            this.ChessBoard.Click += new System.EventHandler(this.ChessBoard_Click);
            // 
            // pawnChangeToQueen
            // 
            this.pawnChangeToQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pawnChangeToQueen.Location = new System.Drawing.Point(781, 56);
            this.pawnChangeToQueen.Name = "pawnChangeToQueen";
            this.pawnChangeToQueen.Size = new System.Drawing.Size(83, 80);
            this.pawnChangeToQueen.TabIndex = 1;
            this.pawnChangeToQueen.TabStop = false;
            this.pawnChangeToQueen.Visible = false;
            this.pawnChangeToQueen.Click += new System.EventHandler(this.pawnChangeToQueen_Click);
            // 
            // pawnChangeToRook
            // 
            this.pawnChangeToRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pawnChangeToRook.Location = new System.Drawing.Point(870, 56);
            this.pawnChangeToRook.Name = "pawnChangeToRook";
            this.pawnChangeToRook.Size = new System.Drawing.Size(83, 80);
            this.pawnChangeToRook.TabIndex = 2;
            this.pawnChangeToRook.TabStop = false;
            this.pawnChangeToRook.Visible = false;
            this.pawnChangeToRook.Click += new System.EventHandler(this.pawnChangeToRook_Click);
            // 
            // pawnChangeToBishop
            // 
            this.pawnChangeToBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pawnChangeToBishop.Location = new System.Drawing.Point(781, 142);
            this.pawnChangeToBishop.Name = "pawnChangeToBishop";
            this.pawnChangeToBishop.Size = new System.Drawing.Size(83, 80);
            this.pawnChangeToBishop.TabIndex = 3;
            this.pawnChangeToBishop.TabStop = false;
            this.pawnChangeToBishop.Visible = false;
            this.pawnChangeToBishop.Click += new System.EventHandler(this.pawnChangeToBishop_Click);
            // 
            // pawnChangeToKnight
            // 
            this.pawnChangeToKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pawnChangeToKnight.Location = new System.Drawing.Point(870, 142);
            this.pawnChangeToKnight.Name = "pawnChangeToKnight";
            this.pawnChangeToKnight.Size = new System.Drawing.Size(83, 80);
            this.pawnChangeToKnight.TabIndex = 4;
            this.pawnChangeToKnight.TabStop = false;
            this.pawnChangeToKnight.Visible = false;
            this.pawnChangeToKnight.Click += new System.EventHandler(this.pawnChangeToKnight_Click);
            // 
            // changePawnTo_Title
            // 
            this.changePawnTo_Title.AutoSize = true;
            this.changePawnTo_Title.Location = new System.Drawing.Point(781, 37);
            this.changePawnTo_Title.Name = "changePawnTo_Title";
            this.changePawnTo_Title.Size = new System.Drawing.Size(115, 13);
            this.changePawnTo_Title.TabIndex = 5;
            this.changePawnTo_Title.Text = "Change your Pawn to?";
            this.changePawnTo_Title.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1199, 745);
            this.Controls.Add(this.changePawnTo_Title);
            this.Controls.Add(this.pawnChangeToKnight);
            this.Controls.Add(this.pawnChangeToBishop);
            this.Controls.Add(this.pawnChangeToRook);
            this.Controls.Add(this.pawnChangeToQueen);
            this.Controls.Add(this.ChessBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChangeToKnight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ChessBoard;
        private System.Windows.Forms.PictureBox pawnChangeToQueen;
        private System.Windows.Forms.PictureBox pawnChangeToRook;
        private System.Windows.Forms.PictureBox pawnChangeToBishop;
        private System.Windows.Forms.PictureBox pawnChangeToKnight;
        private System.Windows.Forms.Label changePawnTo_Title;
    }
}

