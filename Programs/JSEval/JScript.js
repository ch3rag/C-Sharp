class JSEval {
    static function Eval(expression) {
		try {
			var evaluated =  eval(expression);
			if(typeof(evaluated) === "number") {
				 return evaluated * 1.0;
			} else {
				return evaluated;
			}
		} catch(e) {
			return null;
		}
    };
}