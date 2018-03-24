  $(function () {
                        document.getElementById('#nav').onclick = function selected() {

                            //get full address url
                            var url = window.location.href;

                            $("ul#nav li a").each(function () {

                                if (url == (this.href)) {
                                    $('a').removeClass("selected");
                                    $(this).closest("a").addClass("selected");
                                }


                            });

                        };
                    });



                    function selected() {

                        //get full address url
                        var url = window.location.href;

                        $("ul#nav li a").each(function () {

                            if (url == (this.href)) {
                                $(this).closest("a").addClass("selected");
                            }


                        });


                    }
                    selected();