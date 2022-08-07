using Microsoft.Xaml.Behaviors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AttWithView.MVVMs.Views.DragDrops
{
    internal class ReorderableSelectorBehavior : Behavior<Selector>
    {
        private DragDropObject? temporaryData;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AllowDrop = true;
            AssociatedObject.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseMove += OnPreviewMouseMove;
            AssociatedObject.PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
            AssociatedObject.PreviewDragEnter += OnPreviewDragEnter;
            AssociatedObject.PreviewDragLeave += OnPreviewDragLeave;
            AssociatedObject.PreviewDrop += OnPreviewDrop;
            AssociatedObject.PreviewDragOver += OnPreviewDragOver;

        }
        /// <summary>
        /// ドラッグ中のマウス移動中に場所を分かり易くする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreviewDragOver(object sender, DragEventArgs e)
        {
            if (TryGetIndex(e, out _, out int originalSourceIndex))
            {
                AssociatedObject.SelectedIndex = originalSourceIndex;
            }
        }


        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as FrameworkElement;
            temporaryData = new DragDropObject();
            temporaryData.Start = e.GetPosition(Window.GetWindow(control));
            temporaryData.DraggedItem = GetTemplatedRootElement(e.OriginalSource as FrameworkElement);
        }
        private static FrameworkElement? GetTemplatedRootElement(FrameworkElement? element)
        {
            var parent = element?.TemplatedParent as FrameworkElement;
            while (parent?.TemplatedParent != null)
            {
                parent = parent.TemplatedParent as FrameworkElement;
            }
            return parent;
        }
        private void OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (temporaryData != null)
            {
                var control = sender as FrameworkElement;
                var current = e.GetPosition(Window.GetWindow(control));
                if (temporaryData.CheckStartDragging(current))
                {
                    DragDrop.DoDragDrop(control, temporaryData.DraggedItem, DragDropEffects.Move);
                    temporaryData = null;
                }
            }
        }

        private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            temporaryData = null;
        }
        private void OnPreviewDragEnter(object sender, DragEventArgs e)
        {
            if (temporaryData != null)
            {
                temporaryData.IsDroppable = true;
            }
        }

        private void OnPreviewDragLeave(object sender, DragEventArgs e)
        {
            if (temporaryData != null)
            {
                temporaryData.IsDroppable = false;
            }
        }

        private void OnPreviewDrop(object sender, DragEventArgs e)
        {
            if (TryGetIndex(e, out int draggedItemIndex, out int index))
            {
                if (AssociatedObject.ItemsSource is IList)
                {
                    IList itemsSource = (IList)AssociatedObject.ItemsSource;
                    object? item = itemsSource[draggedItemIndex];
                    itemsSource.RemoveAt(draggedItemIndex);
                    itemsSource.Insert(index, item);
                    AssociatedObject.SelectedIndex = index;
                }
            }
        }
        private bool TryGetIndex(DragEventArgs e, out int draggedItemIndex, out int originalSourceIndex)
        {
            draggedItemIndex = AssociatedObject.ItemContainerGenerator.IndexFromContainer(temporaryData?.DraggedItem);
            FrameworkElement? originalSourceRootElement = GetTemplatedRootElement(e.OriginalSource as FrameworkElement);
            originalSourceIndex = AssociatedObject.ItemContainerGenerator.IndexFromContainer(originalSourceRootElement);
            return temporaryData?.IsDroppable is true && draggedItemIndex >= 0 && originalSourceIndex >= 0;
        }
        public void Dispose()
        {
            AssociatedObject.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseMove -= OnPreviewMouseMove;
            AssociatedObject.PreviewMouseLeftButtonUp -= OnPreviewMouseLeftButtonUp;
            AssociatedObject.PreviewDragEnter -= OnPreviewDragEnter;
            AssociatedObject.PreviewDragLeave -= OnPreviewDragLeave;
            AssociatedObject.PreviewDrop -= OnPreviewDrop;
        }

    }
}
