// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Dever
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField birthdateResLabel { get; set; }

		[Outlet]
		AppKit.NSTextField brotherCountResLabel { get; set; }

		[Outlet]
		AppKit.NSTextField fatherNameResLabel { get; set; }

		[Outlet]
		AppKit.NSTextField motherNameResLabel { get; set; }

		[Outlet]
		AppKit.NSTextField nameResLabel { get; set; }

		[Outlet]
		AppKit.NSTextField searchTextField { get; set; }

		[Outlet]
		AppKit.NSTextField sexResLabel { get; set; }

		[Action ("clearSearch:")]
		partial void clearSearch (Foundation.NSObject sender);

		[Action ("deleteButton:")]
		partial void deleteButton (Foundation.NSObject sender);

		[Action ("saveButton:")]
		partial void saveButton (Foundation.NSObject sender);

		[Action ("search:")]
		partial void search (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (birthdateResLabel != null) {
				birthdateResLabel.Dispose ();
				birthdateResLabel = null;
			}

			if (brotherCountResLabel != null) {
				brotherCountResLabel.Dispose ();
				brotherCountResLabel = null;
			}

			if (fatherNameResLabel != null) {
				fatherNameResLabel.Dispose ();
				fatherNameResLabel = null;
			}

			if (motherNameResLabel != null) {
				motherNameResLabel.Dispose ();
				motherNameResLabel = null;
			}

			if (nameResLabel != null) {
				nameResLabel.Dispose ();
				nameResLabel = null;
			}

			if (searchTextField != null) {
				searchTextField.Dispose ();
				searchTextField = null;
			}

			if (sexResLabel != null) {
				sexResLabel.Dispose ();
				sexResLabel = null;
			}
		}
	}
}
