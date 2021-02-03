const isNullOrUndefined = s => {
    /**
     * Will evaluate to true if value is not:
     * null
     * undefined
     * NaN
     * empty string ("")
     * 0
     * false 
     * */
    if (s === null || s === undefined) {
        return true;
    }
    return false;
}

const isNullOrEmpty = s => {
    return isNullOrUndefined(s) || s === "";
}

const isNullOrWhitespace = s => {
    return isNullOrEmpty(s) || s.trim() === "";
}

const functionCollection = {
    isNullOrUndefined,
    isNullOrEmpty,
    isNullOrWhitespace
}

export default functionCollection;