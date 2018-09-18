using FileDiff.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileDiff.Model;
using FileDiff.ViewModel;
using Model.FileDiff;

namespace FileDiff.Presenter
{
    public class MainPresenter
    {
        private MainView _view;
        private List<string> _firstLines;
        private List<string> _secondLines;
        private MainViewModel _mainViewModel;

        public MainPresenter()
        {
            _view = new MainView();
            _view.Closed += OnViewClosed;
            _mainViewModel = new MainViewModel();
            _view.bindingSource1.DataSource = _mainViewModel;

            _view.FirstFileButton.Click += FirstFileButtonOnClick;
            _view.SecondFileButton.Click += SecondFileButton_Click;
            _view.ResultButton.Click += ResultButtonOnClick;
            _view.listBox1.DrawItem += new DrawItemEventHandler(TestListBox_DrawItem);

        }

        private void TestListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!(_view.listBox1.Items[e.Index] is DiffLine item)) return;
            var color = Color.Green;

            switch (item.DiffType)
            {
                case DiffType.Add:
                    color = Color.Coral;
                    break;
                case DiffType.Delete:
                    color = Color.Red;
                    break;
            }

            e.Graphics.DrawString( 
                item.Value, 
                _view.listBox1.Font,
                new SolidBrush(color), 
                0, 
                e.Index *_view.listBox1.ItemHeight
            );
        }

        private void ResultButtonOnClick(object sender, EventArgs e)
        {
            var diff = new Diff(_firstLines, _secondLines);
            _mainViewModel.DiffList = diff.GetDiffList();
            _view.listBox1.DrawItem += new DrawItemEventHandler(TestListBox_DrawItem);
        }

        public void SecondFileButton_Click(object sender, EventArgs e)
        {
            string fileName = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                }
            }

            if (fileName == null) return;

            var text = File.ReadAllText(fileName);
            _secondLines = File.ReadLines(fileName,
                System.Text.Encoding.GetEncoding(1251)).ToList();
        }

        public void FirstFileButtonOnClick(object sender, EventArgs e)
        {
            string fileName = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                }
            }

            if (fileName == null) return;

            var text = File.ReadAllText(fileName);
            _firstLines = File.ReadLines(fileName,
                System.Text.Encoding.GetEncoding(1251)).ToList();

        }

        public void Run()
        {
            Application.Run(_view);
        }

        public void Initialize()
        {
        }

        private void OnViewClosed(object sender, EventArgs e)
        {
        }


    }
}
