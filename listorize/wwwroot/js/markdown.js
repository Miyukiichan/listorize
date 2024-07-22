var editor;

initMarkdown = () => {
  //Needs to be destroyed every time otherwise there are two duplicates created
  if (editor) {
    destroyMarkdown();
  }
  editor = new SimpleMDE({
    element: document.getElementById("editor"),
    readOnly: true,
    hideIcons: ["side-by-side", "fullscreen"],
  });
};

markdownValue = () => {
  var value = editor == null ? "" : editor.value();
  return value;
};

destroyMarkdown = () => {
  editor.toTextArea();
  editor = null;
};
