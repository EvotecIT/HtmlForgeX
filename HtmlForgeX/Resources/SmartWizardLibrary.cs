namespace HtmlForgeX.Resources;

/// <summary>
/// Metadata description for the SmartWizard jQuery plugin library.
/// SmartWizard is a responsive jQuery plugin for creating step-by-step wizards.
/// </summary>
public class SmartWizardLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="SmartWizardLibrary"/> class.
    /// </summary>
    public SmartWizardLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/smartwizard@6.0.0/dist/css/smart_wizard_all.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/smartwizard@6.0.0/dist/js/jquery.smartWizard.min.js"]
        };
        Comment = "SmartWizard jQuery plugin for step-by-step wizards";
        LicenseLink = "https://github.com/techlab/jquery-smartwizard/blob/master/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/techlab/jquery-smartwizard";
        Website = "https://smartwizard.techlaboratory.net/";
    }
}