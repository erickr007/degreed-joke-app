
class JokeGenerator{

    constructor(){
        this.jokeTimer = null;

        $("#randomErrorMessage").hide();
        $("#searchErrorMessage").hide();
    }

    static loadRandomJoke() {
        $.get("api/jokes", function(data,status){
            if(status == "success"){
                $("#randomErrorMessage").hide();
                $("#randomJoke").html(data.joke);
            }
            else{
                $("#randomErrorMessage").html("Joke Generator failed.  Please try reloading joke.");
                $("#randomErrorMessage").show();
            }
         });
    }

    startJokeTimer(){
        this.jokeTimer = setInterval(function(){ JokeGenerator.loadRandomJoke(); }, 10000);
    }

    stopJokeTimer(){
        clearInterval(this.jokeTimer);
    }

    searchForJokes(){
        var term = $("#searchTerm").val();

        if(term == ""){
            $("#searchErrorMessage").html("You must enter a search term");
             $("#searchErrorMessage").show();
        }

        $.get("home/search/" + term, function(data,status){
            if(status == "success"){
                data = data.replace(new RegExp(term, "ig"), '<mark>'+term+'</mark>');

                $("#searchResults").html(data);
                $("#searchErrorMessage").hide();
            }
            else{
                $("#searchErrorMessage").html("Search failed.  Please try again.");
                $("#searchErrorMessage").show();
            }
         });
    }
}


JokeGenerator.loadRandomJoke();

const generator = new JokeGenerator();
generator.startJokeTimer();