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

filter_words("input_filter.txt","output_filter.txt")

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
copy_lines("input_copy.txt","output_copy.txt")

#N3

def 


