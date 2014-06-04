using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AudioBookConverter {
	public abstract class DataGridViewImageButtonCell : DataGridViewButtonCell {
		private bool _enabled;                // Is the button enabled
		private PushButtonState _buttonState; // What is the button state
		protected Image _buttonImageHot;      // The hot image
		protected Image _buttonImageNormal;   // The normal image
		protected Image _buttonImageDisabled; // The disabled image
		private int _buttonImageOffset;       // The amount of offset or border around the image

		protected DataGridViewImageButtonCell () {
			// In my project, buttons are disabled by default
			_enabled = true;
			_buttonState = PushButtonState.Normal;

			// Changing this value affects the appearance of the image on the button.
			_buttonImageOffset = 2;

			// Call the routine to load the images specific to a column.
			LoadImages();
		}

		// Button Enabled Property
		public bool Enabled {
			get {
				return _enabled;
			}

			set {
				_enabled = value;
				_buttonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
			}
		}

		// PushButton State Property
		public PushButtonState ButtonState {
			get { return _buttonState; }
			set { _buttonState = value; }
		}

		// Image Property
		// Returns the correct image based on the control's state.
		public Image ButtonImage {
			get {
				switch (_buttonState) {
					case PushButtonState.Disabled:
						return _buttonImageDisabled;

					case PushButtonState.Hot:
						return _buttonImageHot;

					case PushButtonState.Normal:
						return _buttonImageNormal;

					case PushButtonState.Pressed:
						return _buttonImageNormal;

					case PushButtonState.Default:
						return _buttonImageNormal;

					default:
						return _buttonImageNormal;
				}
			}
		}

		protected override void Paint (Graphics graphics,
			Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
			DataGridViewElementStates elementState, object value,
			object formattedValue, string errorText,
			DataGridViewCellStyle cellStyle,
			DataGridViewAdvancedBorderStyle advancedBorderStyle,
			DataGridViewPaintParts paintParts) {
			//base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

			// Draw the cell background, if specified.
			if ((paintParts & DataGridViewPaintParts.Background) ==
				DataGridViewPaintParts.Background) {
				SolidBrush cellBackground =
					new SolidBrush(cellStyle.BackColor);
				graphics.FillRectangle(cellBackground, cellBounds);
				cellBackground.Dispose();
			}

			// Draw the cell borders, if specified.
			if ((paintParts & DataGridViewPaintParts.Border) ==
				DataGridViewPaintParts.Border) {
				PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
					advancedBorderStyle);
			}

			// Calculate the area in which to draw the button.
			// Adjusting the following algorithm and values affects
			// how the image will appear on the button.
			Rectangle buttonArea = cellBounds;

			Rectangle buttonAdjustment =
				BorderWidths(advancedBorderStyle);

			buttonArea.X += buttonAdjustment.X;
			buttonArea.Y += buttonAdjustment.Y;
			buttonArea.Height -= buttonAdjustment.Height;
			buttonArea.Width -= buttonAdjustment.Width;
			
			Rectangle imageArea = new Rectangle(
				buttonArea.X + _buttonImageOffset,
				buttonArea.Y + _buttonImageOffset,
				16,
				16);
			
			//using (Pen p = new Pen(cellStyle.ForeColor))
			//{
			//graphics.DrawRectangle(p, buttonArea.X, buttonArea.Y, 
			//buttonArea.Width - 1, buttonArea.Height - 1);
			//}

			graphics.DrawImage(ButtonImage, buttonArea.X, buttonArea.Y, buttonArea.Width - 1, buttonArea.Height - 1);

			//ButtonRenderer.DrawButton(graphics, buttonArea, ButtonImage, imageArea, false, ButtonState);
		}

		// An abstract method that must be created in each derived class.
		// The images in the derived class will be loaded here.
		public abstract void LoadImages ();
	}

	public class DataGridViewImageButtonUpCell : DataGridViewImageButtonCell {
		public override void LoadImages () {
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.

			_buttonImageHot = AudioBookConverter.Properties.Resources.arrow_up;
			_buttonImageNormal = AudioBookConverter.Properties.Resources.arrow_up;
			_buttonImageDisabled = AudioBookConverter.Properties.Resources.arrow_up;
		}
	}

	public class DataGridViewImageButtonUpColumn : DataGridViewButtonColumn {
		public DataGridViewImageButtonUpColumn () {
			this.CellTemplate = new DataGridViewImageButtonUpCell();
			this.Width = 22;
			this.Resizable = DataGridViewTriState.False;
		}
	}
		public class DataGridViewImageButtonDownCell : DataGridViewImageButtonCell {
			
			public override void LoadImages () {
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.
			
			_buttonImageHot = AudioBookConverter.Properties.Resources.arrow_down;
			_buttonImageNormal = AudioBookConverter.Properties.Resources.arrow_down;
			_buttonImageDisabled = AudioBookConverter.Properties.Resources.arrow_down;
		}
	}

	public class DataGridViewImageButtonDownColumn : DataGridViewButtonColumn {
		public DataGridViewImageButtonDownColumn () {
			this.CellTemplate = new DataGridViewImageButtonDownCell();
			this.Width = 22;
			this.Resizable = DataGridViewTriState.False;
		}
	}
	public class DataGridViewImageButtonPlayCell : DataGridViewImageButtonCell {
		public override void LoadImages () {
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.

			_buttonImageHot = AudioBookConverter.Properties.Resources.play;
			_buttonImageNormal = AudioBookConverter.Properties.Resources.play;
			_buttonImageDisabled = AudioBookConverter.Properties.Resources.play;
		}
	}

	public class DataGridViewImageButtonPlayColumn : DataGridViewButtonColumn {
		public DataGridViewImageButtonPlayColumn () {
			this.CellTemplate = new DataGridViewImageButtonPlayCell();
			this.Width = 22;
			this.Resizable = DataGridViewTriState.False;
		}
	}
		public class DataGridViewImageButtonStopCell : DataGridViewImageButtonCell {
		public override void LoadImages () {
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.

			_buttonImageHot = AudioBookConverter.Properties.Resources.stop;
			_buttonImageNormal = AudioBookConverter.Properties.Resources.stop_small;
			_buttonImageDisabled = AudioBookConverter.Properties.Resources.stop_small;
		}
	}

	public class DataGridViewImageButtonStopColumn : DataGridViewButtonColumn {
		public DataGridViewImageButtonStopColumn () {
			this.CellTemplate = new DataGridViewImageButtonStopCell();
			this.Width = 22;
			this.Resizable = DataGridViewTriState.False;
		}
	}
			public class DataGridViewImageButtonDeleteCell : DataGridViewImageButtonCell {
		public override void LoadImages () {
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.

			_buttonImageHot = AudioBookConverter.Properties.Resources.stop;
			_buttonImageNormal = AudioBookConverter.Properties.Resources.cross_small;
			_buttonImageDisabled = AudioBookConverter.Properties.Resources.stop_small;
		}
	}

	public class DataGridViewImageButtonDeleteColumn : DataGridViewButtonColumn {
		public DataGridViewImageButtonDeleteColumn () {
			this.CellTemplate = new DataGridViewImageButtonDeleteCell();
			this.Width = 22;
			this.Resizable = DataGridViewTriState.False;
		}
	}
}

