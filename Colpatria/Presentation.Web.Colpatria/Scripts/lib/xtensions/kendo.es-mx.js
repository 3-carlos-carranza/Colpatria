﻿kendo.ui.Locale = "Español de México (es-MX)";
kendo.ui.ColumnMenu.prototype.options.messages =
  $.extend(kendo.ui.ColumnMenu.prototype.options.messages, {
      sortAscending: "Ascendente",
      sortDescending: "Descendente",
      filter: "Filtro",
      columns: "Columnas"
  });

kendo.ui.Groupable.prototype.options.messages =
  $.extend(kendo.ui.Groupable.prototype.options.messages, {
      empty: "Arrastre una columna aquí para agrupar por dicha columna"
  });

kendo.ui.FilterMenu.prototype.options.messages =
  $.extend(kendo.ui.FilterMenu.prototype.options.messages, {
      info: "Título:",  
      filter: "Filtrar",      
      clear: "Limpiar",      
      isTrue: "Verdadero", 
      isFalse: "Falso",     
      and: "Y",
      or: "O",
      selectValue: "Seleccione un valor"
  });

kendo.ui.FilterMenu.prototype.options.operators =
  $.extend(kendo.ui.FilterMenu.prototype.options.operators, {
      string: {
          eq: "Es igual a",
          neq: "Es diferente a",
          startswith: "Comienza con",
          contains: "Contiene",
          doesnotcontain: "No contiene",
          endswith: "Termina con"
      },
      number: {
          eq: "Es igual a",
          neq: "Es diferente a",
          gte: "Es mayor que o igual a",
          gt: "Es mayor que",
          lte: "Es menor que o igual a",
          lt: "Es menor que"
      },
      date: {
          eq: "Es igual a",
          neq: "Es diferente de",
          gte: "Es igual o posterior a",
          gt: "Es posterior a",
          lte: "Es igual o anterior a",
          lt: "Es anterior a"
      },
      enums: {
          eq: "Es igual a",
          neq: "Es diferente de"
      }
  });

kendo.ui.Pager.prototype.options.messages =
  $.extend(kendo.ui.Pager.prototype.options.messages, {

      display: "{0} - {1} de {2} elementos.",
      empty: "Sin datos para mostrar.",
      page: "Página",
      of: "de {0}",
      itemsPerPage: "elementos por página.",
      first: "Ir a la primera página",
      previous: "Ir a la página anterior",
      next: "Ir a la página siguiente",
      last: "Ir a la última página",
      refresh: "Refrescar"
  });

kendo.ui.Validator.prototype.options.messages =
  $.extend(kendo.ui.Validator.prototype.options.messages, {
      required: "{0} es obligatorio",
      pattern: "{0} no es válido",
      min: "{0} debe ser mayor o igual que {1}",
      max: "{0} debe ser menor o igual que {1}",
      step: "{0} no es válido",
      email: "{0} no es un correo electrónico válido",
      url: "{0} no es un URL válido",
      date: "{0} no es una fecha válida"
  });

kendo.ui.ImageBrowser.prototype.options.messages =
  $.extend(kendo.ui.ImageBrowser.prototype.options.messages, {
      uploadFile: "Enviar",
      orderBy: "Ordenar por",
      orderByName: "Nombre",
      orderBySize: "Tamaño",
      directoryNotFound: "El directorio no fue encontrado.",
      emptyFolder: "Carpeta vacía",
      deleteFile: '¿Está seguro de que desea eliminar "{0}"?',
      invalidFileType: "El archivo seleccionado \"{0}\" no es válido. Los tipos de archivos soportados son {1}.",
      overwriteFile: "Un archivo con el nombre \"{0}\" ya existe en la carpeta actual. ¿Desea sobrescribirlo?",
      dropFilesHere: "Coloque los archivos aquí"
  });

kendo.ui.Editor.prototype.options.messages =
  $.extend(kendo.ui.Editor.prototype.options.messages, {
      bold: "Negrita",
      italic: "Cursiva",
      underline: "Subrayado",
      strikethrough: "Tachado",
      superscript: "Superíndice",
      subscript: "Subíndice",
      justifyCenter: "Centrar texto",
      justifyLeft: "Alinear texto a la izquierda",
      justifyRight: "Alinear texto a la derecha",
      justifyFull: "Justificar",
      insertUnorderedList: "Insertar una lista",
      insertOrderedList: "Insertar una lista ordenada",
      indent: "Aumentar sangría",
      outdent: "Disminuir sangría",
      createLink: "Crear enlace",
      unlink: "Remover enlace",
      insertImage: "Insertar imagen",
      insertHtml: "Insertar HTML",
      fontName: "Seleccionar fuente",
      fontNameInherit: "(fuente heredada)",
      fontSize: "Seleccionar tamaño de la fuente",
      fontSizeInherit: "(tamaño heredado)",
      formatBlock: "Formatear",
      paragraph: "Párrafo",
      foreColor: "Color",
      backColor: "Color de fondo",
      style: "Estilos",
      emptyFolder: "Carpeta vacía",
      uploadFile: "Enviar",
      orderBy: "Ordenar por:",
      orderBySize: "Tamaño",
      orderByName: "Nombre",
      invalidFileType: "El archivo seleccionado \"{0}\" no es válido. Los tipos de archivos soportados son {1}.",
      deleteFile: '¿Está seguro de que desea eliminar "{0}"?',
      overwriteFile: "Un archivo con el nombre \"{0}\" ya existe en la carpeta actual. ¿Desea sobrescribirlo?",
      directoryNotFound: "El directorio no fue encontrado.",
      imageWebAddress: "Dirección de internet",
      imageAltText: "Texto alternativo",
      dialogInsert: "Insertar",
      dialogButtonSeparator: "o",
      dialogCancel: "Cancelar"
  });