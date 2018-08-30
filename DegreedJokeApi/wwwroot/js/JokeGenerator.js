class JokeGenerator{

    constructor(randomErrMsg, randomJokePlaceholder, searchErrMsg, searchResultPlaceholder, searchInput){
        this.jokeTimer = null;
        this.randomErrElement = randomErrMsg;
        this.randomJokeElement = randomJokePlaceholder;
        this.searchErrElement = searchErrMsg;
        this.searchResultElement = searchResultPlaceholder;

        $(this.randomErrElement).hide();
        $(this.searchErrElement).hide();

        $(searchInput).keypress(function(e){
            if(e.which == 32) return false;
        });
    }

    loadRandomJoke(thisContext) {
        $.get("api/jokes", function(data,status){
            if(status == "success"){
                $(thisContext.randomErrElement).hide();
                $(thisContext.randomJokeElement).html(data.joke);
            }
            else{
                $(this.randomErrElement).html("Joke Generator failed.  Please standby.");
                $(this.randomErrElement).show();
            }
         });
    }

    startJokeTimer(){
        let loader = this.loadRandomJoke;
        loader(this);

        let thisContext = this;
        this.jokeTimer = setInterval(function(){ loader(thisContext); }, 10000);
    }

    stopJokeTimer(){
        clearInterval(this.jokeTimer);
    }

    searchForJokes(term){
        if(term.trim() == ""){
            $(this.searchErrElement).html("You must enter a search term");
            $(this.searchErrElement).show();

            return;
        }

        let thisContext = this;
        $.get("home/search/" + term, function(data,status){
            if(status == "success"){
                data = data.replace(new RegExp(term, "ig"), '<mark>'+term+'</mark>');

                $(thisContext.searchResultElement).html(data);
                $(thisContext.searchErrElement).hide();
            }
            else{
                $(thisContext.searchErrElement).html("Search failed.  Please try again.");
                $(thisContext.searchErrElement).show();
            }
         });
    }
}
