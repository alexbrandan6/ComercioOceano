(function($) {
	$.fn.simpleAlert = function(options) {
		if (typeof options === 'undefined') options = {};

		var defaultOptions = {
	        title: '',
	        message: '',
	        btnLabel: 'Aceptar'
	    }
	    options = $.extend(defaultOptions, options);

	    this.each(function() {
	    	var $this = $(this);
	    	var html;

	    	$this.addClass('simple-dialog active');

	    	html = '<div class="simple-dialog-content">';
	    	html += '<div class="simple-dialog-header"><h3 class="title">'+options.title+'</h3><a class="simple-dialog-close" data-action="close"></a></div>';
	    	html += '<div class="simple-dialog-body"><p class="message">'+options.message+'</p></div>';
			html += '<div class="simple-dialog-footer"><a class="btn btn-success m-1 accept" data-action="close">' + options.btnLabel + '</a></div>';
	    	html += '</div>';

	    	$this.html(html);

	    	$(document).on('click', 'a[data-action="close"]', function(e) {
				e.preventDefault();
				$(this).parents('.simple-dialog').removeClass('active');
			});
	    });

	    return this;
	};

	$.fn.simpleConfirm = function(options) {
		if (typeof options === 'undefined') options = {};

        var defaultOptions = {
	        title: 'Atencion',
	        message: '',
	        acceptBtnLabel: 'Aceptar',
	        cancelBtnLabel: 'Cancelar',
	        success: function() {},
	        cancel: function() {}
	    }
	    options = $.extend(defaultOptions, options);

	    this.each(function() {
	    	var $this = $(this);
	    	var html;

	    	$this.addClass('simple-dialog active');

	    	html = '<div class="simple-dialog-content">';
	    	html += '<div class="simple-dialog-header"><h3 class="title">'+options.title+'</h3></div>';
	    	html += '<div class="simple-dialog-body"><p class="message">'+options.message+'</p></div>';
			html += '<div class="simple-dialog-footer clearfix"><a class="btn btn-success m-1 accept" data-action="close">' + options.acceptBtnLabel +'</a><a class="btn btn-secondary m-1 cancel" data-action="close">'+options.cancelBtnLabel+'</a></div>';
	    	html += '</div>';

	    	$this.html(html);

	    	$(document).on('click', 'a[data-action="close"]', function(e) {
				e.preventDefault();
				$(this).parents('.simple-dialog').removeClass('active');
				if($(this).hasClass('accept')) {
					options.success();
				}
				if($(this).hasClass('cancel')) {
					options.cancel();
				}
			});
	    });

	    return this;
	};

	$.fn.simplePrompt = function(options) {
		if (typeof options === 'undefined') options = {};

        var defaultOptions = {
	        title: 'Prompt',
	        message: '',
	        acceptBtnLabel: 'Accept',
	        cancelBtnLabel: 'Cancel',
	        success: function(result) {},
	        cancel: function(result) {}
	    }
	    options = $.extend(defaultOptions, options);

	    this.each(function() {
	    	var $this = $(this);
	    	var html;

	    	$this.addClass('simple-dialog active');

	    	html = '<div class="simple-dialog-content">';
	    	html += '<div class="simple-dialog-header"><h3 class="title">'+options.title+'</h3></div>';
	    	html += '<div class="simple-dialog-body"><p class="message">'+options.message+'</p><p class="answer"><input type="text" /></p></div>';
	    	html += '<div class="simple-dialog-footer clearfix"><a class="simple-dialog-button accept" data-action="close">'+options.acceptBtnLabel+'</a><a class="simple-dialog-button cancel" data-action="close">'+options.cancelBtnLabel+'</a></div>';
	    	html += '</div>';

	    	$this.html(html);

	    	$(document).on('click', 'a[data-action="close"]', function(e) {
				e.preventDefault();
				var result = $('.answer input').val();
				$(this).parents('.simple-dialog').removeClass('active');
				if($(this).hasClass('accept')) {
					options.success(result);
				}
				if($(this).hasClass('cancel')) {
					options.cancel(result);
				}
			});
	    });

	    return this;
	};
})(jQuery);