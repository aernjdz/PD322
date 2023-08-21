# # №3
# def count_words(filename):
#     try:
#         with open(filename, 'r', encoding='utf-8') as file:
#             content = file.read()
#             words = content.split()
#             return len(words)
#     except FileNotFoundError:
#         return "File not found!"

# filename = 'test.txt' 
# word_count = count_words(filename)
# if isinstance(word_count, int):
#     print(f"Word Count: {word_count}")
# else:
#     print(word_count)
# # №2
# def reverse_words(filename_input, filename_output):
#     try:
#         with open(filename_input, 'r', encoding='utf-8') as file:
#             content = file.read()
#             words = content.split()
#             reversed_words = ' '.join(reversed(words))

#             with open(filename_output, 'w+', encoding='utf-8') as output_file:
#                 output_file.write(reversed_words)
#         print("Success reverse")
#     except FileNotFoundError:
#         print("File not found!")

# input_filename = 'input.txt'  
# output_filename = 'output.txt'  

# reverse_words(input_filename, output_filename)
#=============================================================================================


import re
#N1
def filter_words(input_file,output_file ,min_lenght=7):
    try:
        with open(input_file, "r",encoding='utf-8') as file:
            content = file.read()
            words = re.findall(r'\w+',content)
            filter_text = " ".join([word for word in words if len(word) >= min_lenght])
            with open(output_file , "w+",encoding="utf-8") as output:
                output.write(filter_text)
        print("Success")
    except FileNotFoundError:
        print("File not found!")

filter_words("01_input.txt", "01_output.txt")

#N2
def copy_lines(input_file,output_file):
    try:
        with open(input_file, 'r', encoding="utf-8") as input:
            lines = input.readlines()

            with open(output_file, "w+", encoding="utf-8") as output:
                output.writelines( lines)
        print("Success copy")     
    except FileNotFoundError:
        print("File not found!")
copy_lines("02_input.txt", "02_output.txt")

#N3
def reverse_lines(source_file, target_file):
    try:
        with open(source_file, 'r', encoding="utf-8") as source:
            lines = source.readlines()
        
        with open(target_file, 'w', encoding="utf-8") as target:
            reversed_lines = reversed(lines)
            target.writelines(reversed_lines)
        
        print("Lines reversed and written to the target file.")
    except FileNotFoundError:
        print("Source file not found.")
    except Exception as e:
        print(f"An error occurred: {e}")
reverse_lines("03_input.txt", "03_output.txt")

#4
def add_stars(source_file, target_file):
    try:
        with open(source_file, 'r', encoding="utf-8") as source:
            lines = source.readlines()

        last_line_without_comma_index = None
        for index, line in enumerate(reversed(lines)):
            if ',' not in line:
                last_line_without_comma_index = len(lines) - 1 - index
                break

        new_line = "************\n"
        if last_line_without_comma_index is not None:
            lines.insert(last_line_without_comma_index + 1, new_line)
        else:
            lines.append(new_line)

        with open(target_file, 'w', encoding="utf-8") as target:
            target.writelines(lines)

        print("New line added to the target file.")
    except FileNotFoundError:
        print("Source file not found.")
    except Exception as e:
        print(f"An error occurred: {e}")

add_stars("04_input.txt", "04_output.txt")

#N5

def count_words(filename, start_char):
    try:
        with open(filename, 'r', encoding="utf-8") as file:
            content = file.read()

        words = content.split()
        count = 0

        for word in words:
            if word.startswith(start_char):
                count += 1
        
        return count
    except FileNotFoundError:
        print("File not found.")
        return 0
    except Exception as e:
        print(f"An error occurred: {e}")
        return 0

start_char = input("Enter a character: ")    
print(f"Number of words starting with '{start_char}': {count_words('05_input.txt',start_char=start_char)}")
#N6
def replace_characters(source_filename, target_filename):
    try:
        with open(source_filename, 'r', encoding="utf-8") as source_file:
            content = source_file.read()

        content_replaced = content.replace('*', '#temp#').replace('&', '*').replace('#temp#', '&')

        with open(target_filename, 'w', encoding="utf-8") as target_file:
            target_file.write(content_replaced)

        print("Characters replaced and written to the target file.")
    except FileNotFoundError:
        print("Source file not found.")
    except Exception as e:
        print(f"An error occurred: {e}")

replace_characters("06_input.txt", "06_output.txt")
#N7
def write_array_to_file(array, filename):
    try:
        with open(filename, 'w+', encoding="utf-8") as file:
            for item in array:
                file.write(item + '\n')
        
        print("Array elements written to the file.")
    except Exception as e:
        print(f"An error occurred: {e}")

array = ["Hello", "World", "Python", "Programming", "Aernjdz", "(._.\")"]
    
write_array_to_file(array, "07_output.txt")

#N8 Тут було ідентичне завдання до 7 тому я пропустив

#N9
def count_characters(filename):
    try:
        with open(filename, 'r' , encoding="utf-8") as file:
            content = file.read()

        char_count = len(content)
        return char_count
    except FileNotFoundError:
        print("File not found.")
        return 0
    except Exception as e:
        print(f"An error occurred: {e}")
        return 0
print(f"Number of characters in the file: {count_characters('08_input.txt')}")
#N10
def count_lines(filename):
    try:
        with open(filename, 'r') as file:
            lines = file.readlines()

        line_count = len(lines)
        return line_count
    except FileNotFoundError:
        print("File not found.")
        return 0
    except Exception as e:
        print(f"An error occurred: {e}")
        return 0
print(f"Number of lines in the file: {count_lines('09_input.txt')}")
