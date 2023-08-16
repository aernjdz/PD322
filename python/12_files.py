# №3
def count_words(filename):
    try:
        with open(filename, 'r', encoding='utf-8') as file:
            content = file.read()
            words = content.split()
            return len(words)
    except FileNotFoundError:
        return "File not found!"

filename = 'test.txt' 
word_count = count_words(filename)
if isinstance(word_count, int):
    print(f"Word Count: {word_count}")
else:
    print(word_count)
# №2
def reverse_words(filename_input, filename_output):
    try:
        with open(filename_input, 'r', encoding='utf-8') as file:
            content = file.read()
            words = content.split()
            reversed_words = ' '.join(reversed(words))

            with open(filename_output, 'w+', encoding='utf-8') as output_file:
                output_file.write(reversed_words)
        print("Success reverse")
    except FileNotFoundError:
        print("File not found!")

input_filename = 'input.txt'  
output_filename = 'output.txt'  

reverse_words(input_filename, output_filename)
