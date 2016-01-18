using System;
using System.Collections.Generic;
using System.Linq;
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

namespace VsStyle.Contents
{
    /// <summary>
    /// Interaction logic for BlogEditor.xaml
    /// </summary>
    partial class BlogEditor : UserControl, IContent
    {
        public IContentContainer Container { get; set; }

        public static string TabCharacter = "    ";

        public BlogEditor()
        {
            InitializeComponent();
        }

        public BlogEditor(IContentContainer container) : this()
        {
            Container = container;
        }

        private void RichTextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            var richTextBox = sender as RichTextBox;
            if (richTextBox != null)
            {
                var dataObject = e.DataObject as DataObject;
                if (dataObject != null)
                {
                    if (dataObject.ContainsText())
                    {
                        richTextBox.Selection.Text = "";

                        richTextBox.CaretPosition = richTextBox.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
                        richTextBox.CaretPosition.InsertTextInRun(dataObject.GetText());
                    }
                }
            }

            e.CancelCommand();
        }

        private void RichTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                var richTextBox = sender as RichTextBox;
                if (richTextBox != null)
                {
                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    {
                        // Shift + Tab

                        if (richTextBox.Selection.IsEmpty || richTextBox.Selection.Start.Paragraph == richTextBox.Selection.End.Paragraph)
                        {
                            // 若未选中任何文本或在单行内选中，则删除插入符同一行内之前的空白字符
                            var text = richTextBox.CaretPosition.GetTextInRun(LogicalDirection.Backward);
                            var count = 0;
                            for (int i = text.Length - 1; i >= 0; i--)
                            {
                                if (text[i] == ' ')
                                {
                                    count++;
                                    if (count >= TabCharacter.Length)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            richTextBox.CaretPosition.DeleteTextInRun(-count);
                        }
                        else
                        {
                            // 若在多行内选中，则在每行行首删除空白字符
                            var textPointer = richTextBox.Selection.Start;
                            if (!textPointer.IsAtLineStartPosition)
                            {
                                textPointer = textPointer.GetLineStartPosition(0);
                            }

                            while (textPointer.GetOffsetToPosition(richTextBox.Selection.End) > 0)
                            {
                                if (textPointer.IsAtLineStartPosition)
                                {
                                    var text = textPointer.GetTextInRun(LogicalDirection.Forward);
                                    var count = 0;
                                    for (int i = 0; i < text.Length; i++)
                                    {
                                        if (text[i] == ' ')
                                        {
                                            count++;
                                            if (count >= TabCharacter.Length)
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    textPointer.DeleteTextInRun(count);
                                    textPointer = textPointer.GetPositionAtOffset(count + 1);
                                }
                                else
                                {
                                    textPointer = textPointer.GetPositionAtOffset(1);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Tab

                        if (richTextBox.Selection.IsEmpty)
                        {
                            // 未选中任何文字，则插入执行插入制表符操作
                            richTextBox.CaretPosition = richTextBox.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
                            richTextBox.CaretPosition.InsertTextInRun(TabCharacter);
                        }
                        else
                        {
                            if (richTextBox.Selection.Start.Paragraph == richTextBox.Selection.End.Paragraph)
                            {
                                // 若在单行内选中，则删除选中的文本，同时执行插入制表符操作
                                richTextBox.Selection.Text = "";
                                richTextBox.CaretPosition = richTextBox.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
                                richTextBox.CaretPosition.InsertTextInRun(TabCharacter);
                            }
                            else
                            {
                                // 若在多行内选中，则在每行行首执行插入制表符操作
                                var textPointer = richTextBox.Selection.Start;
                                if (!textPointer.IsAtLineStartPosition)
                                {
                                    textPointer = textPointer.GetLineStartPosition(0);
                                }

                                while (textPointer.GetOffsetToPosition(richTextBox.Selection.End) > 0)
                                {
                                    if (textPointer.IsAtLineStartPosition)
                                    {
                                        textPointer.InsertTextInRun(TabCharacter);
                                        textPointer = textPointer.GetPositionAtOffset(TabCharacter.Length + 1);
                                    }
                                    else
                                    {
                                        textPointer = textPointer.GetPositionAtOffset(1);
                                    }
                                }
                            }
                        }
                    }
                }

                e.Handled = true;
            }
        }

        private void SeperatorBarDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (RightPanel.ActualWidth - e.HorizontalChange < 0)
            {
                RightPanel.Width = 0;
            }
            else if (RightPanel.ActualWidth - e.HorizontalChange > ActualWidth - 30)
            {
                RightPanel.Width = ActualWidth - 30;
            }
            else
            {
                RightPanel.Width = RightPanel.ActualWidth - e.HorizontalChange;
            }
        }
        
    }
}
