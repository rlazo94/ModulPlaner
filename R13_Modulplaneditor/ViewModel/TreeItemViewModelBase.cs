using System;
using System.Collections.Generic;
using System.Text;

namespace Modulplaneditor
{
    public class TreeItemViewModelBase : ViewModelBase
    {
        protected readonly TreeItemViewModelBase _superitem;
                
        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                
                // Expand all the way up to the root.
                if (_isExpanded && _superitem != null)
                    _superitem.IsExpanded = true;
                
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        public TreeItemViewModelBase(TreeItemViewModelBase superitem)
        {
            _superitem = superitem;
        }
    }
}
