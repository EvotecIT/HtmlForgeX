using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public partial class TablerCardEnhanced {
    #region Footer Methods
    /// <summary>
    /// Initializes or configures WithFooter.
    /// </summary>
    public TablerCardEnhanced WithFooter(string text = "", bool transparent = false) {
        FooterText = text;
        FooterTransparent = transparent;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithFooterButton.
    /// </summary>
    public TablerCardEnhanced WithFooterButton(string text, string href = "#", TablerButtonVariant variant = TablerButtonVariant.Primary) {
        FooterActions.Add(new TablerButton(text, href, variant));
        return this;
    }

    /// <summary>
    /// Initializes or configures WithFooterAvatars.
    /// </summary>
    public TablerCardEnhanced WithFooterAvatars(params string[] imageUrls) {
        foreach (var url in imageUrls) {
            FooterAvatars.Add(new TablerAvatar().Image(url).Size(AvatarSize.XS));
        }
        return this;
    }

    /// <summary>
    /// Initializes or configures WithFooterSwitch.
    /// </summary>
    public TablerCardEnhanced WithFooterSwitch(bool isChecked = false) {
        FooterHasSwitch = true;
        FooterSwitchChecked = isChecked;
        return this;
    }
    #endregion

    private HtmlTag BuildCardFooter() {
        // Ensure all actions have the current Document and Email references
        foreach (var action in FooterActions.WhereNotNull()) {
            action.Document = Document;
            action.Email = Email;
        }

        var footerDiv = new HtmlTag("div");
        var footerClasses = new List<string> { "card-footer" };

        if (FooterTransparent) {
            footerClasses.Add("card-footer-transparent");
        }

        footerDiv.Class(string.Join(" ", footerClasses));

        if (!string.IsNullOrEmpty(FooterText)) {
            footerDiv.Value(FooterText);
        }

        // Handle complex footer layouts
        if (FooterActions.Any() || FooterAvatars.Any() || FooterHasSwitch) {
            var rowDiv = new HtmlTag("div").Class("row align-items-center");

            // Left side content
            if (FooterActions.Any(a => a is TablerButton b && b.Variant == TablerButtonVariant.Link)) {
                var leftCol = new HtmlTag("div").Class("col-auto");
                foreach (var action in FooterActions.Where(a => a is TablerButton b && b.Variant == TablerButtonVariant.Link)) {
                    leftCol.Value(action);
                }
                rowDiv.Value(leftCol);
            }

            // Right side content
            var rightCol = new HtmlTag("div").Class("col-auto ms-auto");

            // Add avatars
            if (FooterAvatars.Any()) {
                var avatarList = new HtmlTag("div").Class("avatar-list avatar-list-stacked");
                foreach (var avatar in FooterAvatars) {
                    avatarList.Value(avatar);
                }
                rightCol.Value(avatarList);
            }

            // Add switch
            if (FooterHasSwitch) {
                var switchLabel = new HtmlTag("label").Class("form-check form-switch form-switch-lg m-0");
                var switchInput = new HtmlTag("input")
                    .Class("form-check-input position-static")
                    .Attribute("type", "checkbox");

                if (FooterSwitchChecked) {
                    switchInput.Attribute("checked", "");
                }

                switchLabel.Value(switchInput);
                rightCol.Value(switchLabel);
            }

            // Add primary buttons
            foreach (var action in FooterActions.Where(a => !(a is TablerButton b && b.Variant == TablerButtonVariant.Link))) {
                rightCol.Value(action);
            }

            rowDiv.Value(rightCol);
            footerDiv.Value(rowDiv);
        }

        return footerDiv;
    }
}
