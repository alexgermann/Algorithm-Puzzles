fn main() {
    get_number_of_steps(-11);
    get_number_of_steps(1);
    get_number_of_steps(2);
    get_number_of_steps(6);
    get_number_of_steps(10);
    get_number_of_steps(16);
    get_number_of_steps(26);
    get_number_of_steps(100);
    get_number_of_steps(102);
    get_number_of_steps(529);
    get_number_of_steps(1000);
    get_number_of_steps(10002);
    get_number_of_steps(24500);
}

// Get smallest number of steps to reach 1
fn get_number_of_steps(input: i32) {
    let mut step_count = 0;
    let mut number = input;
    let mut step_list = Vec::new();
    // Validate input
    if (number < 1) || (number > std::i32::MAX) {
        println!("Input ({}) must be between 1 and {}", input, std::i32::MAX);
        return;
    }
    while number > 1 {
        // Get square root, if it is a whole number, use that
        let sqrt = f64::sqrt(number.into());
        if sqrt.fract() == 0.0 {
            // Square root is a whole number - best case, use that
            number = sqrt as i32;
        } else {
            let factors = get_factors(number);
            let next_square_root = sqrt as i32;
            let next_square = next_square_root * next_square_root;
            if ((factors.len() == 2) && (factors[0] == 1) && (factors[1] == number))
                || (next_square == number - 1)
            {
                // Prime number, or next number is a square.
                number -= 1;
            } else {
                // Look for smallest factor that is larger than square root
                for i in 0..factors.len() {
                    if factors[i] > next_square_root {
                        number = factors[i];
                        break;
                    }
                }
            }
        }
        step_list.push(number);
        step_count += 1;
    }
    println!(
        "Steps for {} to reach 1: {}. Step list: {:?}",
        input, step_count, step_list
    );
}

fn get_factors(n: i32) -> Vec<i32> {
    (1..n + 1)
        .into_iter()
        .filter(|&x| n % x == 0)
        .collect::<Vec<i32>>()
}
