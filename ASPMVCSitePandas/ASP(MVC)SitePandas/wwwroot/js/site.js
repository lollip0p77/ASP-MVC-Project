const letterRegex = /^[a-zA-ZÀ-ÿ]+$/
const emailRegex = /^[a-zA-ZÀ-ÿ0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-ZÀ-ÿ0-9](?:[a-zA-ZÀ-ÿ0-9-]{0,61}[a-zA-ZÀ-ÿ0-9])?(?:\.[a-zA-ZÀ-ÿ0-9](?:[a-zA-ZÀ-ÿ0-9-]{0,61}[a-zA-ZÀ-ÿ0-9])?)*$/
const numberRegex = /^\d+$/;
const letterNumberRegex = /^[a-zA-ZÀ-ÿ0-9]+$/;
const nomRegex = /^[a-zA-ZÀ-ÿ]+(?:[-'][a-zA-ZÀ-ÿ]+)*$/;
const phoneRegex = /^\(\d{3}\)-\d{3}-\d{4}$/;
const codePostalRegex = /^[A-Z]\d[A-Z]\s?\d[A-Z]\d$/;

function RegexValidation(input,regex) {
    let valid;
    let value = input.value;
    switch (regex) {
        case 'letter':
                valid = letterRegex.test(value);
                break;
        case 'number':
                valid = numberRegex.test(value);
                break;
        case 'letterNumber':
                valid = letterNumberRegex.test(value);
                break;
        case 'nom':
                valid = nomRegex.test(value);
                break;
        case 'email':
                valid = emailRegex.test(value);
                break;
        case 'phone':
                valid = phoneRegex.test(value);
                break;
        case 'codePostal':
                valid = codePostalRegex.test(value);
                break;
    }
    return valid;
}
function ValidForm(form) {
    
}


