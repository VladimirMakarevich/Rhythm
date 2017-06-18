/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {

    config.filebrowserImageBrowseUrl = "/Scripts/ckeditor/ImageBrowser.aspx";
    config.filebrowserImageWindowWidth = 780;
    config.filebrowserImageWindowHeight = 720;
    config.filebrowserBrowseUrl = "/Scripts/ckeditor/LinkBrowser.aspx";
    config.filebrowserWindowWidth = 500;
    config.filebrowserWindowHeight = 650;
    config.allowedContent = true;
    //// protect <anytag class="preserve"></anytag>
    //config.protectedSource.push(/<([\S]+)[^>]*class="preserve"[^>]*>.*<\/\1>/g);
    //// protect <anytag class="preserve" /><
    //config.protectedSource.push(/<[^>]+class="preserve"[^>\/]*\/>/g);
    //// Define changes to default configuration here. For example:
    //config.protectedSource.push(/<([\S]+)[^>]*class="preserve"[^>]*>(.|\n)*<\/\1>/g);
	//// config.language = 'fr';
    //// config.uiColor = '#AADC6E';
    config.pasteFilter = null;
};

//CKEDITOR.editorConfig = function (config) {
//    config.pasteFilter = null;
//    config.allowedContent = {
//        script: true,
//        $1: {
//            // This will set the default set of elements
//            elements: CKEDITOR.dtd,
//            attributes: true,
//            styles: true,
//            classes: true
//        }
//    };
//};

//CKEDITOR.editorConfig = function (config) {
//    var editor = CKEDITOR.replace('wysiwyg5', {
//        allowedContent: 'script; div(alert,alert-info)'
//    });
//    // protect <anytag class="preserve"></anytag>
//    config.protectedSource.push(/<([\S]+)[^>]*class="preserve"[^>]*>.*<\/\1>/g);
//    // protect <anytag class="preserve" /><
//    config.protectedSource.push(/<[^>]+class="preserve"[^>\/]*\/>/g);
//};


/* /(system|application)/config/config.php - line 66 */
/**
 * Enable or disable global XSS filtering of GET, POST, and SERVER data. This
 * option also accepts a string to specify a specific XSS filtering tool.
 */
//$config['global_xss_filtering'] = FALSE;

//// protect <anytag class="preserve"></anytag>
//CKEDITOR.config.protectedSource.push(/<([\S]+)[^>]*class="preserve"[^>]*>(.|\n)*<\/\1>/g);
//// protect <anytag class="preserve" /><
//// protect <anytag class="preserve"></anytag>
//CKEDITOR.config.protectedSource.push(/<([\S]+)[^>]*class="preserve"[^>]*>.*<\/\1>/g);
//// protect <anytag class="preserve" /><
//CKEDITOR.config.protectedSource.push(/<[^>]+class="preserve"[^>\/]*\/>/g);

//CKEDITOR.editorConfig = function (config) {
//    // Define changes to default configuration here. For example:
//    config.toolbarCanCollapse = true,
//	config.enterMode = CKEDITOR.ENTER_P,
//	config.shiftEnterMode = CKEDITOR.ENTER_BR,
//	config.colorButton_enableMore = true,
//  	config.bodyId = 'content',
//	config.entities = false,
//	config.forceSimpleAmpersand = false,
//	config.fontSize_defaultLabel = '12px',
//	config.font_defaultLabel = 'Arial',
//	config.emailProtection = 'encode',
//	config.contentsLangDirection = 'ltr',
//	config.language = 'en',
//	config.contentsLanguage = 'en',
//	config.toolbarLocation = 'top',
//	config.browserContextMenuOnCtrl = false,
//	config.image_previewText = CKEDITOR.tools.repeat('Get-Simple - the best CMS for your purposes. Install it, test it, enjoy it. Free, OpenSource and userfriendly', 50)
//};
//// from  http://help.pixelandtonic.com/brandonkelly/topics/how_do_i_set_output_formatting_writer_rules?from_gsfn=true 
//CKEDITOR.on('instanceReady', function (ev) {

//    var blockTags = ['div', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'p', 'pre', 'ul', 'li'];
//    var rules = {
//        indent: false,
//        breakBeforeOpen: false,
//        breakAfterOpen: false,
//        breakBeforeClose: false,
//        breakAfterClose: true
//    };

//    for (var i = 0; i < blockTags.length; i++) {
//        ev.editor.dataProcessor.writer.setRules(blockTags[i], rules);
//    }

//});

//// from  http://docs.cksource.com/CKEditor_3.x/Developers_Guide/Dialog_Customization

//CKEDITOR.on('dialogDefinition', function (ev) {
//    // Take the dialog name and its definition from the event data.
//    var dialogName = ev.data.name;
//    var dialogDefinition = ev.data.definition;

//    // Check if the definition is from the dialog we're
//    // interested on (the Link dialog).
//    if (dialogName == 'link') {
//        /* Enable this part only if you don't remove the 'target' tab in the previous block. */
//        FCKConfig.DefaultLinkTarget = '_blank'
//        // Get a reference to the "Target" tab.
//        var targetTab = dialogDefinition.getContents('target');
//        var targetField = targetTab.get('linkTargetType');
//        targetField['default'] = '';
//        linkField['default'] = 'URL';

//    } // end dialogDefinition

//    if (dialogName == 'image') {
//        dialogDefinition.removeContents('advanced');
//        dialogDefinition.removeContents('Link');
//    }

//    if (dialogName == 'flash') {
//        dialogDefinition.removeContents('advanced');
//    }

//});