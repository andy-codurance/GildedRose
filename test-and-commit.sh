#! /bin/bash

test() {
    dotnet test
}

commit() {
    $(git add .) && git commit -m "auto commit"
}

revert() {
    git reset --hard
}

$(test) && commit || revert 

