<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextEditorControl.ascx.cs" Inherits="AIS_TextEditor_TextEditorControl" %>

<!DOCTYPE html>

<meta http-equiv="X-UA-Compatible" content="IE=Edge">
<meta charset="utf-8">

<style>
  body {
    font-family: Verdana;
    font-size: 11px;
  }
  
  h2 {
    margin-bottom: 0;
  }
  
  small {
    display: block;
    margin-top: 40px;
    font-size: 9px;
  }
  
  small,
  small a {
    color: #666;
  }
  
  a {
    color: #000;
    text-decoration: underline;
    cursor: pointer;
  }
  
  #toolbar [data-wysihtml5-action] {
    float: right;
  }
  
  #toolbar,
  textarea {
    width: 850px;
    padding: 5px;
    -webkit-box-sizing: border-box;
    -ms-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
  }
  
  textarea {
    height: 280px;
    border: 2px solid green;
    font-family: Verdana;
    font-size: 11px;
  }
  
  textarea:focus {
    color: black;
    border: 2px solid black;
  }
  
  .wysihtml5-command-active {
    font-weight: bold;
  }
  
  [data-wysihtml5-dialog] {
    margin: 5px 0 0;
    padding: 5px;
    border: 1px solid #666;
  }
  
  a[data-wysihtml5-command-value="red"] {
    color: red;
  }
  
  a[data-wysihtml5-command-value="green"] {
    color: green;
  }
  
  a[data-wysihtml5-command-value="blue"] {
    color: blue;
  }
</style>


<form>
  <div id="toolbar" style="display: none;">
    <a data-wysihtml5-command="bold" title="CTRL+B">Gras</a> 
    <a data-wysihtml5-command="italic" title="CTRL+I">Italique</a> 
      <a data-wysihtml5-command="underline" title="CTRL+S">Souligner</a> 
      <a data-wysihtml5-command="justifyLeft" title="CTRL+L">Justifier gauche</a> 
      <a data-wysihtml5-command="justifyCenter" title="CTRL+J">Justifier centre</a> 
      <a data-wysihtml5-command="justifyRight" title="CTRL+R">Justifier droite</a> 
    <a data-wysihtml5-command="createLink">Insérer un lien</a> 
    <a data-wysihtml5-command="insertImage">Insérer une image</a> 
    <a data-wysihtml5-command="formatBlock" data-wysihtml5-command-value="h1">h1</a> 
    <a data-wysihtml5-command="formatBlock" data-wysihtml5-command-value="h2">h2</a> 
    <a data-wysihtml5-command="insertUnorderedList">insertUnorderedList</a> 
    <a data-wysihtml5-command="insertOrderedList">insertOrderedList</a> 
    <a data-wysihtml5-command="foreColor" data-wysihtml5-command-value="red">red</a> 
    <a data-wysihtml5-command="foreColor" data-wysihtml5-command-value="green">green</a> 
    <a data-wysihtml5-command="foreColor" data-wysihtml5-command-value="blue">blue</a> 
    <a data-wysihtml5-command="insertSpeech">speech</a>
    <a data-wysihtml5-action="change_view">switch to html view</a>
    
    <div data-wysihtml5-dialog="createLink" style="display: none;">
      <label>
        Link:
        <input data-wysihtml5-dialog-field="href" value="http://">
      </label>
      <a data-wysihtml5-dialog-action="save">OK</a>&nbsp;<a data-wysihtml5-dialog-action="cancel">Cancel</a>
    </div>
    
    <div data-wysihtml5-dialog="insertImage" style="display: none;">
      <label>
        Image:
        <input data-wysihtml5-dialog-field="src" value="http://">
      </label>
      <label>
        Align:
        <select data-wysihtml5-dialog-field="className">
          <option value="">default</option>
          <option value="wysiwyg-float-left">left</option>
          <option value="wysiwyg-float-right">right</option>
        </select>
      </label>
      <a data-wysihtml5-dialog-action="save">OK</a>&nbsp;<a data-wysihtml5-dialog-action="cancel">Cancel</a>
    </div>
    
  </div>

  <textarea id="textarea" placeholder="Saisir le texte..." autofocus></textarea>
</form>

<!-- wysihtml5 parser rules -->
<script src="AIS/TextEditor/wysihtml5-fb0cfe4/parser_rules/advanced.js"></script>
<!-- Library -->
<script src="AIS/TextEditor/wysihtml5-fb0cfe4/dist/wysihtml5-0.3.0.js"></script>

<script>
    var editor = new wysihtml5.Editor("textarea", {
        toolbar: "toolbar",
        stylesheets: "AIS/TextEditor/wysihtml5-fb0cfe4/examples/css/stylesheet.css",
        parserRules: wysihtml5ParserRules
    });
</script>